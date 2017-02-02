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
    public class TeacherManager
    {
        public List<Designation> GetAllDesignation()
        {
            try
            {
                TeacherGetway teacherGetway = new TeacherGetway();
                return teacherGetway.GetAllDesignation();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool SaveTeacher(Teacher teacher)
        {
            try
            {
                if (IsTeacherExist(teacher.Email))
                {
                    throw new Exception("Teacher already exist.");
                }
                else
                {
                    TeacherGetway teacherGetway = new TeacherGetway();
                    return teacherGetway.SaveTeacher(teacher);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private bool IsTeacherExist(string teacherEmail)
        {
            try
            {
                TeacherGetway teacherGetway = new TeacherGetway();
                return teacherGetway.IsTeacherExist(teacherEmail);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Teacher> GetAllTeacher()
        {
            try
            {
                TeacherGetway teacherGetway = new TeacherGetway();
                return teacherGetway.GetAllTeacher();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Teacher GetTeacherById(int id)
        {
            try
            {
                TeacherGetway teacherGetway = new TeacherGetway();
                return teacherGetway.GetTeacherById(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UpdateTeacher(Teacher teacher)
        {
            try
            {
                TeacherGetway teacherGetway = new TeacherGetway();
                return teacherGetway.UpdateTeacher(teacher);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteTeacher(int id)
        {
            try
            {
                TeacherGetway teacherGetway = new TeacherGetway();
                return teacherGetway.DeleteTeacher(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}