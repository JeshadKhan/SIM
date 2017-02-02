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
    public class AllocateClassroomManager
    {
        public bool Save(AllocateClassroom allocateClassroom)
        {
            try
            {
                if (IsOverlapping(allocateClassroom))
                {
                    throw new Exception("Schedule already exist.");
                }
                else
                {
                    AllocateClassroomGetway allocateClassroomGetway = new AllocateClassroomGetway();
                    return allocateClassroomGetway.Save(allocateClassroom);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private bool IsOverlapping(AllocateClassroom allocateClassroom)
        {
            try
            {
                AllocateClassroomGetway allocateClassroomGetway = new AllocateClassroomGetway();
                return allocateClassroomGetway.IsOverlapping(allocateClassroom);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<AllocateClassroom> GetAllAllocateClassroom()
        {
            try
            {
                AllocateClassroomGetway allocateClassroomGetway = new AllocateClassroomGetway();
                return allocateClassroomGetway.GetAllAllocateClassroom();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool IsScheduleExist(AllocateClassroom allocateClassroom)
        {
            try
            {
                AllocateClassroomGetway allocateClassroomGetway = new AllocateClassroomGetway();
                return allocateClassroomGetway.IsScheduleExist(allocateClassroom);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<AllocateClassroom> GetAllAllocateClassroomList()
        {
            try
            {
                AllocateClassroomGetway allocateClassroomGetway = new AllocateClassroomGetway();
                return allocateClassroomGetway.GetAllAllocateClassroomList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public AllocateClassroom GetAllAllocateClassroomById(int id, int did, int cid)
        {
            try
            {
                AllocateClassroomGetway allocateClassroomGetway = new AllocateClassroomGetway();
                return allocateClassroomGetway.GetAllAllocateClassroomById(id, did, cid);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UpdateAllocateClassroom(AllocateClassroom allocateClassroom)
        {
            try
            {
                AllocateClassroomGetway allocateClassroomGetway = new AllocateClassroomGetway();
                return allocateClassroomGetway.UpdateAllocateClassroom(allocateClassroom);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteAllocateClassroom(int id, int did, int cid)
        {
            try
            {
                AllocateClassroomGetway allocateClassroomGetway = new AllocateClassroomGetway();
                return allocateClassroomGetway.DeleteAllocateClassroom(id, did, cid);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UnallocateAllClassroom()
        {
            try
            {
                AllocateClassroomGetway allocateClassroomGetway = new AllocateClassroomGetway();
                return allocateClassroomGetway.UnallocateAllClassroom();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}