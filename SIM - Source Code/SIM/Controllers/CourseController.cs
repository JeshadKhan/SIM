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
using System.Web.Mvc;
using SIM.Models;
using SIM.BLL;

namespace SIM.Controllers
{
    public class CourseController : Controller
    {
        DepartmentManager departmentManager = new DepartmentManager();
        SemesterManager semesterManager = new SemesterManager();
        CourseManager courseManager = new CourseManager();
        TeacherManager teacherManager = new TeacherManager();
        SessionManager session = new SessionManager();

        public ActionResult Save(string id = null)
        {
            try
            {
                session.IsAuthenticated();
                GetDepartmentAndSeester();

                if (id != null)
                {
                    Course course = courseManager.GetCourseById(Convert.ToInt32(Security.Decrypt(id)));
                    ViewBag.Course = course;
                }
            }
            catch (Exception ex)
            {
                ViewBag.ExErrorMessage = ex.Message;
                return View();
            }

            return View();
        }

        private void GetDepartmentAndSeester()
        {
            try
            {
                List<Department> listOfDepartment = departmentManager.GetAllDepartment();
                ViewBag.Departments = listOfDepartment;

                List<Semester> listOfSemester = semesterManager.GetAllSemester();
                ViewBag.Semesters = listOfSemester;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public ActionResult Save(Course course)
        {
            try
            {
                session.IsAuthenticated();
                GetDepartmentAndSeester();

                if (course.EId != null)
                {
                    course.Id = Convert.ToInt32(Security.Decrypt(course.EId));
                }

                course.DepartmentId = Convert.ToInt32(Security.Decrypt(course.EDepartmentId));
                course.SemesterId = Convert.ToInt32(Security.Decrypt(course.ESemesterId));

                string code = course.Code;
                string name = course.Name;
                float credit = course.Credit;
                int departmentId = course.DepartmentId;
                int semesterId = course.SemesterId;

                if (string.IsNullOrEmpty(course.Description))
                {
                    course.Description = string.Empty;
                }

                if (string.IsNullOrEmpty(code))
                {
                    ViewBag.CodeErrorMessage = "Please provide code.";
                    return View();
                }
                else if (string.IsNullOrEmpty(name))
                {
                    ViewBag.NameErrorMessage = "Please provide name.";
                    return View();
                }
                else if (string.IsNullOrEmpty(credit.ToString()))
                {
                    ViewBag.CreditErrorMessage = "Please provide credit.";
                    return View();
                }
                else if (departmentId < 1)
                {
                    ViewBag.DepartmentErrorMessage = "Please select department.";
                    return View();
                }
                else if (semesterId < 1)
                {
                    ViewBag.SemesterErrorMessage = "Please select semester.";
                    return View();
                }
                else
                {
                    if (code.Length < 5)
                    {
                        ViewBag.CodeErrorMessage = "Code length should be at least five character long.";
                        return View();
                    }
                    else
                    {
                        if (credit < 0.5 || credit > 5)
                        {
                            ViewBag.CreditErrorMessage = "Credit should be numeric value and between half to five.";
                            return View();
                        }
                        else
                        {
                            if (course.Id > 0)
                            {
                                if (courseManager.UpdateCourse(course))
                                {
                                    ViewBag.SaveMessage = "Update successfully.";
                                    Response.Redirect("~/Course/Get");
                                }
                                else
                                {
                                    ViewBag.ExErrorMessage = "Failed to update.";
                                }
                            }
                            else
                            {
                                if (courseManager.SaveCourse(course))
                                {
                                    ViewBag.SaveMessage = "Saved successfully.";
                                }
                                else
                                {
                                    ViewBag.ExErrorMessage = "Failed to save.";
                                }
                            }
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
                List<Course> listOfCourse = courseManager.GetAllCourse();
                ViewBag.Courses = listOfCourse;
            }
            catch (Exception ex)
            {
                ViewBag.ExErrorMessage = ex.Message;
                return View();
            }

            return View();
        }

        public ActionResult CourseTeacher(string id = null, string cid = null, string tid = null)
        {
            try
            {
                session.IsAuthenticated();
                GetDepartmentAndCourse();

                if (id != null && cid != null && tid != null)
                {
                    CourseTeacher courseTeacher = courseManager.GetCourseCourseTeacherById(Convert.ToInt32(Security.Decrypt(id)), Convert.ToInt32(Security.Decrypt(cid)), Convert.ToInt32(Security.Decrypt(tid)));
                    ViewBag.CourseTeacher = courseTeacher;
                }
            }
            catch (Exception ex)
            {
                ViewBag.ExErrorMessage = ex.Message;
                return View();
            }

            return View();
        }

        private void GetDepartmentAndCourse()
        {
            try
            {
                List<Department> listOfDepartment = departmentManager.GetAllDepartment();
                ViewBag.Departments = listOfDepartment;

                List<Course> listOfCourse = courseManager.GetAllCourse();
                ViewBag.Courses = listOfCourse;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult DeleteCourse(string id = null)
        {
            try
            {
                session.IsAuthenticated();

                if (id != null)
                {
                    if (courseManager.DeleteCourse(Convert.ToInt32(Security.Decrypt(id))))
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

        [HttpPost]
        public ActionResult CourseTeacher(CourseTeacher courseTeacher)
        {
            try
            {
                session.IsAuthenticated();
                GetDepartmentAndCourse();

                if (courseTeacher.EId != null)
                {
                    courseTeacher.Id = Convert.ToInt32(Security.Decrypt(courseTeacher.EId));
                }

                courseTeacher.DepartmentId = Convert.ToInt32(Security.Decrypt(courseTeacher.EDepartmentId));
                courseTeacher.TeacherId = Convert.ToInt32(Security.Decrypt(courseTeacher.ETeacherId));
                courseTeacher.CourseId = Convert.ToInt32(Security.Decrypt(courseTeacher.ECourseId));

                if (courseTeacher.Status != null)
                {
                    courseTeacher.CourseAssignStatus = true;
                }
                else
                {
                    courseTeacher.CourseAssignStatus = false;
                }

                int deptId = courseTeacher.DepartmentId;
                int teacherId = courseTeacher.TeacherId;
                int courseId = courseTeacher.CourseId;

                if (deptId < 1)
                {
                    ViewBag.DepartmentErrorMessage = "Please select department.";
                    return View();
                }
                else if (teacherId < 1)
                {
                    ViewBag.TeacherErrorMessage = "Please select teacher.";
                    return View();
                }
                else if (courseId < 1)
                {
                    ViewBag.CourseErrorMessage = "Please select course.";
                    return View();
                }
                else
                {
                    if (courseTeacher.Id > 0)
                    {
                        if (courseManager.UpdateCourseTeacher(courseTeacher))
                        {
                            ViewBag.SaveMessage = "Update successfully.";
                            Response.Redirect("~/Course/CourseTeacherList");
                        }
                        else
                        {
                            ViewBag.ExErrorMessage = "Failed to update.";
                        }
                    }
                    else
                    {
                        if (courseManager.AssignCourseTeacher(courseTeacher))
                        {
                            ViewBag.SaveMessage = "Course assign to teacher successfully.";
                        }
                        else
                        {
                            ViewBag.ExErrorMessage = "Failed to assigning course.";
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

        public JsonResult GetTeacherByDepartmentId(string departmentId = null)
        {
            if (departmentId != null)
            {
                int deptId = Convert.ToInt32(Security.Decrypt(departmentId));
                var dept = teacherManager.GetAllTeacher();
                var deptList = dept.Where(d => d.DepartmentId == deptId).ToList();
                return Json(deptList, JsonRequestBehavior.AllowGet);
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

        public JsonResult GetTeacherByTeacherId(string teacherId = null)
        {
            if (teacherId != null)
            {
                int tcherId = Convert.ToInt32(Security.Decrypt(teacherId));
                var teacher = teacherManager.GetAllTeacher();
                var techerList = teacher.Where(d => d.Id == tcherId).ToList();
                return Json(techerList, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(null, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCourseByCourseId(string courseId = null)
        {
            if (courseId != null)
            {
                int corsId = Convert.ToInt32(Security.Decrypt(courseId));
                var course = courseManager.GetAllCourse();
                var courseList = course.Where(c => c.Id == corsId).ToList();
                return Json(courseList, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(null, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CourseTeacherList()
        {
            try
            {
                session.IsAuthenticated();
                List<CourseTeacher> listOfCourseTeacher = courseManager.GetAllCourseCourseTeacher();
                ViewBag.CourseTeacherList = listOfCourseTeacher;
            }
            catch (Exception ex)
            {
                ViewBag.ExErrorMessage = ex.Message;
                return View();
            }

            return View();
        }

        public ActionResult DeleteCourseTeacher(string id = null, string cid = null, string tid = null)
        {
            try
            {
                if (id != null && cid != null && tid != null)
                {
                    if (courseManager.DeleteCourseTeacher(Convert.ToInt32(Security.Decrypt(id)), Convert.ToInt32(Security.Decrypt(cid)), Convert.ToInt32(Security.Decrypt(tid))))
                    {
                        ViewBag.SaveMessage = "Delete successfully.";
                    }
                    else
                    {
                        ViewBag.ExErrorMessage = "Failed to Delete.";
                    }
                }

                return RedirectToAction("CourseTeacherList");
            }
            catch (Exception ex)
            {
                ViewBag.ExErrorMessage = ex.Message;
                return RedirectToAction("CourseTeacherList");
            }
        }

        public ActionResult ViewCourseStatics()
        {
            try
            {
                List<Department> listOfDepartment = departmentManager.GetAllDepartment();
                ViewBag.Departments = listOfDepartment;
            }
            catch (Exception ex)
            {
                ViewBag.ExErrorMessage = ex.Message;
                return View();
            }

            return View();
        }

        public JsonResult GetCourseStaticsByDepartmentId(string departmentId = null)
        {
            if (departmentId != null)
            {
                int deptId = Convert.ToInt32(Security.Decrypt(departmentId));
                var courseTeacherSemesters = courseManager.GetCourseTeacherSemesters();
                var courseTeacherSemestersList = courseTeacherSemesters.Where(cts => cts.DepartmentId == deptId).ToList();
                return Json(courseTeacherSemestersList, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(null, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UnassignCourses()
        {
            try
            {
                session.IsAuthenticated();
            }
            catch (Exception ex)
            {
                ViewBag.ExErrorMessage = ex.Message;
                return View();
            }

            return View();
        }

        [HttpPost]
        public ActionResult UnassignCourses(UnassignCourse unassignCourse)
        {
            try
            {
                session.IsAuthenticated();

                if (courseManager.UnassignCourses())
                {
                    ViewBag.SaveMessage = "All the courses will be unassigned.";
                }
                else
                {
                    ViewBag.ExErrorMessage = "Failed to unassign courses.";
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