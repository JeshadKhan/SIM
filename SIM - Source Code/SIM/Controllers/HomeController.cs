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
    public class HomeController : Controller
    {
        SettingManager settingManager = new SettingManager();
        SessionManager session = new SessionManager();

        public ActionResult Index()
        {
            try
            {
                ViewBag.Settings = settingManager.GetSetting();
                ViewBag.Slider = settingManager.GetAllSliderSettings();

                //if (session.IsSessionExist())
                //{
                //    if (Convert.ToBoolean(session.LoginFlag))
                //    {
                //        Response.AddHeader("Refresh", "1");
                //    }
                //}
            }
            catch (Exception ex)
            {
                ViewBag.ExErrorMessage = ex.Message;
                return View();
            }

            return View();
        }

        public ActionResult About()
        {
            try
            {
                ViewBag.Settings = settingManager.GetSetting();
            }
            catch (Exception ex)
            {
                ViewBag.ExErrorMessage = ex.Message;
                return View();
            }

            return View();
        }

        public ActionResult Contact()
        {
            try
            {
                ViewBag.Settings = settingManager.GetSetting();
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