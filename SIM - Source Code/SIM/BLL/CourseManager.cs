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
    public class CourseManager
    {
        public bool SaveCourse(Course course)
        {
            try
            {
                CourseGetway courseGetway = new CourseGetway();

                if (IsValidCourseCode(course.Code))
                {
                    throw new Exception("Course code already exist.");
                }
                else
                {
                    if (IsValidCourseName(course.Name))
                    {
                        throw new Exception("Course name already exist.");
                    }
                    else
                    {
                        return courseGetway.SaveCourse(course);
                    }
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private bool IsValidCourseCode(string courseCode)
        {
            try
            {
                CourseGetway courseGetway = new CourseGetway();
                return courseGetway.IsValidCourseCode(courseCode);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private bool IsValidCourseName(string courseName)
        {
            try
            {
                CourseGetway courseGetway = new CourseGetway();
                return courseGetway.IsValidCourseName(courseName);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public List<Course> GetAllCourse()
        {
            try
            {
                CourseGetway courseGetway = new CourseGetway();
                return courseGetway.GetAllCourse();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Course GetCourseById(int id)
        {
            try
            {
                CourseGetway courseGetway = new CourseGetway();
                return courseGetway.GetCourseById(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UpdateCourse(Course course)
        {
            try
            {
                CourseGetway courseGetway = new CourseGetway();
                return courseGetway.UpdateCourse(course);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteCourse(int id)
        {
            try
            {
                CourseGetway courseGetway = new CourseGetway();
                return courseGetway.DeleteCourse(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool AssignCourseTeacher(CourseTeacher courseTeacher)
        {
            try
            {
                if (IsCourseTeacherPairExist(courseTeacher))
                {
                    throw new Exception("This course already assigned to this teacher.");
                }
                else
                {
                    if (IsCourseAssign(courseTeacher.CourseId))
                    {
                        throw new Exception("Course already assigned.");
                    }
                    else
                    {
                        CourseGetway courseGetway = new CourseGetway();
                        return courseGetway.AssignCourseTeacher(courseTeacher);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private bool IsCourseAssign(int courseId)
        {
            try
            {
                CourseGetway courseGetway = new CourseGetway();
                return courseGetway.IsCourseAssign(courseId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool IsCourseTeacherPairExist(CourseTeacher courseTeacher)
        {
            try
            {
                CourseGetway courseGetway = new CourseGetway();
                return courseGetway.IsCourseTeacherPairExist(courseTeacher);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<CourseTeacher> GetAllCourseCourseTeacher()
        {
            try
            {
                CourseGetway courseGetway = new CourseGetway();
                return courseGetway.GetAllCourseCourseTeacher();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public CourseTeacher GetCourseCourseTeacherById(int id, int cid, int tid)
        {
            try
            {
                CourseGetway courseGetway = new CourseGetway();
                return courseGetway.GetCourseCourseTeacherById(id, cid, tid);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UpdateCourseTeacher(CourseTeacher courseTeacher)
        {
            try
            {
                CourseGetway courseGetway = new CourseGetway();
                return courseGetway.UpdateCourseTeacher(courseTeacher);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteCourseTeacher(int id, int cid, int tid)
        {
            try
            {
                CourseGetway courseGetway = new CourseGetway();
                return courseGetway.DeleteCourseTeacher(id, cid, tid);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<CourseTeacherSemestersView> GetCourseTeacherSemesters()
        {
            try
            {
                CourseGetway courseGetway = new CourseGetway();
                return courseGetway.GetCourseTeacherSemesters();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UnassignCourses()
        {
            try
            {
                CourseGetway courseGetway = new CourseGetway();
                return courseGetway.UnassignCourses();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}