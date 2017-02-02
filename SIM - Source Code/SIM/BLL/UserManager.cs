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
    public class UserManager
    {
        public int RegisterUser(SystemUser user)
        {
            try
            {
                UserGetway userGetway = new UserGetway();
                return userGetway.RegisterUser(user);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool IsUserExist()
        {
            try
            {
                UserGetway userGetway = new UserGetway();
                return userGetway.IsUserExist();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool IsUserExist(string email)
        {
            try
            {
                UserGetway userGetway = new UserGetway();
                return userGetway.IsUserExist(email);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Login(SystemUser user)
        {
            try
            {
                UserGetway userGetway = new UserGetway();
                return userGetway.Login(user);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public bool UpdateUser(SystemUser user)
        {
            try
            {
                UserGetway userGetway = new UserGetway();
                return userGetway.UpdateUser(user);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public SystemUser GetUserById(int id)
        {
            try
            {
                UserGetway userGetway = new UserGetway();
                return userGetway.GetUserById(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteUser(int userId)
        {
            try
            {
                UserGetway userGetway = new UserGetway();
                return userGetway.DeleteUser(userId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}