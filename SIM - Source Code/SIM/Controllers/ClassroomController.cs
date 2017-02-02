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
    public class ClassroomController : Controller
    {
        ClassroomManager classroomManager = new ClassroomManager();
        DepartmentManager departmentManager = new DepartmentManager();
        CourseManager courseManager = new CourseManager();
        AllocateClassroomManager allocateClassroomManager = new AllocateClassroomManager();
        SessionManager session = new SessionManager();

        public ActionResult Save(string id = null)
        {
            try
            {
                session.IsAuthenticated();

                if (id != null)
                {
                    Classroom classroom = classroomManager.GetClassroomByRoomNo(Convert.ToString(Security.Decrypt(id)));
                    ViewBag.Classroom = classroom;
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
        public ActionResult Save(Classroom classroom)
        {
            try
            {
                session.IsAuthenticated();

                if (classroom.EId != null)
                {
                    classroom.Id = Convert.ToString(Security.Decrypt(classroom.EId));
                }

                if (string.IsNullOrEmpty(classroom.RoomNo))
                {
                    ViewBag.ExErrorMessage = "Please provide room no.";
                    return View();
                }
                else
                {
                    if (classroom.Id != null)
                    {
                        if (classroomManager.UpdateClassroom(classroom))
                        {
                            ViewBag.SaveMessage = "Update successfully.";
                            Response.Redirect("~/Classroom/Get");
                        }
                        else
                        {
                            ViewBag.ExErrorMessage = "Failed to update.";
                        }
                    }
                    else
                    {
                        if (classroomManager.SaveDepartment(classroom))
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
                List<Classroom> listOfClassroom = classroomManager.GetAllClassroom();
                ViewBag.Classrooms = listOfClassroom;
            }
            catch (Exception ex)
            {
                ViewBag.ExErrorMessage = ex.Message;
                return View();
            }

            return View();
        }

        public ActionResult DeleteClassroom(string id = null)
        {
            try
            {
                if (id != null)
                {
                    if (classroomManager.DeleteClassroom(Convert.ToString(Security.Decrypt(id))))
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

        public ActionResult Allocate(string id = null, string did = null, string cid = null)
        {
            try
            {
                session.IsAuthenticated();
                GetDepartmentAndRoomNo();

                Dictionary<string, string> day = GetDay();
                ViewBag.Day = day;

                if (id != null && did != null && cid != null)
                {
                    AllocateClassroom allocateClassroom = allocateClassroomManager.GetAllAllocateClassroomById(Convert.ToInt32(Security.Decrypt(id)), Convert.ToInt32(Security.Decrypt(did)), Convert.ToInt32(Security.Decrypt(cid)));
                    ViewBag.AllocateClassroom = allocateClassroom;
                }
            }
            catch (Exception ex)
            {
                ViewBag.ExErrorMessage = ex.Message;
                return View();
            }

            return View();
        }

        private void GetDepartmentAndRoomNo()
        {
            try
            {
                List<Department> listOfDepartment = departmentManager.GetAllDepartment();
                ViewBag.Departments = listOfDepartment;

                List<Classroom> listOfRoomNo = classroomManager.GetAllClassroom();
                ViewBag.Classroom = listOfRoomNo;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private Dictionary<string, string> GetDay()
        {
            try
            {
                Dictionary<string, string> day = new Dictionary<string, string>();
                day.Add("Saturday", "Saturday");
                day.Add("Sunday", "Sunday");
                day.Add("Monday", "Monday");
                day.Add("Tuesday", "Tuesday");
                day.Add("Wednesday", "Wednesday");
                day.Add("Thursday", "Thursday");
                day.Add("Friday", "Friday");

                return day;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public ActionResult Allocate(AllocateClassroom allocateClassroom)
        {
            try
            {
                session.IsAuthenticated();

                if (allocateClassroom.EId != null)
                {
                    allocateClassroom.Id = Convert.ToInt32(Security.Decrypt(allocateClassroom.EId));
                }

                allocateClassroom.DepartmentId = Convert.ToInt32(Security.Decrypt(allocateClassroom.EDepartmentId));
                allocateClassroom.CourseId = Convert.ToInt32(Security.Decrypt(allocateClassroom.ECourseId));
                allocateClassroom.RoomNo = Convert.ToString(Security.Decrypt(allocateClassroom.ERoomNo));
                allocateClassroom.Day = Convert.ToString(Security.Decrypt(allocateClassroom.EDay));

                if (allocateClassroom.Status != null)
                {
                    allocateClassroom.StatusFlag = true;
                }
                else
                {
                    allocateClassroom.StatusFlag = false;
                }

                GetDepartmentAndRoomNo();
                int deptId = allocateClassroom.DepartmentId;
                int courseId = allocateClassroom.CourseId;
                string roomNo = allocateClassroom.RoomNo;
                string day = allocateClassroom.Day;
                string fromTime = allocateClassroom.FromTime.ToString();
                string toTime = allocateClassroom.ToTime.ToString();

                if (deptId < 1)
                {
                    ViewBag.DepartmentErrorMessage = "Please select department";
                    return View();
                }
                else if (courseId < 1)
                {
                    ViewBag.CourseErrorMessage = "Please select course";
                    return View();
                }
                else if (roomNo == "--Select--")
                {
                    ViewBag.RoomNoErrorMessage = "Please select room number";
                    return View();
                }
                else if (day == "--Select--")
                {
                    ViewBag.DayErrorMessage = "Please select day";
                    return View();
                }
                else if (string.IsNullOrEmpty(fromTime))
                {
                    ViewBag.FromTimeErrorMessage = "Please provide class start time";
                    return View();
                }
                else if (string.IsNullOrEmpty(toTime))
                {
                    ViewBag.ToTimeErrorMessage = "Please provide class end time";
                    return View();
                }
                else
                {
                    if (allocateClassroom.Id > 0)
                    {
                        if (allocateClassroomManager.UpdateAllocateClassroom(allocateClassroom))
                        {
                            ViewBag.SaveMessage = "Update successfully.";
                            Response.Redirect("~/Classroom/AllocateList");
                        }
                        else
                        {
                            ViewBag.ExErrorMessage = "Failed to update.";
                        }
                    }
                    else
                    {
                        if (allocateClassroomManager.IsScheduleExist(allocateClassroom))
                        {
                            ViewBag.ExErrorMessage = "Schedule already exist.";
                            return View();
                        }
                        else
                        {
                            if (allocateClassroomManager.Save(allocateClassroom))
                            {
                                ViewBag.SaveMessage = "Classroom allocated.";
                            }
                            else
                            {
                                ViewBag.ExErrorMessage = "Failed to allocate classroom.";
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

        public ActionResult AllocateList()
        {
            try
            {
                session.IsAuthenticated();
                List<AllocateClassroom> listOfAllocateClassroom = allocateClassroomManager.GetAllAllocateClassroomList();
                ViewBag.AllocateClassroomList = listOfAllocateClassroom;
            }
            catch (Exception ex)
            {
                ViewBag.ExErrorMessage = ex.Message;
                return View();
            }

            return View();
        }

        public ActionResult DeleteAllocateClassroom(string id = null, string did = null, string cid = null)
        {
            try
            {
                session.IsAuthenticated();

                if (id != null && did != null && cid != null)
                {
                    if (allocateClassroomManager.DeleteAllocateClassroom(Convert.ToInt32(Security.Decrypt(id)), Convert.ToInt32(Security.Decrypt(did)), Convert.ToInt32(Security.Decrypt(cid))))
                    {
                        ViewBag.SaveMessage = "Delete successfully.";
                    }
                    else
                    {
                        ViewBag.ExErrorMessage = "Failed to Delete.";
                    }
                }

                return RedirectToAction("AllocateList");
            }
            catch (Exception ex)
            {
                ViewBag.ExErrorMessage = ex.Message;
                return RedirectToAction("AllocateList");
            }
        }

        public ActionResult ClassSchedule()
        {
            try
            {
                GetDepartmentAndRoomNo();
            }
            catch (Exception ex)
            {
                ViewBag.ExErrorMessage = ex.Message;
                return View();
            }

            return View();
        }

        public JsonResult GetAllocateClassroomsByDepartmentId(string departmentId = null)
        {
            if (departmentId != null)
            {
                int deptId = Convert.ToInt32(Security.Decrypt(departmentId));
                var allocateClassroom = allocateClassroomManager.GetAllAllocateClassroom();
                var allocateClassroomList = allocateClassroom.Where(ac => ac.DepartmentId == deptId).ToList();
                return Json(allocateClassroomList, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(null, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Unallocate()
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
        public ActionResult Unallocate(UnallocateClassroom unallocateClassroom)
        {
            try
            {
                if (allocateClassroomManager.UnallocateAllClassroom())
                {
                    ViewBag.SaveMessage = "All classroom successfully unallocated.";
                }
                else
                {
                    ViewBag.ExErrorMessage = "Failed to unallocate all classroom.";
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