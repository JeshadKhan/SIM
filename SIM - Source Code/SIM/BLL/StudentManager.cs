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
using SIM.Models;
using SIM.DAL;

namespace SIM.BLL
{
    public class StudentManager
    {
        public bool SaveStudent(Student student)
        {
            try
            {
                if (IsStudentExist(student.Email))
                {
                    throw new Exception("Student already exist.");
                }
                else
                {
                    StudentGetway studentGetway = new StudentGetway();
                    return studentGetway.SaveStudent(student);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private bool IsStudentExist(string studentEmail)
        {
            try
            {
                StudentGetway studentGetway = new StudentGetway();
                return studentGetway.IsStudentExist(studentEmail);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Student> GetAllStudent()
        {
            try
            {
                StudentGetway studentGetway = new StudentGetway();
                return studentGetway.GetAllStudent();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public Student GetStudentById(int id)
        {
            try
            {
                StudentGetway studentGetway = new StudentGetway();
                return studentGetway.GetStudentById(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UpdateStudent(Student student)
        {
            try
            {
                if (IsStudentEmailExist(student.Email, student.Id))
                {
                    throw new Exception("This email already exist.");
                }
                else
                {
                    StudentGetway studentGetway = new StudentGetway();
                    return studentGetway.UpdateStudent(student);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private bool IsStudentEmailExist(string studentEmail, int id)
        {
            try
            {
                StudentGetway studentGetway = new StudentGetway();
                return studentGetway.IsStudentEmailExist(studentEmail, id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteStudent(int id)
        {
            try
            {
                StudentGetway studentGetway = new StudentGetway();
                return studentGetway.DeleteStudent(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EnrollCourse(Student enrollCourse)
        {
            try
            {
                if (IsStudentEnrollCourseExist(enrollCourse))
                {
                    throw new Exception("Student already enrolled in this course.");
                }
                else
                {
                    StudentGetway studentGetway = new StudentGetway();
                    return studentGetway.EnrollCourse(enrollCourse);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private bool IsStudentEnrollCourseExist(Student enrollCourse)
        {
            try
            {
                StudentGetway studentGetway = new StudentGetway();
                return studentGetway.IsStudentEnrollCourseExist(enrollCourse);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Student> GetAllStudentEnrollCourse()
        {
            try
            {
                StudentGetway studentGetway = new StudentGetway();
                return studentGetway.GetAllStudentEnrollCourse();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Student GetAllStudentEnrollCourseById(int id, int sid, int cid)
        {
            try
            {
                StudentGetway studentGetway = new StudentGetway();
                return studentGetway.GetAllStudentEnrollCourseById(id, sid, cid);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UpdateEnrollment(Student enrollCourse)
        {
            try
            {
                if (IsStudentEnrollCourseExist(enrollCourse))
                {
                    throw new Exception("Student already enrolled in this course.");
                }
                else
                {
                    StudentGetway studentGetway = new StudentGetway();
                    return studentGetway.UpdateEnrollment(enrollCourse);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteEnrollCourse(int id, int sid, int cid)
        {
            try
            {
                StudentGetway studentGetway = new StudentGetway();
                return studentGetway.DeleteEnrollCourse(id, sid, cid);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Student> GetAllStudentCourse()
        {
            try
            {
                StudentGetway studentGetway = new StudentGetway();
                return studentGetway.GetAllStudentCourse();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool StudentResult(Student studentResult)
        {
            try
            {
                if (IsStudentResultExist(studentResult))
                {
                    throw new Exception("Student result already saved.");
                }
                else
                {
                    StudentGetway studentGetway = new StudentGetway();
                    return studentGetway.StudentResult(studentResult);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private bool IsStudentResultExist(Student studentResult)
        {
            try
            {
                StudentGetway studentGetway = new StudentGetway();
                return studentGetway.IsStudentResultExist(studentResult);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Student> GetAllStudentResult()
        {
            try
            {
                StudentGetway studentGetway = new StudentGetway();
                return studentGetway.GetAllStudentResult();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Student GetStudentResultById(int id, int sid, int cid)
        {
            try
            {
                StudentGetway studentGetway = new StudentGetway();
                return studentGetway.GetStudentResultById(id, sid, cid);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UpdateStudentResult(Student student)
        {
            try
            {
                StudentGetway studentGetway = new StudentGetway();
                return studentGetway.UpdateStudentResult(student);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteStudentResult(int id, int sid, int cid)
        {
            try
            {
                StudentGetway studentGetway = new StudentGetway();
                return studentGetway.DeleteStudentResult(id, sid, cid);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable GetStudentResultReportByStudentId(int studentId)
        {
            try
            {
                StudentGetway studentGetway = new StudentGetway();
                return studentGetway.GetStudentResultReportByStudentId(studentId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}