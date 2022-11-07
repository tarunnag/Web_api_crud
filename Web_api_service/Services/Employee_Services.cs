using Api_WebApplication1_Services_Class.Model;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace Api_WebApplication1_Services_Class.Services
{
    public class Employee_Services
    {
        SqlConnection con;
        public Employee_Services(SqlConnection sqlConnection)
        {
         con = sqlConnection;
        }
        public IList<Employee_Class> GetAll()
        {
            List<Employee_Class> employees = new List<Employee_Class>();
            try
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Employee";
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    employees.Add(new Employee_Class
                    {
                        Id = Convert.ToInt32(sdr["EmpId"]),
                        Name = Convert.ToString(sdr["EmpName"]),
                        EmailId = Convert.ToString(sdr["EmailId"])
                    });
                }
            }
            finally
            {
                con.Close();
            }
            return employees;
        }
        public Boolean AddMethod(Employee_Class employee)
        {
            try
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Insert into Employee(Empid,EmpName,EmailId) values(" + employee.Id + ",'" + employee.Name + "','" + employee.EmailId + ""; ;
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public Boolean UpdateMethod(int EmpId, Employee_Class employee)
        {
            try
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update Employee Set EmpName='" + employee.Name + "',EmailId= '" + employee.EmailId + "' Where(EmpId= " + EmpId + ");";
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public Boolean DeleteMethod(int EmpId)
        {
            try
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Delete from Employee Where(EmpId=" + EmpId + ");";
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                con.Close();
            }


        }
    }
                  
}
