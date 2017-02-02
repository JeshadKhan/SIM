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
    public class TeacherController : Controller
    {
        TeacherManager teacherManager = new TeacherManager();
        DepartmentManager departmentManager = new DepartmentManager();
        SessionManager session = new SessionManager();

        public ActionResult Save(string id = null)
        {
            try
            {
                session.IsAuthenticated();

                if (id != null)
                {
                    Teacher teacher = teacherManager.GetTeacherById(Convert.ToInt32(Security.Decrypt(id)));
                    ViewBag.Teacher = teacher;
                }

                GetDesignationAndDepartment();
            }
            catch (Exception ex)
            {
                ViewBag.ExErrorMessage = ex.Message;
                return View();
            }

            return View();
        }

        private void GetDesignationAndDepartment()
        {
            try
            {
                List<Designation> listOfDesignations = teacherManager.GetAllDesignation();
                ViewBag.Designations = listOfDesignations;

                List<Department> listODepartments = departmentManager.GetAllDepartment();
                ViewBag.Departments = listODepartments;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public ActionResult Save(Teacher teacher)
        {
            try
            {
                session.IsAuthenticated();

                if (teacher.EId != null)
                {
                    teacher.Id = Convert.ToInt32(Security.Decrypt(teacher.EId));
                }

                teacher.DepartmentId = Convert.ToInt32(Security.Decrypt(teacher.EDepartmentId));
                GetDesignationAndDepartment();

                string name = teacher.Name;
                string email = teacher.Email;
                string contactNo = teacher.ContactNo;
                int designationId = teacher.DesignationId;
                int departmentId = teacher.DepartmentId;
                int credirToBeTaken = teacher.CreditToBeTaken;

                if (string.IsNullOrEmpty(name))
                {
                    ViewBag.NameErrorMessage = "Please provide name.";
                    return View();
                }
                else if (string.IsNullOrEmpty(email))
                {
                    ViewBag.EmailErrorMessage = "Please provide email.";
                    return View();
                }
                else if (string.IsNullOrEmpty(contactNo))
                {
                    ViewBag.ContactNoErrorMessage = "Please provide contact number.";
                    return View();
                }
                else if (designationId < 1)
                {
                    ViewBag.DesignationErrorMessage = "Select designation.";
                    return View();
                }
                else if (departmentId < 1)
                {
                    ViewBag.DepartmentErrorMessage = "Select department.";
                    return View();
                }
                else if (string.IsNullOrEmpty(credirToBeTaken.ToString().Trim()))
                {
                    ViewBag.CreditToBeTakenErrorMessage = "Please provide credit.";
                    return View();
                }
                else
                {
                    if (credirToBeTaken < 0)
                    {
                        ViewBag.CreditToBeTakenErrorMessage = "Credit should be non-negative value.";
                        return View();
                    }
                    else
                    {
                        if (teacher.Id > 0)
                        {
                            if (teacherManager.UpdateTeacher(teacher))
                            {
                                ViewBag.SaveMessage = "Update successfully.";
                                Response.Redirect("~/Teacher/Get");
                            }
                            else
                            {
                                ViewBag.ExErrorMessage = "Failed to update.";
                            }
                        }
                        else
                        {
                            if (teacherManager.SaveTeacher(teacher))
                            {
                                ViewBag.SaveMessage = "Teacher saved successfully.";
                            }
                            else
                            {
                                ViewBag.ExErrorMessage = "Failed to save.";
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
                List<Teacher> listOfTeacher = teacherManager.GetAllTeacher();
                ViewBag.Teachers = listOfTeacher;
            }
            catch (Exception ex)
            {
                ViewBag.ExErrorMessage = ex.Message;
                return View();
            }

            return View();
        }

        public ActionResult DeleteTeacher(string id = null)
        {
            try
            {
                session.IsAuthenticated();

                if (id != null)
                {
                    if (teacherManager.DeleteTeacher(Convert.ToInt32(Security.Decrypt(id))))
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
    }
}