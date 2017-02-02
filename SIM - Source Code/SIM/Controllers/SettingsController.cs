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
using System.IO;
using SIM.Models;
using SIM.BLL;

namespace SIM.Controllers
{
    public class SettingsController : Controller
    {
        SettingManager settingManager = new SettingManager();
        SessionManager session = new SessionManager();
        UserManager userManager = new UserManager();

        public ActionResult Basic()
        {
            try
            {
                session.IsAuthenticated();
                Setting setting = settingManager.GetAllBasicSettings()[0];
                ViewBag.Settings = setting;
            }
            catch (Exception ex)
            {
                ViewBag.ExErrorMessage = ex.Message;
                return View();
            }

            return View();
        }

        [HttpPost]
        public ActionResult Basic(Setting setting)
        {
            try
            {
                session.IsAuthenticated();
                SettingManager settings = new SettingManager();
                Setting s = settingManager.GetAllBasicSettings()[0];

                if (!string.IsNullOrEmpty(setting.InstituteFullName))
                {
                    if (setting.InstituteFullName.Length > 50)
                    {
                        ViewBag.ExErrorMessage = "Maximum limit exist.";
                        return View();
                    }
                }
                else
                    setting.InstituteFullName = "";

                if (!string.IsNullOrEmpty(setting.InstituteShortName))
                {
                    if (setting.InstituteShortName.Length > 10)
                    {
                        ViewBag.ExErrorMessage = "Maximum limit exist.";
                        return View();
                    }
                }
                else
                    setting.InstituteShortName = "";

                if (!string.IsNullOrEmpty(setting.BrandDescription))
                {
                    if (setting.BrandDescription.Length > 5000)
                    {
                        ViewBag.ExErrorMessage = "Maximum limit exist.";
                        return View();
                    }
                }
                else
                    setting.BrandDescription = "";

                if (!string.IsNullOrEmpty(setting.Location))
                {
                    if (setting.Location.Length > 200)
                    {
                        ViewBag.ExErrorMessage = "Maximum limit exist.";
                        return View();
                    }
                }
                else
                    setting.Location = "";

                if (!string.IsNullOrEmpty(setting.Email))
                {
                    if (setting.Email.Length > 50)
                    {
                        ViewBag.ExErrorMessage = "Maximum limit exist.";
                        return View();
                    }
                }
                else
                    setting.Email = "";

                if (!string.IsNullOrEmpty(setting.MobileNumber))
                {
                    if (setting.MobileNumber.Length > 20)
                    {
                        ViewBag.ExErrorMessage = "Maximum limit exist.";
                        return View();
                    }
                }
                else
                    setting.MobileNumber = "";

                if (!string.IsNullOrEmpty(setting.PhoneNumber))
                {
                    if (setting.PhoneNumber.Length > 20)
                    {
                        ViewBag.ExErrorMessage = "Maximum limit exist.";
                        return View();
                    }
                }
                else
                    setting.PhoneNumber = "";

                if (!string.IsNullOrEmpty(setting.Website))
                {
                    if (setting.Website.Length > 50)
                    {
                        ViewBag.ExErrorMessage = "Maximum limit exist.";
                        return View();
                    }
                }
                else
                    setting.Website = "";

                if (!string.IsNullOrEmpty(setting.GoogleMap))
                {
                    if (setting.GoogleMap.Length > 500)
                    {
                        ViewBag.ExErrorMessage = "Maximum limit exist.";
                        return View();
                    }
                }
                else
                    setting.GoogleMap = "";

                if (!string.IsNullOrEmpty(setting.AboutUs))
                {
                    if (setting.AboutUs.Length > 5000)
                    {
                        ViewBag.ExErrorMessage = "Maximum limit exist.";
                        return View();
                    }
                }
                else
                    setting.AboutUs = "";

                if (!string.IsNullOrEmpty(setting.FacebookLink))
                {
                    if (setting.FacebookLink.Length > 100)
                    {
                        ViewBag.ExErrorMessage = "Maximum limit exist.";
                        return View();
                    }
                }
                else
                    setting.FacebookLink = "";

                if (!string.IsNullOrEmpty(setting.GooglePlusLink))
                {
                    if (setting.GooglePlusLink.Length > 100)
                    {
                        ViewBag.ExErrorMessage = "Maximum limit exist.";
                        return View();
                    }
                }
                else
                    setting.GooglePlusLink = "";

                if (!string.IsNullOrEmpty(setting.TwitterLink))
                {
                    if (setting.TwitterLink.Length > 100)
                    {
                        ViewBag.ExErrorMessage = "Maximum limit exist.";
                        return View();
                    }
                }
                else
                    setting.TwitterLink = "";

                if (!string.IsNullOrEmpty(setting.YoutTubeLink))
                {
                    if (setting.YoutTubeLink.Length > 100)
                    {
                        ViewBag.ExErrorMessage = "Maximum limit exist.";
                        return View();
                    }
                }
                else
                    setting.YoutTubeLink = "";

                if (!string.IsNullOrEmpty(setting.LinkedInLink))
                {
                    if (setting.LinkedInLink.Length > 100)
                    {
                        ViewBag.ExErrorMessage = "Maximum limit exist.";
                        return View();
                    }
                }
                else
                    setting.LinkedInLink = "";

                if (!string.IsNullOrEmpty(setting.GitHubLink))
                {
                    if (setting.GitHubLink.Length > 100)
                    {
                        ViewBag.ExErrorMessage = "Maximum limit exist.";
                        return View();
                    }
                }
                else
                    setting.GitHubLink = "";

                if (setting.BrandLogoFile != null)
                {
                    if (Path.GetExtension(setting.BrandLogoFile.FileName.ToString()).ToLower() != ".png")
                    {
                        ViewBag.ExErrorMessage = "File is not in correct format. Only PNG can be used.";
                        return View();
                    }
                    else
                    {
                        var brandLogoFileName = Path.GetFileName(setting.BrandLogoFile.FileName);
                        var brandLogoFilePath = Path.Combine(Server.MapPath("~/Images/UserFiles/"), brandLogoFileName);
                        setting.BrandLogo = "/Images/UserFiles/" + brandLogoFileName.ToString();
                        setting.BrandLogoFile.SaveAs(brandLogoFilePath);
                    }
                }
                else
                    setting.BrandLogo = s.BrandLogo;

                if (setting.BrandFaviconFile != null)
                {
                    if (Path.GetExtension(setting.BrandFaviconFile.FileName.ToString()).ToLower() != ".png")
                    {
                        ViewBag.ExErrorMessage = "File is not in correct format. Only PNG can be used.";
                        return View();
                    }
                    else
                    {
                        var brandFaviconFileName = Path.GetFileName(setting.BrandFaviconFile.FileName);
                        var brandFaviconFilePath = Path.Combine(Server.MapPath("~/Images/UserFiles/"), brandFaviconFileName);
                        setting.BrandFavicon = "/Images/UserFiles/" + brandFaviconFileName.ToString();
                        setting.BrandFaviconFile.SaveAs(brandFaviconFilePath);
                    }
                }
                else
                    setting.BrandFavicon = s.BrandFavicon;

                setting.UserId = session.ActiveUserId;

                if (settings.UpdateSettings(setting))
                {
                    ViewBag.SaveMessage = "Saved successfully.";

                    Setting set = settingManager.GetAllBasicSettings()[0];
                    ViewBag.Settings = set;
                }
                else
                {
                    ViewBag.ExErrorMessage = "Failed to save.";
                }
            }
            catch (Exception ex)
            {
                ViewBag.ExErrorMessage = ex.Message;
                return View();
            }

            return View();
        }

