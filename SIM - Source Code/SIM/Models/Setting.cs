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

namespace SIM.Models
{
    public class Setting
    {
        public int UserId { get; set; }
        public string InstituteFullName { get; set; }
        public string InstituteShortName { get; set; }
        public string BrandDescription { get; set; }
        public HttpPostedFileBase BrandLogoFile { get; set; }
        public string BrandLogo { get; set; }
        public HttpPostedFileBase BrandFaviconFile { get; set; }
        public string BrandFavicon { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Website { get; set; }
        public string GoogleMap { get; set; }
        public string AboutUs { get; set; }
        public string FacebookLink { get; set; }
        public string GooglePlusLink { get; set; }
        public string TwitterLink { get; set; }
        public string YoutTubeLink { get; set; }
        public string LinkedInLink { get; set; }
        public string GitHubLink { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }
        public string Image { get; set; }
        public string EId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public SystemUser GetUserDefaultInfo(int userId)
        {
            SystemUser user = new SystemUser();
            user.UserId = userId;
            user.FullName = "System Admin";
            user.Email = "admin";
            user.Password = "admin";
            user.Status = true;
            return user;
        }

        public Setting GetUserDefaultSetting(int userId)
        {
            Setting setting = new Setting();
            setting.UserId = userId;
            setting.InstituteFullName = "Simple Institute Management";
            setting.InstituteShortName = "SIM";
            setting.BrandDescription = "An open source institute management system.";
            setting.BrandLogo = "/Images/logo.png";
            setting.BrandFavicon = "/Images/favicon.png";
            setting.Location = "Bangladesh";
            setting.Email = "contact@domain.com";
            setting.MobileNumber = "+XXX XXXX XXX XXX";
            setting.PhoneNumber = "XXX XXXXXX";
            setting.Website = "www.domain.com";
            setting.GoogleMap = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3741170.263299203!2d90.34435205!3d23.694311749999997!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x30adaaed80e18ba7%3A0xf2d28e0c4e1fc6b!2sBangladesh!5e0!3m2!1sen!2s!4v1425390886644";
            setting.AboutUs = "We believe technology is a game changer, specially in education domain. It can help students, parents, teachers and management to stay connected and exchanging information almost in realtime while utilizing internet, mobiles, etc. It can enable institute to focus more on providing quality education while simplifying and automating day to day tasks.";
            setting.FacebookLink = "https://www.facebook.com";
            setting.GooglePlusLink = "https://plus.google.com";
            setting.TwitterLink = "https://twitter.com";
            setting.YoutTubeLink = "https://www.youtube.com";
            setting.LinkedInLink = "https://www.linkedin.com";
            setting.GitHubLink = "https://github.com";
            return setting;
        }

        public List<Setting> GetUserDefaultSliderSetting(int userId)
        {
            List<Setting> sliderSetting = new List<Setting>();
            sliderSetting.Add(new Setting() { UserId = userId, Image = "/Images/Slider/01.jpg", Title = "Initiative Institute", Description = "A distinguish landmark of learning." });
            sliderSetting.Add(new Setting() { UserId = userId, Image = "/Images/Slider/02.jpg", Title = "Global Linkage", Description = "The global innovation linkages programme provides link to the world." });
            sliderSetting.Add(new Setting() { UserId = userId, Image = "/Images/Slider/03.jpg", Title = "Pathway To The Future", Description = "The future pathway from dark to light." });
            return sliderSetting;
        }
    }
}