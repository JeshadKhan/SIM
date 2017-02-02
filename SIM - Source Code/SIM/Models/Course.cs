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
    public class Course
    {
        public string EId { get; set; }
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public float Credit { get; set; }
        public string Description { get; set; }
        public string EDepartmentId { get; set; }
        public int DepartmentId { get; set; }
        public string ESemesterId { get; set; }
        public int SemesterId { get; set; }
    }
}