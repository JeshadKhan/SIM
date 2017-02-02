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
    public class AllocateClassroom
    {
        public string EId { get; set; }
        public int Id { get; set; }
        public string EDepartmentId { get; set; }
        public int DepartmentId { get; set; }
        public string ECourseId { get; set; }
        public int CourseId { get; set; }
        public string ERoomNo { get; set; }
        public string RoomNo { get; set; }
        public string EDay { get; set; }
        public string Day { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime AllocationDate { get; set; }

        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string ScheduleInfo { get; set; }

        public string DepartmentName { get; set; }
        public string Time { get; set; }
        public string TimeDuration { get; set; }
        public bool StatusFlag { get; set; }
        public string Status { get; set; }
    }
}