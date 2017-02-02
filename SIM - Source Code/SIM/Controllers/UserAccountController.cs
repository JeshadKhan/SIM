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
    public class UserAccountController : Controller
    {
        UserManager userManager = new UserManager();
        SettingManager settingManager = new SettingManager();
        SessionManager session = new SessionManager();

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(SystemUser user)
        {
            try
            {
                Setting setting = new Setting();
                user = setting.GetUserDefaultInfo(0);

                if (userManager.IsUserExist(user.Email))
                {
                    ViewBag.ExErrorMessage = "User already exist.";
                }
                else
                {
                    int userId = userManager.RegisterUser(user);
                    bool basicSetting = settingManager.SaveSettings(setting.GetUserDefaultSetting(userId));
                    bool sliderSetting = settingManager.SaveSliderDefaultSettings(setting.GetUserDefaultSliderSetting(userId));

                    if (userId > 0 && basicSetting == true && sliderSetting == true)
                    {
                        ViewBag.SaveMessage = "Register admin successfully.";
                        session.ClearAll();
                        Response.Redirect("~/UserAccount/LogIn");
                    }
                    else
                    {
                        ViewBag.ExErrorMessage = "Failed to Register.";
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return View();
        }

        public ActionResult LogIn()
        {
            session.ClearAll(); 
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(SystemUser user)
        {
            try
            {
                session.ClearAll();

                if (string.IsNullOrEmpty(user.Email))
                {
                    ViewBag.ExErrorMessage = "Email must be provided.";
                    return View();
                }
                else if (string.IsNullOrEmpty(user.Password))
                {
                    ViewBag.ExErrorMessage = "Password must be provided.";
                    return View();
                }
                else
                {
                    if (userManager.IsUserExist(user.Email))
                    {
                        if (userManager.Login(user))
                        {
                            ViewBag.SaveMessage = "Logged In successfully.";
                            session.LoginFlag = true;
                            session.Add("PageLoadCount", 0);
                            Response.Redirect("~/");
                        }
                        else
                        {
                            session.ClearAll();
                            ViewBag.ExErrorMessage = "Failed to Login.";
                        }
                    }
                    else
                    {
                        session.ClearAll();
                        ViewBag.ExErrorMessage = "User not exist.";
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return View();
        }

        public ActionResult LogOut()
        {
            try
            {
                session.ClearAll();
                Response.Redirect("~/UserAccount/LogIn");
            }
            catch (Exception)
            {

                throw;
            }

            return View();
        }
    }
}