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
using SIM.BLL;
using System.Data;
using System.Data.SqlClient;

namespace SIM.DAL
{
    public class UserGetway
    {
        public int RegisterUser(SystemUser user)
        {
            int userId = 0;
            DBPlayer db = new DBPlayer();

            try
            {
                db.cmdText = "INSERT INTO Users(FullName, Email, Password, Status) VALUES(@FullName, @Email, @Password, @Status)";

                db.command.Parameters.Add("FullName", SqlDbType.NVarChar);
                db.command.Parameters["FullName"].Value = user.FullName;

                db.command.Parameters.Add("Email", SqlDbType.NVarChar);
                db.command.Parameters["Email"].Value = user.Email;

                db.command.Parameters.Add("Password", SqlDbType.NVarChar);
                db.command.Parameters["Password"].Value = user.Password;

                db.command.Parameters.Add("Status", SqlDbType.Bit);
                db.command.Parameters["Status"].Value = user.Status;

                db.Open();
                int rowsAffected = db.command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    userId = GetUserIdByEmail(user.Email);
                }
                else
                {
                    userId = 0;
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

            return userId;
        }

        public bool IsUserExist()
        {
            bool flag = false;
            DBPlayer db = new DBPlayer();

            try
            {
                db.cmdText = "SELECT Email FROM Users";

                db.Open();
                SqlDataReader reader = db.command.ExecuteReader();

                if (reader.HasRows)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
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

            return flag;
        }

        public bool IsUserExist(string email)
        {
            bool flag = false;
            DBPlayer db = new DBPlayer();

            try
            {
                db.cmdText = "SELECT Email FROM Users WHERE Email = @Email";

                db.command.Parameters.Add("Email", SqlDbType.NVarChar);
                db.command.Parameters["Email"].Value = email;

                db.Open();
                SqlDataReader reader = db.command.ExecuteReader();

                if (reader.HasRows)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
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

            return flag;
        }

        public bool Login(SystemUser user)
        {
            bool flag = false;
            DBPlayer db = new DBPlayer();
            SessionManager session = new SessionManager();

            try
            {
                db.cmdText = "SELECT * FROM Users WHERE Email = @Email AND Password = @Password";

                db.command.Parameters.Add("Email", SqlDbType.NVarChar);
                db.command.Parameters["Email"].Value = user.Email;

                db.command.Parameters.Add("Password", SqlDbType.NVarChar);
                db.command.Parameters["Password"].Value = user.Password;

                db.Open();
                SqlDataReader reader = db.command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SystemUser userInfo = new SystemUser();
                        userInfo.UserId = int.Parse(reader["Id"].ToString());
                        userInfo.FullName = reader["FullName"].ToString();
                        userInfo.Email = reader["Email"].ToString();
                        userInfo.Status = Convert.ToBoolean(reader["Status"]);

                        session.ActiveUserId = userInfo.UserId;
                        session.Add("ActiveUser", userInfo);
                        break;
                    }

                    flag = true;
                }
                else
                {
                    flag = false;
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

            return flag;
        }

        public bool UpdateUser(SystemUser user)
        {
            bool flag = false;
            DBPlayer db = new DBPlayer();

            try
            {
                db.cmdText = "UPDATE Users SET FullName = @FullName, Email = @Email, Password = @Password, Status = @Status WHERE Id = @Id";

                db.command.Parameters.Add("FullName", SqlDbType.NVarChar);
                db.command.Parameters["FullName"].Value = user.FullName;

                db.command.Parameters.Add("Email", SqlDbType.NVarChar);
                db.command.Parameters["Email"].Value = user.Email;

                db.command.Parameters.Add("Password", SqlDbType.NVarChar);
                db.command.Parameters["Password"].Value = user.Password;

                db.command.Parameters.Add("Status", SqlDbType.Bit);
                db.command.Parameters["Status"].Value = user.Status;

                db.command.Parameters.Add("Id", SqlDbType.Int);
                db.command.Parameters["Id"].Value = user.UserId;

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

        public SystemUser GetUserById(int id)
        {
            SystemUser user = new SystemUser();
            DBPlayer db = new DBPlayer();

            try
            {
                db.cmdText = "SELECT * FROM Users WHERE Id = @Id";

                db.command.Parameters.Add("Id", SqlDbType.Int);
                db.command.Parameters["Id"].Value = id;

                db.Open();
                SqlDataReader reader = db.command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        user.UserId = int.Parse(reader["Id"].ToString());
                        user.FullName = reader["FullName"].ToString();
                        user.Email = reader["Email"].ToString();
                        //user.Password = reader["Password"].ToString();
                        user.Status = Convert.ToBoolean(reader["Status"].ToString());
                        break;
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

            return user;
        }

        public int GetUserIdByEmail(string email)
        {
            int userId = 0;
            DBPlayer db = new DBPlayer();

            try
            {
                db.cmdText = "SELECT * FROM Users WHERE Email = @Email";

                db.command.Parameters.Add("Email", SqlDbType.NVarChar);
                db.command.Parameters["Email"].Value = email;

                db.Open();
                SqlDataReader reader = db.command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        userId = int.Parse(reader["Id"].ToString());
                        break;
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

            return userId;
        }

        public bool DeleteUser(int userId)
        {
            bool flag = false;
            DBPlayer db = new DBPlayer();

            try
            {
                db.cmdText = "DELETE FROM Users WHERE Id = @Id";

                db.command.Parameters.Add("Id", SqlDbType.Int);
                db.command.Parameters["Id"].Value = userId;

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