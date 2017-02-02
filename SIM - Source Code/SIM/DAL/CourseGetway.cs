/*
 * Author               : Quaint Park
 * Copyright            : © 2017 Quaint Park.
 * Official Website     : www.quaintpark.com
 * ------------------------------------------------------------------------------
 * Developed By         : Jeshad Khan
 * Profile              : www.jeshadkhan.com
 * ------------------------------------------------------------------------------
 * Title                : Simple Institute Management (SIM)
 * Version              : 1.0
 * License              : Licensed under MIT <http://opensource.org/licenses/MIT>
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using SIM.Models;
using SIM.BLL;

namespace SIM.DAL
{
    public class CourseGetway
    {
        public bool SaveCourse(Course course)
        {
            bool flag = false;
            DBPlayer db = new DBPlayer();

            try
            {
                if (string.IsNullOrEmpty(course.Description))
                {
                    course.Description = string.Empty;
                }

                db.cmdText = "INSERT INTO Courses(Code, Name, Credit, Description, DepartmentId, SemesterId) VALUES(@Code, @Name, @Credit, @Description, @DepartmentId, @SemesterId)";

                db.command.Parameters.AddWithValue("@Code", course.Code);
                db.command.Parameters.AddWithValue("@Name", course.Name);
                db.command.Parameters.AddWithValue("@Credit", course.Credit);
                db.command.Parameters.AddWithValue("@Description", course.Description);
                db.command.Parameters.AddWithValue("@DepartmentId", course.DepartmentId);
                db.command.Parameters.AddWithValue("@SemesterId", course.SemesterId);

                db.Open();
                int rowsAffected = db.command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Close();
            }

            return flag;
        }

        public bool IsValidCourseCode(string courseCode)
        {
            bool flag = false;
            DBPlayer db = new DBPlayer();

            try
            {
                db.cmdText = "SELECT Code FROM Courses WHERE Code = @Code";

                db.command.Parameters.Add("Code", SqlDbType.VarChar);
                db.command.Parameters["Code"].Value = courseCode;

                db.Open();
                SqlDataReader reader = db.command.ExecuteReader();

                if (reader.HasRows)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }

                reader.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Close();
            }

            return flag;
        }

        public bool IsValidCourseName(string courseName)
        {
            bool flag = false;
            DBPlayer db = new DBPlayer();

            try
            {
                db.cmdText = "SELECT Name FROM Courses WHERE Name = @Name";

                db.command.Parameters.Add("Name", SqlDbType.VarChar);
                db.command.Parameters["Name"].Value = courseName;

                db.Open();
                SqlDataReader reader = db.command.ExecuteReader();

                if (reader.HasRows)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }

                reader.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Close();
            }

            return flag;
        }

        public List<Course> GetAllCourse()
        {
            List<Course> listOfCourse = new List<Course>();
            DBPlayer db = new DBPlayer();

            try
            {
                db.cmdText = "SELECT * FROM Courses";

                db.Open();
                SqlDataReader reader = db.command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Course course = new Course();
                        course.Id = int.Parse(reader["Id"].ToString());
                        course.EId = Security.Encrypt(reader["Id"].ToString());
                        course.Code = reader["Code"].ToString();
                        course.Name = reader["Name"].ToString();
                        course.Credit = float.Parse(reader["Credit"].ToString());

                        if (string.IsNullOrEmpty(reader["Description"].ToString()))
                        {
                            course.Description = "N/A";
                        }
                        else
                        {
                            course.Description = reader["Description"].ToString();
                        }

                        course.DepartmentId = int.Parse(reader["DepartmentId"].ToString());
                        course.SemesterId = int.Parse(reader["SemesterId"].ToString());
                        listOfCourse.Add(course);
                    }
                }

                reader.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Close();
            }

            return listOfCourse;
        }

        public Course GetCourseById(int id)
        {
            Course course = new Course();
            DBPlayer db = new DBPlayer();

            try
            {
                db.cmdText = "SELECT * FROM Courses WHERE Id = @Id";
                db.command.Parameters.AddWithValue("@Id", id);

                db.Open();
                SqlDataReader reader = db.command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        course.Id = int.Parse(reader["Id"].ToString());
                        course.Code = reader["Code"].ToString();
                        course.Name = reader["Name"].ToString();
                        course.Credit = float.Parse(reader["Credit"].ToString());
                        course.Description = reader["Description"].ToString();
                        course.DepartmentId = int.Parse(reader["DepartmentId"].ToString());
                        course.SemesterId = int.Parse(reader["SemesterId"].ToString());
                    }
                }

                reader.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Close();
            }

            return course;
        }

        public bool UpdateCourse(Course course)
        {
            bool flag = false;
            DBPlayer db = new DBPlayer();

            try
            {
                db.cmdText = "UPDATE Courses SET Code = @Code, Name = @Name, Credit = @Credit, Description = @Description, DepartmentId = @DepartmentId, SemesterId = @SemesterId WHERE Id = @Id";

                db.command.Parameters.AddWithValue("@Code", course.Code);
                db.command.Parameters.AddWithValue("@Name", course.Name);
                db.command.Parameters.AddWithValue("@Credit", course.Credit);
                db.command.Parameters.AddWithValue("@Description", course.Description);
                db.command.Parameters.AddWithValue("@DepartmentId", course.DepartmentId);
                db.command.Parameters.AddWithValue("@SemesterId", course.SemesterId);
                db.command.Parameters.AddWithValue("@Id", course.Id);

                db.Open();
                int rowsAffected = db.command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Close();
            }

            return flag;
        }

        public bool DeleteCourse(int id)
        {
            bool flag = false;
            DBPlayer db = new DBPlayer();

            try
            {
                db.cmdText = "DELETE FROM Courses WHERE Id = @Id";
                db.command.Parameters.AddWithValue("@Id", id);

                db.Open();
                int rowsAffected = db.command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Close();
            }

            return flag;
        }

        public bool AssignCourseTeacher(CourseTeacher courseTeacher)
        {
            bool flag = false;
            DBPlayer db = new DBPlayer();

            try
            {
                db.cmdText = "INSERT INTO CourseTeacher(DepartmentId, TeacherId, CourseId, Status) VALUES(@DepartmentId, @TeacherId, @CourseId, @Status)";

                db.command.Parameters.AddWithValue("@DepartmentId", courseTeacher.DepartmentId);
                db.command.Parameters.AddWithValue("@TeacherId", courseTeacher.TeacherId);
                db.command.Parameters.AddWithValue("@CourseId", courseTeacher.CourseId);
                db.command.Parameters.AddWithValue("@Status", true);

                db.Open();
                int rowsAffected = db.command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {

                    if (UpdateTeacherRemainingCourse(courseTeacher.TeacherId, courseTeacher.CourseCredit))
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                    }
                }
                else
                {
                    flag = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Close();
            }

            return flag;
        }

        private bool UpdateTeacherRemainingCourse(int teacherId, int courseCredit)
        {
            bool flag = false;
            DBPlayer db = new DBPlayer();

            try
            {
                Teacher teacher = GetCurrentcurrentRemainingCourseId(teacherId);
                int currentRemainingCredit = teacher.RemainingCredit;
                int updateRemainingCredit = currentRemainingCredit - courseCredit;

                if (updateRemainingCredit < 0)
                {
                    db.cmdText = "UPDATE Teachers SET RemainingCredit = @RemainingCredit WHERE Id = @Id";

                    db.command.Parameters.AddWithValue("@RemainingCredit", 0);
                    db.command.Parameters.AddWithValue("@Id", teacherId);

                    db.Open();
                    int rowsAffected = db.command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                    }
                }
                else
                {
                    db.cmdText = "UPDATE Teachers SET RemainingCredit = @RemainingCredit WHERE Id = @Id";

                    db.command.Parameters.AddWithValue("@RemainingCredit", updateRemainingCredit);
                    db.command.Parameters.AddWithValue("@Id", teacherId);

                    db.Open();
                    int rowsAffected = db.command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Close();
            }

            return flag;
        }

        private bool UpdateTeacherRemainingCourse(int teacherId, int courseId, int courseCredit)
        {
            bool flag = false;
            DBPlayer db = new DBPlayer();

            try
            {
                Teacher teacher = GetCurrentcurrentRemainingCourseId(teacherId);
                int currentRemainingCredit = teacher.RemainingCredit;
                int updateRemainingCredit = currentRemainingCredit + courseCredit;

                if (updateRemainingCredit > teacher.CreditToBeTaken)
                {
                    updateRemainingCredit = teacher.CreditToBeTaken;
                }

                db.cmdText = "UPDATE Teachers SET RemainingCredit = @RemainingCredit WHERE Id = @Id";

                db.command.Parameters.AddWithValue("@RemainingCredit", updateRemainingCredit);
                db.command.Parameters.AddWithValue("@Id", teacherId);

                db.Open();
                int rowsAffected = db.command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Close();
            }

            return flag;
        }

        private Teacher GetCurrentcurrentRemainingCourseId(int teacherId)
        {
            //int currentRemainingCredit = 0;
            Teacher teacher = new Teacher();
            DBPlayer db = new DBPlayer();

            try
            {
                db.cmdText = "SELECT CreditToBeTaken, RemainingCredit FROM Teachers WHERE Id = @Id";
                db.command.Parameters.AddWithValue("@Id", teacherId);

                db.Open();
                SqlDataReader reader = db.command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //currentRemainingCredit = int.Parse(reader["RemainingCredit"].ToString());
                        teacher.CreditToBeTaken = Convert.ToInt32(reader["CreditToBeTaken"]);
                        teacher.RemainingCredit = Convert.ToInt32(reader["RemainingCredit"]);
                        break;
                    }
                }

                reader.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Close();
            }

            //return currentRemainingCredit;
            return teacher;
        }

        public bool IsCourseTeacherPairExist(CourseTeacher courseTeacher)
        {
            bool flag = false;
            DBPlayer db = new DBPlayer();

            try
            {
                db.cmdText = "SELECT * FROM CourseTeacher WHERE TeacherId = @TeacherId AND CourseId = @CourseId AND Status = @Status";

                db.command.Parameters.AddWithValue("@TeacherId", courseTeacher.TeacherId);
                db.command.Parameters.AddWithValue("@CourseId", courseTeacher.CourseId);
                db.command.Parameters.AddWithValue("@Status", true);

                db.Open();
                SqlDataReader reader = db.command.ExecuteReader();

                if (reader.HasRows)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }

                reader.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Close();
            }

            return flag;
        }

        public bool IsCourseAssign(int courseId)
        {
            bool flag = false;
            DBPlayer db = new DBPlayer();

            try
            {
                db.cmdText = "SELECT * FROM CourseTeacher WHERE CourseId = @CourseId AND Status = @Status";
                db.command.Parameters.AddWithValue("@CourseId", courseId);
                db.command.Parameters.AddWithValue("@Status", true);

                db.Open();
                SqlDataReader reader = db.command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        CourseTeacher courseTeacher = new CourseTeacher();
                        courseTeacher.CourseAssignStatus = bool.Parse(reader["CourseAssignStatus"].ToString());

                        if (courseTeacher.CourseAssignStatus)
                        {
                            flag = true;
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                }
                else
                {
                    flag = false;
                }

                reader.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Close();
            }

            return flag;
        }

        public List<CourseTeacher> GetAllCourseCourseTeacher()
        {
            List<CourseTeacher> listOfCourseTeacher = new List<CourseTeacher>();
            DBPlayer db = new DBPlayer();

            try
            {
                db.cmdText = "SELECT * FROM CourseTeacherDepartmentView";

                db.Open();
                SqlDataReader reader = db.command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        CourseTeacher courseTeacher = new CourseTeacher();
                        courseTeacher.Id = int.Parse(reader["Id"].ToString());
                        courseTeacher.CourseId = int.Parse(reader["CourseId"].ToString());
                        courseTeacher.CourseCode = reader["CourseCode"].ToString();
                        courseTeacher.CourseName = reader["CourseName"].ToString();
                        courseTeacher.CourseCredit = Convert.ToInt32(reader["CourseCredit"]);
                        courseTeacher.TeacherId = int.Parse(reader["TeacherId"].ToString());
                        courseTeacher.TeacherName = reader["TeacherName"].ToString();
                        courseTeacher.TeacherDesignation = reader["TeacherDesignation"].ToString();
                        courseTeacher.TeacherCreditToBeTaken = Convert.ToInt32(reader["TeacherCreditToBeTaken"]);
                        courseTeacher.TeacherRemainingCredit = Convert.ToInt32(reader["TeacherRemainingCredit"]);
                        courseTeacher.DepartmentId = int.Parse(reader["DepartmentId"].ToString());
                        courseTeacher.DepartmentName = reader["DepartmentName"].ToString();
                        courseTeacher.CourseAssignStatus = Convert.ToBoolean(reader["Status"].ToString());

                        if (courseTeacher.CourseAssignStatus)
                        {
                            courseTeacher.Status = "Assigned";
                        }
                        else
                        {
                            courseTeacher.Status = "Not Assigned";
                        }

                        listOfCourseTeacher.Add(courseTeacher);
                    }
                }

                reader.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Close();
            }

            return listOfCourseTeacher;
        }

        public CourseTeacher GetCourseCourseTeacherById(int id, int cid, int tid)
        {
            CourseTeacher courseTeacher = new CourseTeacher();
            DBPlayer db = new DBPlayer();

            try
            {
                db.cmdText = "SELECT * FROM CourseTeacherDepartmentView WHERE Id = @Id AND CourseId = @CourseId AND TeacherId = @TeacherId";

                db.command.Parameters.AddWithValue("@Id", id);
                db.command.Parameters.AddWithValue("@CourseId", cid);
                db.command.Parameters.AddWithValue("@TeacherId", tid);

                db.Open();
                SqlDataReader reader = db.command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        courseTeacher.Id = int.Parse(reader["Id"].ToString());
                        courseTeacher.CourseId = int.Parse(reader["CourseId"].ToString());
                        courseTeacher.CourseCode = reader["CourseCode"].ToString();
                        courseTeacher.CourseName = reader["CourseName"].ToString();
                        courseTeacher.CourseCredit = Convert.ToInt32(reader["CourseCredit"]);
                        courseTeacher.TeacherId = int.Parse(reader["TeacherId"].ToString());
                        courseTeacher.TeacherName = reader["TeacherName"].ToString();
                        courseTeacher.TeacherDesignation = reader["TeacherDesignation"].ToString();
                        courseTeacher.TeacherCreditToBeTaken = Convert.ToInt32(reader["TeacherCreditToBeTaken"]);
                        courseTeacher.TeacherRemainingCredit = Convert.ToInt32(reader["TeacherRemainingCredit"]);
                        courseTeacher.DepartmentId = int.Parse(reader["DepartmentId"].ToString());
                        courseTeacher.DepartmentName = reader["DepartmentName"].ToString();
                        courseTeacher.CourseAssignStatus = Convert.ToBoolean(reader["Status"].ToString());

                        if (courseTeacher.CourseAssignStatus)
                        {
                            courseTeacher.Status = "Assigned";
                        }
                        else
                        {
                            courseTeacher.Status = "Not Assigned";
                        }

                        break;
                    }
                }

                reader.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Close();
            }

            return courseTeacher;
        }

        public bool UpdateCourseTeacher(CourseTeacher courseTeacher)
        {
            bool flag = false;
            DBPlayer db = new DBPlayer();

            try
            {
                db.cmdText = "UPDATE CourseTeacher SET DepartmentId = @DepartmentId, TeacherId = @TeacherId, Status = @Status WHERE Id = @Id AND CourseId = @CourseId";

                db.command.Parameters.AddWithValue("@DepartmentId", courseTeacher.DepartmentId);
                db.command.Parameters.AddWithValue("@TeacherId", courseTeacher.TeacherId);
                db.command.Parameters.AddWithValue("@Status", courseTeacher.CourseAssignStatus);
                db.command.Parameters.AddWithValue("@Id", courseTeacher.Id);
                db.command.Parameters.AddWithValue("@CourseId", courseTeacher.CourseId);

                db.Open();
                int rowsAffected = db.command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Close();
            }

            return flag;
        }

        public bool DeleteCourseTeacher(int id, int cid, int tid)
        {
            bool flag = false;
            DBPlayer db = new DBPlayer();

            try
            {
                CourseManager courseManager = new CourseManager();
                Course course = courseManager.GetCourseById(cid);

                if (UpdateTeacherRemainingCourse(tid, cid, Convert.ToInt32(course.Credit)))
                {
                    db.cmdText = "DELETE FROM CourseTeacher WHERE Id = @Id AND CourseId = @CourseId";

                    db.command.Parameters.AddWithValue("@Id", id);
                    db.command.Parameters.AddWithValue("@CourseId", cid);

                    db.Open();
                    int rowsAffected = db.command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Close();
            }

            return flag;
        }

        public List<CourseTeacherSemestersView> GetCourseTeacherSemesters()
        {
            List<CourseTeacherSemestersView> listOfCourseTeacherSemestersView = new List<CourseTeacherSemestersView>();
            DBPlayer db = new DBPlayer();

            try
            {
                db.cmdText = "SELECT * FROM CourseTeacherSemestersView";

                db.Open();
                SqlDataReader reader = db.command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        CourseTeacherSemestersView courseTeacherSemestersView = new CourseTeacherSemestersView();
                        courseTeacherSemestersView.Code = reader["Code"].ToString();
                        courseTeacherSemestersView.Name = reader["Name"].ToString();
                        courseTeacherSemestersView.SemesterName = reader["SemesterName"].ToString();
                        courseTeacherSemestersView.DepartmentId = int.Parse(reader["DepartmentId"].ToString());
                        courseTeacherSemestersView.AssignTeacherName = GetAssAssignTeacherByCouseCode(courseTeacherSemestersView.Code);

                        //if (string.IsNullOrEmpty(reader["AssignTeacherName"].ToString().Trim()))
                        //{
                        //    courseTeacherSemestersView.AssignTeacherName = "Not Assigned Yet";
                        //}
                        //else
                        //{
                        //    courseTeacherSemestersView.AssignTeacherName = reader["AssignTeacherName"].ToString();
                        //}

                        //listOfCourseTeacherSemestersView.Add(courseTeacherSemestersView);

                        if (listOfCourseTeacherSemestersView == null)
                        {
                            listOfCourseTeacherSemestersView.Add(courseTeacherSemestersView);
                        }
                        else
                        {
                            if (!IsCourseCodeExistInList(listOfCourseTeacherSemestersView, courseTeacherSemestersView.Code))
                            {
                                listOfCourseTeacherSemestersView.Add(courseTeacherSemestersView);
                            }
                        }
                    }
                }

                reader.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Close();
            }

            return listOfCourseTeacherSemestersView;
        }

        private bool IsCourseCodeExistInList(List<CourseTeacherSemestersView> listOfCourseTeacherSemestersView, string courseCode)
        {
            bool flag = false;

            try
            {
                foreach (CourseTeacherSemestersView item in listOfCourseTeacherSemestersView)
                {
                    if (item.Code == courseCode)
                    {
                        flag = true;
                        break;
                    }
                    else
                    {
                        flag = false;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return flag;
        }

        private string GetAssAssignTeacherByCouseCode(string courseCode)
        {
            String assignTeacher = string.Empty;
            DBPlayer db = new DBPlayer();

            try
            {
                db.cmdText = "SELECT * FROM CourseTeacherSemestersView WHERE Code = @CourseCode";
                db.command.Parameters.AddWithValue("@CourseCode", courseCode);

                db.Open();
                SqlDataReader reader = db.command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        bool status = false;

                        if (string.IsNullOrEmpty(reader["Status"].ToString().Trim()))
                        {
                            status = false;
                        }
                        else
                        {
                            status = bool.Parse(reader["Status"].ToString());
                        }


                        if (status)
                        {
                            if (assignTeacher == "Not Assigned Yet")
                            {
                                assignTeacher = string.Empty;
                            }

                            string assignTeacherName = reader["AssignTeacherName"].ToString().Trim();

                            if (string.IsNullOrEmpty(assignTeacherName))
                            {
                                assignTeacher = "Not Assigned Yet";
                            }
                            else
                            {
                                assignTeacher = assignTeacherName;
                            }
                        }
                        else
                        {
                            assignTeacher = "Not Assigned Yet";
                        }
                    }
                }

                reader.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Close();
            }

            return assignTeacher;
        }

        public bool UnassignCourses()
        {
            bool flag = false;
            DBPlayer db = new DBPlayer();

            try
            {
                db.cmdText = "UPDATE CourseTeacher SET Status = @Status";
                db.command.Parameters.AddWithValue("@Status", false);

                db.Open();
                int rowsAffected = db.command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    flag = true;

                    GetTeacherTakenCreditSetRemainingCredit();
                }
                else
                {
                    flag = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Close();
            }

            return flag;
        }

        private void GetTeacherTakenCreditSetRemainingCredit()
        {
            DBPlayer db = new DBPlayer();

            try
            {
                db.cmdText = "UPDATE Teachers SET RemainingCredit = CreditToBeTaken";

                db.Open();
                db.command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Close();
            }
        }
    }
}