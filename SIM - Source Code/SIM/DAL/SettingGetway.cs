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
using System.Data;
using System.Data.SqlClient;

namespace SIM.DAL
{
    public class SettingGetway
    {
        public bool SaveSettings(Setting setting)
        {
            bool flag = false;
            DBPlayer db = new DBPlayer();

            try
            {
                db.cmdText = "INSERT INTO Settings(UserId, InstituteFullName, InstituteShortName, BrandDescription, BrandLogo, BrandFavicon, Location, Email, MobileNumber, PhoneNumber, Website, GoogleMap, AboutUs, FacebookLink, GooglePlusLink, TwitterLink, YoutTubeLink, LinkedInLink, GitHubLink) VALUES(@UserId, @InstituteFullName, @InstituteShortName, @BrandDescription, @BrandLogo, @BrandFavicon, @Location, @Email, @MobileNumber, @PhoneNumber, @Website, @GoogleMap, @AboutUs, @FacebookLink, @GooglePlusLink, @TwitterLink, @YoutTubeLink, @LinkedInLink, @GitHubLink)";

                db.command.Parameters.Add("UserId", SqlDbType.Int);
                db.command.Parameters["UserId"].Value = setting.UserId;

                db.command.Parameters.Add("InstituteFullName", SqlDbType.NVarChar);
                db.command.Parameters["InstituteFullName"].Value = setting.InstituteFullName;

                db.command.Parameters.Add("InstituteShortName", SqlDbType.NVarChar);
                db.command.Parameters["InstituteShortName"].Value = setting.InstituteShortName;

                db.command.Parameters.Add("BrandDescription", SqlDbType.NVarChar);
                db.command.Parameters["BrandDescription"].Value = setting.BrandDescription;

                db.command.Parameters.Add("BrandLogo", SqlDbType.NVarChar);
                db.command.Parameters["BrandLogo"].Value = setting.BrandLogo;

                db.command.Parameters.Add("BrandFavicon", SqlDbType.NVarChar);
                db.command.Parameters["BrandFavicon"].Value = setting.BrandFavicon;

                db.command.Parameters.Add("Location", SqlDbType.NVarChar);
                db.command.Parameters["Location"].Value = setting.Location;

                db.command.Parameters.Add("Email", SqlDbType.NVarChar);
                db.command.Parameters["Email"].Value = setting.Email;

                db.command.Parameters.Add("MobileNumber", SqlDbType.NVarChar);
                db.command.Parameters["MobileNumber"].Value = setting.MobileNumber;

                db.command.Parameters.Add("PhoneNumber", SqlDbType.NVarChar);
                db.command.Parameters["PhoneNumber"].Value = setting.PhoneNumber;

                db.command.Parameters.Add("Website", SqlDbType.NVarChar);
                db.command.Parameters["Website"].Value = setting.Website;

                db.command.Parameters.Add("GoogleMap", SqlDbType.NVarChar);
                db.command.Parameters["GoogleMap"].Value = setting.GoogleMap;

                db.command.Parameters.Add("AboutUs", SqlDbType.NVarChar);
                db.command.Parameters["AboutUs"].Value = setting.AboutUs;

                db.command.Parameters.Add("FacebookLink", SqlDbType.NVarChar);
                db.command.Parameters["FacebookLink"].Value = setting.FacebookLink;

                db.command.Parameters.Add("GooglePlusLink", SqlDbType.NVarChar);
                db.command.Parameters["GooglePlusLink"].Value = setting.GooglePlusLink;

                db.command.Parameters.Add("TwitterLink", SqlDbType.NVarChar);
                db.command.Parameters["TwitterLink"].Value = setting.TwitterLink;

                db.command.Parameters.Add("YoutTubeLink", SqlDbType.NVarChar);
                db.command.Parameters["YoutTubeLink"].Value = setting.YoutTubeLink;

                db.command.Parameters.Add("LinkedInLink", SqlDbType.NVarChar);
                db.command.Parameters["LinkedInLink"].Value = setting.LinkedInLink;

                db.command.Parameters.Add("GitHubLink", SqlDbType.NVarChar);
                db.command.Parameters["GitHubLink"].Value = setting.GitHubLink;

                db.Open();
                int rowsAffected = db.command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Close();
            }

            return flag;
        }

