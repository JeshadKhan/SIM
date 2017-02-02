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
    public class ClassroomGetway
    {
        public bool SaveClassroom(Classroom classroom)
        {
            bool flag = false;
            DBPlayer db = new DBPlayer();

            try
            {
                db.cmdText = "INSERT INTO RoomNo(RoomNo) VALUES(@RoomNo)";

                db.command.Parameters.Add("RoomNo", SqlDbType.VarChar);
                db.command.Parameters["RoomNo"].Value = classroom.RoomNo;

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

        public bool IsClassroomExist(string roomNo)
        {
            bool flag = false;
            DBPlayer db = new DBPlayer();

            try
            {
                db.cmdText = "SELECT RoomNo FROM RoomNo WHERE RoomNo = @RoomNo";

                db.command.Parameters.Add("RoomNo", SqlDbType.VarChar);
                db.command.Parameters["RoomNo"].Value = roomNo;

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

        public List<Classroom> GetAllClassroom()
        {
            List<Classroom> listOfClassroom = new List<Classroom>();
            DBPlayer db = new DBPlayer();

            try
            {
                db.cmdText = "SELECT * FROM RoomNo";

                db.Open();
                SqlDataReader reader = db.command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Classroom classroom = new Classroom();
                        classroom.RoomNo = reader["RoomNo"].ToString();
                        listOfClassroom.Add(classroom);
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

            return listOfClassroom;
        }

        public Classroom GetClassroomByRoomNo(string id)
        {
            Classroom classroom = new Classroom();
            DBPlayer db = new DBPlayer();

            try
            {
                db.cmdText = "SELECT * FROM RoomNo WHERE RoomNo = @RoomNo";

                db.command.Parameters.Add("RoomNo", SqlDbType.VarChar);
                db.command.Parameters["RoomNo"].Value = id;

                db.Open();
                SqlDataReader reader = db.command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        classroom.RoomNo = reader["RoomNo"].ToString();
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

            return classroom;
        }

        public bool UpdateClassroom(Classroom classroom)
        {
            bool flag = false;
            DBPlayer db = new DBPlayer();

            try
            {
                db.cmdText = "UPDATE RoomNo SET RoomNo = @RoomNo WHERE RoomNo = @Id";

                db.command.Parameters.Add("RoomNo", SqlDbType.NVarChar);
                db.command.Parameters["RoomNo"].Value = classroom.RoomNo;

                db.command.Parameters.Add("Id", SqlDbType.NVarChar);
                db.command.Parameters["Id"].Value = classroom.Id;

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

        public bool DeleteClassroom(string roomNo)
        {
            bool flag = false;
            DBPlayer db = new DBPlayer();

            try
            {
                db.cmdText = "DELETE FROM RoomNo WHERE RoomNo = @RoomNo";

                db.command.Parameters.Add("RoomNo", SqlDbType.NVarChar);
                db.command.Parameters["RoomNo"].Value = roomNo;

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