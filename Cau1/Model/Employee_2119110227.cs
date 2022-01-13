using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau1.Model
{
    public class Employee_2119110227
    {
        public string IdEmployee { set; get; }
        public String Name { set; get; }
        public DateTime DateBirth { set; get; }
        public string Gender { set; get; }
        public String PlaceBirth { set; get; }
        public Department_2119110227 Department { get; set; }

        public String Depart
        {
            get
            {
                return Department.Name_Department;
            }
        }
    }
}
