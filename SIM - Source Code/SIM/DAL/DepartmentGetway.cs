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
    public class DepartmentGetway
    {
        public bool SaveDepartment(Department department)
        {
            bool flag = false;
            DBPlayer db = new DBPlayer();

            try
            {
                db.cmdText = "INSERT INTO Departments(Code, Name) VALUES(@Code, @Name)";

                db.command.Parameters.Add("Code", SqlDbType.VarChar);
                db.command.Parameters["Code"].Value = department.Code;

                db.command.Parameters.Add("Name", SqlDbType.VarChar);
                db.command.Parameters["Name"].Value = department.Name;

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

        public bool IsValidDeptCode(string deptCode)
        {
            bool flag = false;
            DBPlayer db = new DBPlayer();

            try
            {
                db.cmdText = "SELECT Code FROM Departments WHERE Code = @Code";

                db.command.Parameters.Add("Code", SqlDbType.VarChar);
                db.command.Parameters["Code"].Value = deptCode;

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

        public bool IsValidDeptName(string deptName)
        {
            bool flag = false;
            DBPlayer db = new DBPlayer();

            try
            {
                db.cmdText = "SELECT Name FROM Departments WHERE Name = @Name";

                db.command.Parameters.Add("Name", SqlDbType.VarChar);
                db.command.Parameters["Name"].Value = deptName;

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

        public List<Department> GetAllDepartment()
        {
            List<Department> listOfDepartment = new List<Department>();
            DBPlayer db = new DBPlayer();

            try
            {
                db.cmdText = "SELECT * FROM Departments";

                db.Open();
                SqlDataReader reader = db.command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Department dept = new Department();
                        dept.Id = int.Parse(reader["Id"].ToString());
                        dept.Code = reader["Code"].ToString();
                        dept.Name = reader["Name"].ToString();
                        listOfDepartment.Add(dept);
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

            return listOfDepartment;
        }

        public Department GetDepartmentById(int id)
        {
            Department dept = new Department();
            DBPlayer db = new DBPlayer();

            try
            {
                db.cmdText = "SELECT * FROM Departments WHERE Id = @Id";

                db.command.Parameters.Add("Id", SqlDbType.Int);
                db.command.Parameters["Id"].Value = id;

                db.Open();
                SqlDataReader reader = db.command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dept.Id = int.Parse(reader["Id"].ToString());
                        dept.Code = reader["Code"].ToString();
                        dept.Name = reader["Name"].ToString();
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

            return dept;
        }

        public bool UpdateDepartment(Department dept)
        {
            bool flag = false;
            DBPlayer db = new DBPlayer();

            try
            {
                db.cmdText = "UPDATE Departments SET Code = @Code, Name = @Name WHERE Id = @Id";

                db.command.Parameters.Add("Code", SqlDbType.NVarChar);
                db.command.Parameters["Code"].Value = dept.Code;

                db.command.Parameters.Add("Name", SqlDbType.NVarChar);
                db.command.Parameters["Name"].Value = dept.Name;

                db.command.Parameters.Add("Id", SqlDbType.Int);
                db.command.Parameters["Id"].Value = dept.Id;

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

        public bool DeleteDepartment(int id)
        {
            bool flag = false;
            DBPlayer db = new DBPlayer();

            try
            {
                db.cmdText = "DELETE FROM Departments WHERE Id = @Id";

                db.command.Parameters.Add("Id", SqlDbType.NVarChar);
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