        public bool SaveSliderSettings(Setting setting)
        {
            bool flag = false;
            DBPlayer db = new DBPlayer();

            try
            {
                db.cmdText = "INSERT INTO SliderImages(UserId, Images, Title, Description) VALUES(@UserId, @Images, @Title, @Description)";

                db.command.Parameters.Add("UserId", SqlDbType.Int);
                db.command.Parameters["UserId"].Value = setting.UserId;

                db.command.Parameters.Add("Images", SqlDbType.NVarChar);
                db.command.Parameters["Images"].Value = setting.Image;

                db.command.Parameters.Add("Title", SqlDbType.NVarChar);
                db.command.Parameters["Title"].Value = setting.Title;

                db.command.Parameters.Add("Description", SqlDbType.NVarChar);
                db.command.Parameters["Description"].Value = setting.Description;

                db.Open();
                int rowsAffected = db.command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Close();
            }

            return flag;
        }

        public bool SaveSliderDefaultSettings(List<Setting> sliderSetting)
        {
            bool flag = false;
            DBPlayer db = new DBPlayer();

            try
            {
                db.cmdText = "INSERT INTO SliderImages(UserId, Images, Title, Description) VALUES(@UserId, @Images, @Title, @Description)";

                db.command.Parameters.Add("UserId", SqlDbType.Int);
                db.command.Parameters.Add("Images", SqlDbType.NVarChar);
                db.command.Parameters.Add("Title", SqlDbType.NVarChar);
                db.command.Parameters.Add("Description", SqlDbType.NVarChar);

                int rowsAffected = 0;
                db.Open();

                foreach (var setting in sliderSetting)
                {
                    db.command.Parameters["UserId"].Value = setting.UserId;
                    db.command.Parameters["Images"].Value = setting.Image;
                    db.command.Parameters["Title"].Value = setting.Title;
                    db.command.Parameters["Description"].Value = setting.Description;

                    rowsAffected += db.command.ExecuteNonQuery();
                }

                if (rowsAffected > 0)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Close();
            }

            return flag;
        }

        public bool UpdateSettings(Setting setting)
        {
            bool flag = false;
            DBPlayer db = new DBPlayer();

            try
            {
                db.cmdText = "UPDATE Settings SET InstituteFullName = @InstituteFullName, InstituteShortName = @InstituteShortName, BrandDescription = @BrandDescription, BrandLogo = @BrandLogo, BrandFavicon = @BrandFavicon, Location = @Location, Email = @Email, MobileNumber = @MobileNumber, PhoneNumber = @PhoneNumber, Website = @Website, GoogleMap = @GoogleMap, AboutUs = @AboutUs, FacebookLink = @FacebookLink, GooglePlusLink = @GooglePlusLink, TwitterLink = @TwitterLink, YoutTubeLink = @YoutTubeLink, LinkedInLink = @LinkedInLink, GitHubLink = @GitHubLink WHERE UserId = @UserId";

                db.command.Parameters.Add("InstituteFullName", SqlDbType.NVarChar);
                db.command.Parameters["InstituteFullName"].Value = setting.InstituteFullName;

                db.command.Parameters.Add("InstituteShortName", SqlDbType.NVarChar);
                db.command.Parameters["InstituteShortName"].Value = setting.InstituteShortName;

                db.command.Parameters.Add("BrandDescription", SqlDbType.NVarChar);
                db.command.Parameters["BrandDescription"].Value = setting.BrandDescription;

                db.command.Parameters.Add("BrandLogo", SqlDbType.NVarChar);
                db.command.Parameters["BrandLogo"].Value = setting.BrandLogo;

                db.command.Parameters.Add("BrandFavicon", SqlDbType.NVarChar);
                db.command.Parameters["BrandFavicon"].Value = setting.BrandFavicon;

                db.command.Parameters.Add("Location", SqlDbType.NVarChar);
                db.command.Parameters["Location"].Value = setting.Location;

                db.command.Parameters.Add("Email", SqlDbType.NVarChar);
                db.command.Parameters["Email"].Value = setting.Email;

                db.command.Parameters.Add("MobileNumber", SqlDbType.NVarChar);
                db.command.Parameters["MobileNumber"].Value = setting.MobileNumber;

                db.command.Parameters.Add("PhoneNumber", SqlDbType.NVarChar);
                db.command.Parameters["PhoneNumber"].Value = setting.PhoneNumber;

                db.command.Parameters.Add("Website", SqlDbType.NVarChar);
                db.command.Parameters["Website"].Value = setting.Website;

                db.command.Parameters.Add("GoogleMap", SqlDbType.NVarChar);
                db.command.Parameters["GoogleMap"].Value = setting.GoogleMap;

                db.command.Parameters.Add("AboutUs", SqlDbType.NVarChar);
                db.command.Parameters["AboutUs"].Value = setting.AboutUs;

                db.command.Parameters.Add("FacebookLink", SqlDbType.NVarChar);
                db.command.Parameters["FacebookLink"].Value = setting.FacebookLink;

                db.command.Parameters.Add("GooglePlusLink", SqlDbType.NVarChar);
                db.command.Parameters["GooglePlusLink"].Value = setting.GooglePlusLink;

                db.command.Parameters.Add("TwitterLink", SqlDbType.NVarChar);
                db.command.Parameters["TwitterLink"].Value = setting.TwitterLink;

                db.command.Parameters.Add("YoutTubeLink", SqlDbType.NVarChar);
                db.command.Parameters["YoutTubeLink"].Value = setting.YoutTubeLink;

                db.command.Parameters.Add("LinkedInLink", SqlDbType.NVarChar);
                db.command.Parameters["LinkedInLink"].Value = setting.LinkedInLink;

                db.command.Parameters.Add("GitHubLink", SqlDbType.NVarChar);
                db.command.Parameters["GitHubLink"].Value = setting.GitHubLink;

                db.command.Parameters.Add("UserId", SqlDbType.Int);
                db.command.Parameters["UserId"].Value = setting.UserId;

                db.Open();
                int rowsAffected = db.command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Close();
            }

            return flag;
        }

