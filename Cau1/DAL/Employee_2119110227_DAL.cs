using Cau1.Model;
using System;
using System.Collections.Generic;
using System.Data;
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
            SqlCommand cmd = new SqlCommand("selectEmployee_2119110227", conn);
            cmd.CommandType = CommandType.StoredProcedure;
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
                Emp.Gender = reader["Gender"].ToString();
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

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "ThemEployee_2119110227";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;
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
            SqlConnection con = new SqlConnection();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "XoaEployee_2119110227";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.Add("@IdEmployee", SqlDbType.Int).Value = 1;
                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();

                Console.WriteLine("Xoa thanh cong !!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Co loi xay ra !!!" + e);
            }
            finally
            {
                con.Close();
            }
        }
        public void SuaEmployee(Employee_2119110227 emp)
        {
            SqlConnection con = new SqlConnection();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SuaEployee_2119110227";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                cmd.Parameters.Add("@IdEmployee", SqlDbType.Int).Value = emp.IdEmployee;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = emp.Name;
                cmd.Parameters.Add("@DateBirth", SqlDbType.Date).Value = emp.DateBirth;
                cmd.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = emp.Gender;
                cmd.Parameters.Add("@PlaceBirth", SqlDbType.NVarChar).Value = emp.PlaceBirth;
                cmd.Parameters.Add("@IdDepartment", SqlDbType.Int).Value = emp.Department.IdDepartment;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                Console.WriteLine("Sua thanh cong !!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Co loi xay ra !!!" + e);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
