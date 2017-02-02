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
using SIM.Models;
using SIM.DAL;

namespace SIM.BLL
{
    public class SettingManager
    {
        public bool SaveSettings(Setting setting)
        {
            try
            {
                SettingGetway settings = new SettingGetway();
                return settings.SaveSettings(setting);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool SaveSliderSettings(Setting setting)
        {
            try
            {
                SettingGetway settings = new SettingGetway();
                return settings.SaveSliderSettings(setting);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool SaveSliderDefaultSettings(List<Setting> setting)
        {
            try
            {
                SettingGetway settings = new SettingGetway();
                return settings.SaveSliderDefaultSettings(setting);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UpdateSettings(Setting setting)
        {
            try
            {
                SettingGetway settings = new SettingGetway();
                return settings.UpdateSettings(setting);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public bool UpdateSliderSettings(List<Setting> setting)
        {
            try
            {
                SettingGetway settings = new SettingGetway();
                return settings.UpdateSliderSettings(setting);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UpdateSliderImageSettings(Setting setting)
        {
            try
            {
                SettingGetway settings = new SettingGetway();
                return settings.UpdateSliderImageSettings(setting);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Setting> GetAllBasicSettings()
        {
            try
            {
                SettingGetway settings = new SettingGetway();
                return settings.GetAllBasicSettings();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public List<Setting> GetAllSliderSettings()
        {
            try
            {
                SettingGetway settings = new SettingGetway();
                return settings.GetAllSliderSettings();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Setting> GetAllSliderSettingsById(int userId)
        {
            try
            {
                SettingGetway settings = new SettingGetway();
                return settings.GetAllSliderSettingsById(userId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Setting GetSliderImageById(int id)
        {
            try
            {
                SettingGetway settings = new SettingGetway();
                return settings.GetSliderImageById(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Setting GetSetting()
        {
            try
            {
                Setting setting = new Setting();
                var set = GetAllBasicSettings();
                //var setList = set.Where(s => s.UserId == userId).ToList();

                foreach (Setting s in set)
                {
                    //setting.UserId = s.UserId;
                    setting.InstituteFullName = s.InstituteFullName;
                    setting.InstituteShortName = s.InstituteShortName;
                    setting.BrandDescription = s.BrandDescription;
                    setting.BrandLogo = s.BrandLogo;
                    setting.BrandFavicon = s.BrandFavicon;
                    setting.Location = s.Location;
                    setting.Email = s.Email;
                    setting.MobileNumber = s.MobileNumber;
                    setting.PhoneNumber = s.PhoneNumber;
                    setting.Website = s.Website;
                    setting.GoogleMap = s.GoogleMap;
                    setting.AboutUs = s.AboutUs;
                    setting.FacebookLink = s.FacebookLink;
                    setting.GooglePlusLink = s.GooglePlusLink;
                    setting.TwitterLink = s.TwitterLink;
                    setting.YoutTubeLink = s.YoutTubeLink;
                    setting.LinkedInLink = s.LinkedInLink;
                    setting.GitHubLink = s.GitHubLink;
                    break;
                }

                return setting;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteSettings(int userId)
        {
            try
            {
                SettingGetway settings = new SettingGetway();
                return settings.DeleteSettings(userId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteSliderSettings(int userId)
        {
            try
            {
                SettingGetway settings = new SettingGetway();
                return settings.DeleteSliderSettings(userId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteSliderImageSettings(int id)
        {
            try
            {
                SettingGetway settings = new SettingGetway();
                return settings.DeleteSliderImageSettings(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}