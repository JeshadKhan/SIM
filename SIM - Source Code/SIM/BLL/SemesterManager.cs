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
    public class SemesterManager
    {
        public List<Semester> GetAllSemester()
        {
            try
            {
                SemesterGetway semesterGetway = new SemesterGetway();
                return semesterGetway.GetAllSemester();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}