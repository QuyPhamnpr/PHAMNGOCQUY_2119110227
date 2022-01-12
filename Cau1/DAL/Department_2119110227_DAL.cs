using Cau1.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau1.dal
{
    public class Department_2119110227_DAL : DBConnection
    {
        public List<Department_2119110227> ReadAreaList()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Department_2119110227", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<Department_2119110227> lstDepartment = new List<Department_2119110227>();
            while (reader.Read())
            {
                Department_2119110227 Depart = new Department_2119110227();
                Depart.IdDepartment = int.Parse(reader["IdDepartment"].ToString());
                Depart.Name_Department = reader["name_department"].ToString();
                lstDepartment.Add(Depart);
            }
            conn.Close();
            return lstDepartment;
        }
        public Department_2119110227 ReadArea(int id)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(
                "select * from Department_2119110227 where IdDepartment=" + id.ToString(), conn);
            Department_2119110227 Department = new Department_2119110227();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows && reader.Read())
            {
                Department.IdDepartment = int.Parse(reader["IdDepartment"].ToString());
                Department.Name_Department = reader["name_department"].ToString();
            }
            conn.Close();
            return Department;
        }
    }
}
