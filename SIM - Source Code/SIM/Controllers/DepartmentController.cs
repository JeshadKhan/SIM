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
    public class DepartmentController : Controller
    {
        DepartmentManager departmentManager = new DepartmentManager();
        SessionManager session = new SessionManager();

        public ActionResult Save(string id = null)
        {
            try
            {
                session.IsAuthenticated();

                if (id != null)
                {
                    Department dept = departmentManager.GetDepartmentById(Convert.ToInt32(Security.Decrypt(id)));
                    ViewBag.Department = dept;
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
        public ActionResult Save(Department department)
        {
            try
            {
                session.IsAuthenticated();

                if (department.EId != null)
                {
                    department.Id = Convert.ToInt32(Security.Decrypt(department.EId));
                }

                if (string.IsNullOrEmpty(department.Code))
                {
                    ViewBag.CodeErrorMessage = "Please provide code.";
                    return View();
                }
                else if (string.IsNullOrEmpty(department.Name))
                {
                    ViewBag.NameErrorMessage = "Please provide name.";
                    return View();
                }
                else
                {
                    if (department.Code.Length < 2 || department.Code.Length > 7)
                    {
                        ViewBag.CodeErrorMessage = "Code length should be between two to seven character long.";
                        return View();
                    }
                    else
                    {
                        if (department.Id > 0)
                        {
                            if (departmentManager.UpdateDepartment(department))
                            {
                                ViewBag.SaveMessage = "Update successfully.";
                                Response.Redirect("~/Department/Get");
                            }
                            else
                            {
                                ViewBag.ExErrorMessage = "Failed to update.";
                            }
                        }
                        else
                        {
                            if (departmentManager.SaveDepartment(department))
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

        public ActionResult DeleteDepartment(string id = null)
        {
            try
            {
                session.IsAuthenticated();

                if (id != null)
                {
                    if (departmentManager.DeleteDepartment(Convert.ToInt32(Security.Decrypt(id))))
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