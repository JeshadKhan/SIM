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
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security.DataHandler;
using Microsoft.Reporting.WebForms;
using SIM.Models;
using SIM.BLL;
using CrystalDecisions.CrystalReports.Engine;

namespace SIM.Controllers
{
    public class StudentController : Controller
    {
        DepartmentManager departmentManager = new DepartmentManager();
        StudentManager studentManager = new StudentManager();
        CourseManager courseManager = new CourseManager();
        SessionManager session = new SessionManager();

        public ActionResult Save(string id = null)
        {
            try
            {
                session.IsAuthenticated();
                GetDepartments();

                DateTime now = DateTime.Now;
                string today = now.ToShortDateString();
                ViewBag.Today = today;

                if (id != null)
                {
                    Student student = studentManager.GetStudentById(Convert.ToInt32(Security.Decrypt(id)));
                    ViewBag.Student = student;
                }
            }
            catch (Exception ex)
            {
                ViewBag.ExErrorMessage = ex.Message;
                return View();
            }

            return View();
        }

        private void GetDepartments()
        {
            try
            {
                List<Department> listOfDepartment = departmentManager.GetAllDepartment();
                ViewBag.Departments = listOfDepartment;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public ActionResult Save(Student student)
        {
            try
            {
                session.IsAuthenticated();

                if (student.EId != null && student.ERegNo != null)
                {
                    student.Id = Convert.ToInt32(Security.Decrypt(student.EId));
                    student.RegNo = Convert.ToString(Security.Decrypt(student.ERegNo));
                }

                student.DepartmentId = Convert.ToInt32(Security.Decrypt(student.EDepartmentId));
                GetDepartments();

                string name = student.Name;
                string email = student.Email;
                string contactNo = student.ContactNo;
                string departmentCode = student.DepartmentCode;

                if (string.IsNullOrEmpty(name))
                {
                    ViewBag.NameErrorMessage = "Please provide name.";
                    return View();
                }
                else if (string.IsNullOrEmpty(email))
                {
                    ViewBag.EnailErrorMessage = "Please provide email.";
                    return View();
                }
                else if (string.IsNullOrEmpty(contactNo))
                {
                    ViewBag.ContactNoErrorMessage = "Please provide contact number.";
                    return View();
                }
                else if (string.IsNullOrEmpty(departmentCode))
                {
                    ViewBag.DepartmentErrorMessage = "Please select department.";
                    return View();
                }
                else
                {
                    if (student.Id > 0)
                    {
                        if (studentManager.UpdateStudent(student))
                        {
                            ViewBag.SaveMessage = "Update successfully.";
                            Response.Redirect("~/Student/Get");
                        }
                        else
                        {
                            ViewBag.ExErrorMessage = "Failed to update.";
                        }
                    }
                    else
                    {
                        if (studentManager.SaveStudent(student))
                        {
                            ViewBag.SaveMessage = "Student registered successfully.";
                        }
                        else
                        {
                            ViewBag.ExErrorMessage = "Failed to register.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.ExErrorMessage = ex.Message;
                return View();
            }

            return View();
        }

        public ActionResult Get()
        {
            try
            {
                GetStudentsAndCourses();
            }
            catch (Exception ex)
            {
                ViewBag.ExErrorMessage = ex.Message;
                return View();
            }

            return View();
        }

        public JsonResult GetDepartmentByDepartmentId(string departmentId = null)
        {
            if (departmentId != null)
            {
                int deptId = Convert.ToInt32(Security.Decrypt(departmentId));
                var dept = departmentManager.GetAllDepartment();
                var deptList = dept.Where(d => d.Id == deptId).ToList();
                return Json(deptList, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(null, JsonRequestBehavior.AllowGet);            
        }

        public ActionResult DeleteStudent(string id = null)
        {
            try
            {
                if (id != null)
                {
                    if (studentManager.DeleteStudent(Convert.ToInt32(Security.Decrypt(id))))
                    {
                        ViewBag.SaveMessage = "Delete successfully.";
                    }
                    else
                    {
                        ViewBag.ExErrorMessage = "Failed to Delete.";
                    }
                }

                return RedirectToAction("Get");
            }
            catch (Exception ex)
            {
                ViewBag.ExErrorMessage = ex.Message;
                return RedirectToAction("Get");
            }
        }

        public ActionResult EnrollCourse(string id = null, string sid = null, string cid = null)
        {
            try
            {
                session.IsAuthenticated();
                GetStudentsAndCourses();

                if (id != null && sid != null && cid != null)
                {
                    Student studentEnrollCourse = studentManager.GetAllStudentEnrollCourseById(Convert.ToInt32(Security.Decrypt(id)), Convert.ToInt32(Security.Decrypt(sid)), Convert.ToInt32(Security.Decrypt(cid)));
                    ViewBag.StudentEnrollCourse = studentEnrollCourse;
                }
            }
            catch (Exception ex)
            {
                ViewBag.ExErrorMessage = ex.Message;
                return View();
            }

            return View();
        }

        private void GetStudentsAndCourses()
        {
            try
            {
                List<Student> listOfStudent = studentManager.GetAllStudent();
                ViewBag.Students = listOfStudent;

                Dictionary<string, string> grade = GetGrade();
                ViewBag.Grade = grade;

                List<Course> listOfCourse = courseManager.GetAllCourse();
                ViewBag.Courses = listOfCourse;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private Dictionary<string, string> GetGrade()
        {
            try
            {
                Dictionary<string, string> grade = new Dictionary<string, string>();
                grade.Add("A+", "A+");
                grade.Add("A", "A");
                grade.Add("A-", "A-");
                grade.Add("B+", "B+");
                grade.Add("B", "B");
                grade.Add("B-", "B-");
                grade.Add("C+", "C+");
                grade.Add("C", "C");
                grade.Add("C-", "C-");
                grade.Add("D+", "D+");
                grade.Add("D", "D");
                grade.Add("D-", "D-");
                grade.Add("F", "F");
                grade.Add("AB", "AB");

                return grade;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public ActionResult EnrollCourse(Student enrollCourse)
        {
            try
            {
                session.IsAuthenticated();

                if (enrollCourse.EId != null && enrollCourse.EDate != null && enrollCourse.EStatus != null)
                {
                    enrollCourse.Id = Convert.ToInt32(Security.Decrypt(enrollCourse.EId));
                    enrollCourse.Date = Convert.ToDateTime(Security.Decrypt(enrollCourse.EDate));
                    enrollCourse.Status = Convert.ToBoolean(Security.Decrypt(enrollCourse.EStatus));
                }

                enrollCourse.StudentId = Convert.ToInt32(Security.Decrypt(enrollCourse.EStudentId));
                enrollCourse.CourseId = Convert.ToInt32(Security.Decrypt(enrollCourse.ECourseId));
                GetStudentsAndCourses();

                int studentId = enrollCourse.StudentId;
                int courseId = enrollCourse.CourseId;

                if (studentId < 1)
                {
                    ViewBag.StudentErrorMessage = "Please select student.";
                    return View();
                }
                else if (courseId < 1)
                {
                    ViewBag.CourseErrorMessage = "Please select course.";
                    return View();
                }
                else
                {
                    if (enrollCourse.Id > 0)
                    {
                        if (studentManager.UpdateEnrollment(enrollCourse))
                        {
                            ViewBag.SaveMessage = "Update successfully.";
                            Response.Redirect("~/Student/EnrollCourseList");
                        }
                        else
                        {
                            ViewBag.ExErrorMessage = "Failed to update.";
                        }
                    }
                    else
                    {
                        if (studentManager.EnrollCourse(enrollCourse))
                        {
                            ViewBag.SaveMessage = "Student enrolled in course successfully.";
                        }
                        else
                        {
                            ViewBag.ExErrorMessage = "Failed to enroll course.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.ExErrorMessage = ex.Message;
                return View();
            }

            return View();
        }

        public ActionResult EnrollCourseList()
        {
            try
            {
                session.IsAuthenticated();
                List<Student> listOfEnrollCourse = studentManager.GetAllStudentEnrollCourse();
                ViewBag.EnrollCourseList = listOfEnrollCourse;
            }
            catch (Exception ex)
            {
                ViewBag.ExErrorMessage = ex.Message;
                return View();
            }

            return View();
        }

        public ActionResult DeleteEnrollCourse(string id = null, string sid = null, string cid = null)
        {
            try
            {
                session.IsAuthenticated();

                if (id != null && sid != null && cid != null)
                {
                    if (studentManager.DeleteEnrollCourse(Convert.ToInt32(Security.Decrypt(id)), Convert.ToInt32(Security.Decrypt(sid)), Convert.ToInt32(Security.Decrypt(cid))))
                    {
                        ViewBag.SaveMessage = "Delete successfully.";
                    }
                    else
                    {
                        ViewBag.ExErrorMessage = "Failed to Delete.";
                    }
                }

                return RedirectToAction("EnrollCourseList");
            }
            catch (Exception ex)
            {
                ViewBag.ExErrorMessage = ex.Message;
                return RedirectToAction("EnrollCourseList");
            }
        }

        public JsonResult GetStudentByStudentId(string studentId = null)
        {
            if (studentId != null)
            {
                int stdntId = Convert.ToInt32(Security.Decrypt(studentId));
                var student = studentManager.GetAllStudent();
                var studentList = student.Where(s => s.Id == stdntId).ToList();
                return Json(studentList, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(null, JsonRequestBehavior.AllowGet);            
        }

        public JsonResult GetCourseByDepartmentId(string departmentId = null)
        {
            if (departmentId != null)
            {
                int deptId = Convert.ToInt32(Security.Decrypt(departmentId));
                var course = courseManager.GetAllCourse();
                var courseList = course.Where(c => c.DepartmentId == deptId).ToList();
                return Json(courseList, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(null, JsonRequestBehavior.AllowGet);            
        }

        public ActionResult StudentResult(string id = null, string sid = null, string cid = null)
        {
            try
            {
                session.IsAuthenticated();
                GetStudentsAndCourses();

                if (id != null && sid != null && cid != null)
                {
                    Student studentResult = studentManager.GetStudentResultById(Convert.ToInt32(Security.Decrypt(id)), Convert.ToInt32(Security.Decrypt(sid)), Convert.ToInt32(Security.Decrypt(cid)));
                    ViewBag.StudentResult = studentResult;
                }
            }
            catch (Exception ex)
            {
                ViewBag.ExErrorMessage = ex.Message;
                return View();
            }

            return View();
        }

        [HttpPost]
        public ActionResult StudentResult(Student studentResult)
        {
            try
            {
                session.IsAuthenticated();

                if (studentResult.EId != null)
                {
                    studentResult.Id = Convert.ToInt32(Security.Decrypt(studentResult.EId));
                }

                studentResult.StudentId = Convert.ToInt32(Security.Decrypt(studentResult.EStudentId));
                studentResult.CourseId = Convert.ToInt32(Security.Decrypt(studentResult.ECourseId));
                studentResult.Grade = Convert.ToString(Security.Decrypt(studentResult.EGrade));
                GetStudentsAndCourses();

                int studentId = studentResult.StudentId;
                int courseId = studentResult.CourseId;

                if (studentId < 1)
                {
                    ViewBag.StudentErrorMessage = "Please select student.";
                    return View();
                }
                else if (courseId < 1)
                {
                    ViewBag.CourseErrorMessage = "Please select course.";
                    return View();
                }
                else
                {
                    if (studentResult.Id > 0)
                    {
                        if (studentManager.UpdateStudentResult(studentResult))
                        {
                            ViewBag.SaveMessage = "Update successfully.";
                            Response.Redirect("~/Student/StudentResultList");
                        }
                        else
                        {
                            ViewBag.ExErrorMessage = "Failed to update.";
                        }
                    }
                    else
                    {
                        if (studentManager.StudentResult(studentResult))
                        {
                            ViewBag.SaveMessage = "Student result saved successfully.";
                        }
                        else
                        {
                            ViewBag.ExErrorMessage = "Failed to save.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.ExErrorMessage = ex.Message;
                return View();
            }

            return View();
        }

        public ActionResult StudentResultList()
        {
            try
            {
                session.IsAuthenticated();
                List<Student> listOfStudentResult = studentManager.GetAllStudentResult();
                ViewBag.StudentResultList = listOfStudentResult;
            }
            catch (Exception ex)
            {
                ViewBag.ExErrorMessage = ex.Message;
                return View();
            }

            return View();
        }

        public ActionResult DeleteStudentResult(string id = null, string sid = null, string cid = null)
        {
            try
            {
                if (id != null && sid != null && cid != null)
                {
                    if (studentManager.DeleteStudentResult(Convert.ToInt32(Security.Decrypt(id)), Convert.ToInt32(Security.Decrypt(sid)), Convert.ToInt32(Security.Decrypt(cid))))
                    {
                        ViewBag.SaveMessage = "Delete successfully.";
                    }
                    else
                    {
                        ViewBag.ExErrorMessage = "Failed to Delete.";
                    }
                }

                return RedirectToAction("StudentResultList");
            }
            catch (Exception ex)
            {
                ViewBag.ExErrorMessage = ex.Message;
                return RedirectToAction("StudentResultList");
            }
        }

        public JsonResult GetCourseByStudentId(string studentId = null)
        {
            if (studentId != null)
            {
                int stdntId = Convert.ToInt32(Security.Decrypt(studentId));
                var student = studentManager.GetAllStudentCourse();
                var studentList = student.Where(s => s.Id == stdntId).ToList();
                return Json(studentList, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(null, JsonRequestBehavior.AllowGet);            
        }

        public ActionResult ViewResult()
        {
            try
            {
                GetStudentsAndCourses();
            }
            catch (Exception ex)
            {
                ViewBag.ExErrorMessage = ex.Message;
                return View();
            }

            return View();
        }

        [HttpPost]
        public ActionResult ViewResult(Student student)
        {
            try
            {
                GetStudentsAndCourses();

                if (student.EStudentId != null)
                {
                    string saveSheetname = "Student Result Sheet of " + student.RegNo + ".pdf";

                    ReportDocument rd = new ReportDocument();
                    rd.Load(Path.Combine(Server.MapPath("~/Report/ShudentResultSheet.rpt")));
                    rd.SetDataSource(studentManager.GetStudentResultReportByStudentId(Convert.ToInt32(Security.Decrypt(student.EStudentId))));
                    Response.Buffer = false;
                    Response.ClearContent();
                    Response.ClearHeaders();
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    stream.Seek(0, SeekOrigin.Begin);
                    return File(stream, "application/pdf", saveSheetname);
                }
                else
                {
                    ViewBag.ExErrorMessage = "Student not found.";
                }
            }
            catch (Exception ex)
            {
                ViewBag.ExErrorMessage = ex.Message;
                return View();
            }

            return View();
        }
    }
}