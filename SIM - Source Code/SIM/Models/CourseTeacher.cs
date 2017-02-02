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
    public class CourseTeacher
    {
        public string EDepartmentId { get; set; }
        public int DepartmentId { get; set; }
        public string ETeacherId { get; set; }
        public int TeacherId { get; set; }
        public string ECourseId { get; set; }
        public int CourseId { get; set; }
        public bool CourseAssignStatus { get; set; }

        public int CourseCredit { get; set; }

        public string EId { get; set; }
        public int Id { get; set; }
        public string ECourseCode { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string TeacherName { get; set; }
        public string TeacherDesignation { get; set; }
        public int TeacherCreditToBeTaken { get; set; }
        public int TeacherRemainingCredit { get; set; }
        public string DepartmentName { get; set; }
        public string Status { get; set; }
    }
}