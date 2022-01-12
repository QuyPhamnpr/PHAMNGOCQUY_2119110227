using Cau1.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau1.dal
{
    public class Employee_2119110227_DAL : DBConnection
    {
        public List<Employee_2119110227> ReadCustomer()
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
                Emp.IdEmployee = reader["IdEmployee"].ToString();
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
        public void ThemEmployee(Employee_2119110227 emp)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into Employee_2119110227 values (@IdEmployee, @name, @datebirth, @Gender, @PlaceBirth,@IdDepartment)", conn);
            cmd.Parameters.Add(new SqlParameter("@IdEmployee", emp.IdEmployee));
            cmd.Parameters.Add(new SqlParameter("@Name", emp.Name));
            cmd.Parameters.Add(new SqlParameter("@DateBirth", emp.DateBirth));
            cmd.Parameters.Add(new SqlParameter("@Gender", emp.Gender));
            cmd.Parameters.Add(new SqlParameter("@PlaceBirth", emp.PlaceBirth));
            cmd.Parameters.Add(new SqlParameter("@IdDepartment", emp.Department.IdDepartment));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void XoaEmployee(Employee_2119110227 emp)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from Employee_2119110227 where IdEmployee=@IdEmployee", conn);
            cmd.Parameters.Add(new SqlParameter("@IdEmployee", emp.IdEmployee));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void SuaEmployee(Employee_2119110227 emp)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("update Employee_2119110227 set name = @name, DateBirth= @DateBirth, Gender= @Gender,PlaceBirth= @PlaceBirth,IdDepartment= @IdDepartment where IdEmployee = @IdEmployee", conn);
            cmd.Parameters.Add(new SqlParameter("@IdEmployee", emp.IdEmployee));
            cmd.Parameters.Add(new SqlParameter("@Name", emp.Name));
            cmd.Parameters.Add(new SqlParameter("@DateBirth", emp.DateBirth));
            cmd.Parameters.Add(new SqlParameter("@Gender", emp.Gender));
            cmd.Parameters.Add(new SqlParameter("@PlaceBirth", emp.PlaceBirth));
            cmd.Parameters.Add(new SqlParameter("@IdDepartment", emp.Department.IdDepartment));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