        public bool UpdateSliderSettings(List<Setting> setting)
        {
            bool flag = false;
            DBPlayer db = new DBPlayer();

            try
            {
                //db.cmdText = "UPDATE SliderImages SET UserId = @UserId, Images = @Images, Title = @Title, Description = @Description WHERE UserId = @UserId";

                if (DeleteSliderSettings(setting[0].UserId))
                {
                    db.cmdText = "INSERT INTO SliderImages(UserId, Images, Title, Description) VALUES(@UserId, @Images, @Title, @Description)";
                    db.Open();

                    foreach (Setting s in setting)
                    {
                        db.command.Parameters.Clear();

                        db.command.Parameters.Add("Images", SqlDbType.NVarChar);
                        db.command.Parameters["Images"].Value = s.Image;

                        db.command.Parameters.Add("Title", SqlDbType.NVarChar);
                        db.command.Parameters["Title"].Value = s.Title;

                        db.command.Parameters.Add("Description", SqlDbType.NVarChar);
                        db.command.Parameters["Description"].Value = s.Description;

                        db.command.Parameters.Add("UserId", SqlDbType.Int);
                        db.command.Parameters["UserId"].Value = s.UserId;

                        int rowsAffected = db.command.ExecuteNonQuery();
                    }

                    flag = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Close();
            }

            return flag;
        }

        public bool UpdateSliderImageSettings(Setting setting)
        {
            bool flag = false;
            DBPlayer db = new DBPlayer();

            try
            {
                db.cmdText = "UPDATE SliderImages SET UserId = @UserId, Images = @Images, Title = @Title, Description = @Description WHERE Id = @Id";

                db.command.Parameters.Add("UserId", SqlDbType.Int);
                db.command.Parameters["UserId"].Value = setting.UserId;

                db.command.Parameters.Add("Images", SqlDbType.NVarChar);
                db.command.Parameters["Images"].Value = setting.Image;

                db.command.Parameters.Add("Title", SqlDbType.NVarChar);
                db.command.Parameters["Title"].Value = setting.Title;

                db.command.Parameters.Add("Description", SqlDbType.NVarChar);
                db.command.Parameters["Description"].Value = setting.Description;

                db.command.Parameters.Add("Id", SqlDbType.Int);
                db.command.Parameters["Id"].Value = setting.Id;

                db.Open();
                int rowsAffected = db.command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Close();
            }

            return flag;
        }

        public List<Setting> GetAllBasicSettings()
        {
            List<Setting> listOfSetting = new List<Setting>();
            DBPlayer db = new DBPlayer();

            try
            {
                db.cmdText = "SELECT * FROM Settings";

                db.Open();
                SqlDataReader reader = db.command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Setting setting = new Setting();
                        setting.UserId = int.Parse(reader["UserId"].ToString());
                        setting.InstituteFullName = reader["InstituteFullName"].ToString();
                        setting.InstituteShortName = reader["InstituteShortName"].ToString();
                        setting.BrandDescription = reader["BrandDescription"].ToString();
                        setting.BrandLogo = reader["BrandLogo"].ToString();
                        setting.BrandFavicon = reader["BrandFavicon"].ToString();
                        setting.Location = reader["Location"].ToString();
                        setting.Email = reader["Email"].ToString();
                        setting.MobileNumber = reader["MobileNumber"].ToString();
                        setting.PhoneNumber = reader["PhoneNumber"].ToString();
                        setting.Website = reader["Website"].ToString();
                        setting.GoogleMap = reader["GoogleMap"].ToString();
                        setting.AboutUs = reader["AboutUs"].ToString();
                        setting.FacebookLink = reader["FacebookLink"].ToString();
                        setting.GooglePlusLink = reader["GooglePlusLink"].ToString();
                        setting.TwitterLink = reader["TwitterLink"].ToString();
                        setting.YoutTubeLink = reader["YoutTubeLink"].ToString();
                        setting.LinkedInLink = reader["LinkedInLink"].ToString();
                        setting.GitHubLink = reader["GitHubLink"].ToString();
                        listOfSetting.Add(setting);
                    }
                }

                reader.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Close();
            }