        public ActionResult Slider(string id = null)
        {
            try
            {
                session.IsAuthenticated();
                LoadSliderSettings();

                if (id != null)
                {
                    Setting sliderImageSettings = settingManager.GetSliderImageById(Convert.ToInt32(Security.Decrypt(id)));
                    ViewBag.SliderImageSettings = sliderImageSettings;
                }
            }
            catch (Exception ex)
            {
                ViewBag.ExErrorMessage = ex.Message;
                return View();
            }

            return View();
        }

        private void LoadSliderSettings()
        {
            try
            {
                List<Setting> listOfSettings = settingManager.GetAllSliderSettingsById(session.ActiveUserId);
                ViewBag.SliderSettings = listOfSettings;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public ActionResult Slider(Setting setting)
        {
            try
            {
                session.IsAuthenticated();

                if (setting.EId != null)
                {
                    setting.Id = Convert.ToInt32(Security.Decrypt(setting.EId));
                }

                SettingManager settings = new SettingManager();
                setting.UserId = session.ActiveUserId;

                if (!string.IsNullOrEmpty(setting.Title))
                {
                    if (setting.Title.Length > 100)
                    {
                        ViewBag.ExErrorMessage = "Maximum limit exist.";
                        return View();
                    }
                }
                else
                {
                    ViewBag.ExErrorMessage = "Please provide title.";
                    return View();
                }

                if (!string.IsNullOrEmpty(setting.Description))
                {
                    if (setting.Description.Length > 150)
                    {
                        ViewBag.ExErrorMessage = "Maximum limit exist.";
                        return View();
                    }
                }
                else
                {
                    ViewBag.ExErrorMessage = "Please provide description.";
                    return View();
                }

                if (setting.Id > 0)
                {
                    Setting sliderImageSettings = settingManager.GetSliderImageById(setting.Id);

                    if (setting.ImageFile != null)
                    {
                        if (Path.GetExtension(setting.ImageFile.FileName.ToString()).ToLower() != ".jpg")
                        {
                            ViewBag.ExErrorMessage = "File is not in correct format. Only JPG can be used.";
                            return View();
                        }
                        else
                        {
                            var imgFileName = Path.GetFileName(setting.ImageFile.FileName);
                            var imgFilePath = Path.Combine(Server.MapPath("~/Images/UserFiles/Slider/"), imgFileName);
                            setting.Image = "/Images/UserFiles/Slider/" + imgFileName.ToString();
                            setting.ImageFile.SaveAs(imgFilePath);
                        }
                    }
                    else
                        setting.Image = sliderImageSettings.Image;

                    if (settings.UpdateSliderImageSettings(setting))
                    {
                        ViewBag.SaveMessage = "Update successfully.";
                        LoadSliderSettings();
                    }
                    else
                    {
                        ViewBag.ExErrorMessage = "Failed to update.";
                    }

                    Response.Redirect("~/Settings/Slider");
                }
                else
                {
                    if (setting.ImageFile != null)
                    {
                        if (Path.GetExtension(setting.ImageFile.FileName.ToString()).ToLower() != ".jpg")
                        {
                            ViewBag.ExErrorMessage = "File is not in correct format. Only JPG can be used.";
                            return View();
                        }
                        else
                        {
                            var imgFileName = Path.GetFileName(setting.ImageFile.FileName);
                            var imgFilePath = Path.Combine(Server.MapPath("~/Images/UserFiles/Slider/"), imgFileName);
                            setting.Image = "/Images/UserFiles/Slider/" + imgFileName.ToString();
                            setting.ImageFile.SaveAs(imgFilePath);
                        }

                        if (settings.SaveSliderSettings(setting))
                        {
                            ViewBag.SaveMessage = "Saved successfully.";
                            LoadSliderSettings();
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

        public ActionResult DeleteSliderImage(string id = null)
        {
            try
            {
                session.IsAuthenticated();

                if (id != null)
                {
                    if (settingManager.DeleteSliderImageSettings(Convert.ToInt32(Security.Decrypt(id))))
                    {
                        ViewBag.SaveMessage = "Delete successfully.";
                        LoadSliderSettings();
                    }
                    else
                    {
                        ViewBag.ExErrorMessage = "Failed to Delete.";
                    }
                }

                return RedirectToAction("Slider");
            }
            catch (Exception ex)
            {
                ViewBag.ExErrorMessage = ex.Message;
                return RedirectToAction("Slider");
            }
        }

        public ActionResult ChangePassword()
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
        public ActionResult ChangePassword(SystemUser user)
        {
            try
            {
                session.IsAuthenticated();
                SystemUser sysusr = userManager.GetUserById(session.ActiveUserId);

                if (user.Password != user.ConfirmPassword)
                {
                    ViewBag.ExErrorMessage = "Password doesn't match.";
                    return View();
                }

                if (!string.IsNullOrEmpty(user.Password))
                {
                    if (user.Password.Length > 300)
                    {
                        ViewBag.ExErrorMessage = "Maximum limit exist.";
                        return View();
                    }
                }

                sysusr.Password = user.Password;
                bool change = userManager.UpdateUser(sysusr);

                if (change)
                {
                    ViewBag.SaveMessage = "Password changed successfully.";
                }
                else
                {
                    ViewBag.ExErrorMessage = "Failed to change.";
                }
            }
            catch (Exception ex)
            {
                ViewBag.ExErrorMessage = ex.Message;
                return View();
            }

            return View();
        }

        public ActionResult Default()
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
        public ActionResult Default(Setting set)
        {
            try
            {
                session.IsAuthenticated();

                Setting setting = new Setting();
                bool change = userManager.UpdateUser(setting.GetUserDefaultInfo(session.ActiveUserId));
                bool basicSetting = settingManager.UpdateSettings(setting.GetUserDefaultSetting(session.ActiveUserId));
                bool sliderSetting = settingManager.UpdateSliderSettings(setting.GetUserDefaultSliderSetting(session.ActiveUserId));
                bool deleteFiles = DeleteImageFiles();

                if (change == true && basicSetting == true && sliderSetting == true && deleteFiles == true)
                {
                    ViewBag.SaveMessage = "Restore default all settings successfully.";
                }
                else
                {
                    ViewBag.ExErrorMessage = "Failed to Restore.";
                }
            }
            catch (Exception ex)
            {
                ViewBag.ExErrorMessage = ex.Message;
                return View();
            }

            return View();
        }

        public ActionResult Delete()
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
        public ActionResult Delete(Setting set)
        {
            try
            {
                session.IsAuthenticated();

                bool sliderSetting = settingManager.DeleteSliderSettings(session.ActiveUserId);
                bool basicSetting = settingManager.DeleteSettings(session.ActiveUserId);
                bool user = userManager.DeleteUser(session.ActiveUserId);
                bool deleteFiles = DeleteImageFiles();

                if (user == true && basicSetting == true && sliderSetting == true && deleteFiles == true)
                {
                    ViewBag.SaveMessage = "Permanently delete user and all settings successfully.";
                    session.ClearAll();
                    Response.Redirect("~/");
                }
                else
                {
                    ViewBag.ExErrorMessage = "Failed to delete.";
                }
            }
            catch (Exception ex)
            {
                ViewBag.ExErrorMessage = ex.Message;
                return View();
            }

            return View();
        }

        private bool DeleteImageFiles()
        {
            bool flag = false;

            try
            {
                string[] sliderImagesFilePath = Directory.GetFiles(Server.MapPath("~/Images/UserFiles/Slider/"));

                foreach (string file in sliderImagesFilePath)
                {
                    System.IO.File.Delete(file);
                }

                string[] imagesFilePath = Directory.GetFiles(Server.MapPath("~/Images/UserFiles/"));

                foreach (string file in imagesFilePath)
                {
                    System.IO.File.Delete(file);
                }

                flag = true;
            }
            catch (Exception)
            {

                throw;
            }

            return flag;
        }
    }
}