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
    public class Student
    {
        public string EId { get; set; }
        public int Id { get; set; }
        public string ERegNo { get; set; }
        public string RegNo { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string EDate { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; }
        public string EDepartmentId { get; set; }
        public int DepartmentId { get; set; }

        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }

        public string ECourseId { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }

        public string EGrade { get; set; }
        public string Grade { get; set; }

        public string EStudentId { get; set; }
        public int StudentId { get; set; }
        public string EStatus { get; set; }
        public bool Status { get; set; }
    }
}