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
    public class DepartmentManager
    {
        public bool SaveDepartment(Department department)
        {
            DepartmentGetway departmentGetway = new DepartmentGetway();

            try
            {
                if (IsValidDeptCode(department.Code))
                {
                    throw new Exception("Department code already exist.");
                }
                else
                {
                    if (IsValidDeptName(department.Name))
                    {
                        throw new Exception("Department name already exist.");
                    }
                    else
                    {
                        return departmentGetway.SaveDepartment(department);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private bool IsValidDeptCode(string deptCode)
        {
            try
            {
                DepartmentGetway departmentGetway = new DepartmentGetway();
                return departmentGetway.IsValidDeptCode(deptCode);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private bool IsValidDeptName(string deptName)
        {
            try
            {
                DepartmentGetway departmentGetway = new DepartmentGetway();
                return departmentGetway.IsValidDeptName(deptName);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Department> GetAllDepartment()
        {
            try
            {
                DepartmentGetway departmentGetway = new DepartmentGetway();
                return departmentGetway.GetAllDepartment();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Department GetDepartmentById(int id)
        {
            try
            {
                DepartmentGetway departmentGetway = new DepartmentGetway();
                return departmentGetway.GetDepartmentById(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UpdateDepartment(Department dept)
        {
            try
            {
                DepartmentGetway departmentGetway = new DepartmentGetway();
                return departmentGetway.UpdateDepartment(dept);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteDepartment(int id)
        {
            try
            {
                DepartmentGetway departmentGetway = new DepartmentGetway();
                return departmentGetway.DeleteDepartment(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}