using Cau1.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau1.DAL
{
    public class Employee_2119110227_DAL : DBConnection
    {
        public List<Employee_2119110227_DAL> ReadCustomer()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Employee_2119110227", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<Employee_2119110227> lstEmployee = new List<Employee_2119110227>();
            Employee_2119110227_DAL employee = new Employee_2119110227_DAL();
            Department_2119110227_DAL department = new Department_2119110227_DAL();
            while (reader.Read())
            {
                Employee_2119110227 Emp = new Employee_2119110227();
                Emp.IdEmployee = int.Parse(reader["IdEmployee"].ToString());
                Emp.Name = reader["Name"].ToString();
                Emp.DateBirth = DateTime.Parse(reader["DateBirth"].ToString());
                Emp.Gender = char.Parse(reader["Gender"].ToString());
                Emp.PlaceBirth = reader["PlaceBirth"].ToString();
                Emp.Department = department.ReadArea(int.Parse(reader["IdDepartment"].ToString()));
                lstEmployee.Add(Emp);

            }
            conn.Close();
            return lstEmployee;
        }

    }
}
