﻿using Cau1.dal;
using Cau1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau1.BAL
{
    public class Employee_2119110227_BAL
    {
        Employee_2119110227_DAL dal = new Employee_2119110227_DAL();
        public List<Employee_2119110227> ReadCustomer()
        {
            List<Employee_2119110227> lstEmpl = dal.ReadCustomer();
            return lstEmpl;
        }
        public void ThemEmployee(Employee_2119110227 emp)
        {
            dal.ThemEmployee(emp);
        }
        public void XoaEmployee(Employee_2119110227 emp)
        {
            dal.XoaEmployee(emp);
        }
        public void SuaEmployee(Employee_2119110227 emp)
        {
            dal.SuaEmployee(emp);
        }
    }
}
