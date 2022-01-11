using Cau1.DAL;
using Cau1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau1.BAL
{
    public class Department_2119110227_BAL
    {
        Department_2119110227_DAL dal = new Department_2119110227_DAL();
        public List<Department_2119110227> ReadAreaList()
        {
            List<Department_2119110227> lstDepart = dal.ReadAreaList();
            return lstDepart;
        }
}
}
