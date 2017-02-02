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
    public class ClassroomManager
    {
        public bool SaveDepartment(Classroom classroom)
        {
            ClassroomGetway classroomGetway = new ClassroomGetway();

            try
            {
                if (IsClassroomExist(classroom.RoomNo))
                {
                    throw new Exception("Classroom already exist.");
                }
                else
                {
                    return classroomGetway.SaveClassroom(classroom);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private bool IsClassroomExist(string roomNo)
        {
            try
            {
                ClassroomGetway classroomGetway = new ClassroomGetway();
                return classroomGetway.IsClassroomExist(roomNo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Classroom> GetAllClassroom()
        {
            try
            {
                ClassroomGetway classroomGetway = new ClassroomGetway();
                return classroomGetway.GetAllClassroom();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Classroom GetClassroomByRoomNo(string id)
        {
            try
            {
                ClassroomGetway classroomGetway = new ClassroomGetway();
                return classroomGetway.GetClassroomByRoomNo(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UpdateClassroom(Classroom classroom)
        {
            ClassroomGetway classroomGetway = new ClassroomGetway();

            try
            {
                if (IsClassroomExist(classroom.RoomNo))
                {
                    throw new Exception("Classroom already exist.");
                }
                else
                {
                    return classroomGetway.UpdateClassroom(classroom);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteClassroom(string roomNo)
        {
            try
            {
                ClassroomGetway classroomGetway = new ClassroomGetway();
                return classroomGetway.DeleteClassroom(roomNo);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}