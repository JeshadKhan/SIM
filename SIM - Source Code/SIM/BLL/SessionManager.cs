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

namespace SIM.BLL
{
    public class SessionManager
    {
        public int ActiveUserId
        {
            get
            {
                return Convert.ToInt32(Security.Decrypt(HttpContext.Current.Session["ActiveUserId"].ToString()));
            }
            set
            {
                HttpContext.Current.Session["ActiveUserId"] = Security.Encrypt(value.ToString());
            }
        }
        public bool LoginFlag
        {
            get
            {
                return Convert.ToBoolean(Security.Decrypt(HttpContext.Current.Session["LoginFlag"].ToString()));
            }
            set
            {
                HttpContext.Current.Session["LoginFlag"] = Security.Encrypt(value.ToString());
            }
        }

        public void Add(string name, object value)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    string sessionName = '"' + name.Trim() + '"';
                    HttpContext.Current.Session[sessionName] = value;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public object Get(string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    return null;
                }
                else
                {
                    string sessionName = '"' + name.Trim() + '"';
                    return HttpContext.Current.Session[sessionName];
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ClearAll()
        {
            try
            {
                HttpContext.Current.Session.Clear();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool IsSessionExist()
        {
            bool flag = false;

            try
            {
                int? count = Convert.ToInt32(HttpContext.Current.Session.Count);

                if (count != null)
                {
                    if (count == 0)
                    {
                        flag = false;
                    }
                    else
                    {
                        flag = true;
                    }
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

            return flag;
        }

        public void IsAuthenticated()
        {
            try
            {
                if (!IsSessionExist())
                {
                    HttpContext.Current.Response.Redirect("~/UserAccount/LogIn");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}