            return listOfSetting;
        }

        public List<Setting> GetAllSliderSettings()
        {
            List<Setting> listOfSetting = new List<Setting>();
            DBPlayer db = new DBPlayer();

            try
            {
                db.cmdText = "SELECT * FROM SliderImages";

                db.Open();
                SqlDataReader reader = db.command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Setting setting = new Setting();
                        setting.UserId = int.Parse(reader["UserId"].ToString());
                        setting.Image = reader["Images"].ToString();
                        setting.Title = reader["Title"].ToString();
                        setting.Description = reader["Description"].ToString();
                        listOfSetting.Add(setting);
                    }
                }

                reader.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Close();
            }

            return listOfSetting;
        }

        public List<Setting> GetAllSliderSettingsById(int userId)
        {
            List<Setting> listOfSetting = new List<Setting>();
            DBPlayer db = new DBPlayer();

            try
            {
                db.cmdText = "SELECT * FROM SliderImages WHERE UserId = @UserId";

                db.command.Parameters.Add("UserId", SqlDbType.Int);
                db.command.Parameters["UserId"].Value = userId;

                db.Open();
                SqlDataReader reader = db.command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Setting setting = new Setting();
                        setting.Id = int.Parse(reader["Id"].ToString());
                        setting.UserId = int.Parse(reader["UserId"].ToString());
                        setting.Image = reader["Images"].ToString();
                        setting.Title = reader["Title"].ToString();
                        setting.Description = reader["Description"].ToString();
                        listOfSetting.Add(setting);
                    }
                }

                reader.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Close();
            }

            return listOfSetting;
        }

        public Setting GetSliderImageById(int id)
        {
            Setting setting = new Setting();
            DBPlayer db = new DBPlayer();

            try
            {
                db.cmdText = "SELECT * FROM SliderImages WHERE Id = @Id";

                db.command.Parameters.Add("Id", SqlDbType.Int);
                db.command.Parameters["Id"].Value = id;

                db.Open();
                SqlDataReader reader = db.command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        setting.Id = int.Parse(reader["Id"].ToString());
                        setting.Image = reader["Images"].ToString();
                        setting.Title = reader["Title"].ToString();
                        setting.Description = reader["Description"].ToString();
                    }
                }

                reader.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Close();
            }

            return setting;
        }

        public bool DeleteSettings(int userId)
        {
            bool flag = false;
            DBPlayer db = new DBPlayer();

            try
            {
                db.cmdText = "DELETE FROM Settings WHERE UserId = @UserId";

                db.command.Parameters.Add("UserId", SqlDbType.Int);
                db.command.Parameters["UserId"].Value = userId;

                db.Open();
                int rowsAffected = db.command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Close();
            }

            return flag;
        }

        public bool DeleteSliderSettings(int userId)
        {
            bool flag = false;
            DBPlayer db = new DBPlayer();

            try
            {
                db.cmdText = "DELETE FROM SliderImages WHERE UserId = @UserId";

                db.command.Parameters.Add("UserId", SqlDbType.Int);
                db.command.Parameters["UserId"].Value = userId;

                db.Open();
                int rowsAffected = db.command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Close();
            }

            return flag;
        }

        public bool DeleteSliderImageSettings(int id)
        {
            bool flag = false;
            DBPlayer db = new DBPlayer();

            try
            {
                db.cmdText = "DELETE FROM SliderImages WHERE Id = @Id";

                db.command.Parameters.Add("Id", SqlDbType.Int);
                db.command.Parameters["Id"].Value = id;

                db.Open();
                int rowsAffected = db.command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Close();
            }

            return flag;
        }
    }
}