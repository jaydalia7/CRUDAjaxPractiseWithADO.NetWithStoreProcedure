using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRUDAjaxPractiseWithADO.NetWithStoreProcedure.Models
{
    public class EmployeeDB
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        public List<Employee> ListAll()
        {
            List<Employee> employeelst = new List<Employee>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand command = new SqlCommand("GetAllEmployee", con);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    employeelst.Add(new Employee
                    {
                        EmployeeId = Convert.ToInt32(reader["EmployeeId"]),
                        Name = reader["Name"].ToString(),
                        Age = Convert.ToInt32(reader["Age"]),
                        State = reader["State"].ToString(),
                        Country = reader["Country"].ToString()
                    });
                }
                return employeelst;
            }
        }
        public int Add(Employee employee)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand command = new SqlCommand("InsertUpdateEmployee", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", employee.EmployeeId);
                command.Parameters.AddWithValue("@Name", employee.Name);
                command.Parameters.AddWithValue("@Age", employee.Age);
                command.Parameters.AddWithValue("@State", employee.State);
                command.Parameters.AddWithValue("@Country", employee.Country);
                command.Parameters.AddWithValue("@Action", "Insert");
                i = command.ExecuteNonQuery();
            }
            return i;
        }
        //Method for Updating Employee record
        public int Update(Employee emp)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("InsertUpdateEmployee", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", emp.EmployeeId);
                com.Parameters.AddWithValue("@Name", emp.Name);
                com.Parameters.AddWithValue("@Age", emp.Age);
                com.Parameters.AddWithValue("@State", emp.State);
                com.Parameters.AddWithValue("@Country", emp.Country);
                com.Parameters.AddWithValue("@Action", "Update");
                i = com.ExecuteNonQuery();
            }
            return i;
        }
        //Method for Deleting an Employee
        public int Delete(int ID)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("DeleteEmployee", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", ID);
                i = com.ExecuteNonQuery();
            }
            return i;
        }
    }
}