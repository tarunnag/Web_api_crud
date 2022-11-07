using Api_WebApplication1_Services_Class.Model;
using Api_WebApplication1_Services_Class.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Api_WebApplication1_Services_Class.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class Employee_Controllers : ControllerBase
    {
        public IConfiguration _configuration { get; }
        SqlConnection con;
        Employee_Services Service;
        public Employee_Controllers(IConfiguration configuration)
        {
            _configuration = configuration;
            con = new SqlConnection(_configuration.GetConnectionString("Database"));
            Service = new Employee_Services(con);
        }
        [HttpGet]
        public JsonResult GetAllEmployee()
        {
            try
            {
                return new JsonResult(Service.GetAll());
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }
        [HttpPost]
        public Boolean AddEmployee(Employee_Class employee)
        {
            try
            {
                new JsonResult(Service.AddMethod(employee));
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        [HttpPut]
        public Boolean UpdateEmployee(int EmpId, Employee_Class employee)
        {
            try
            {
               new JsonResult(Service.UpdateMethod(EmpId, employee));
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        [HttpDelete]
        public Boolean DeleteEmployee(int EmpId)
        {
            try
            {
                Service.DeleteMethod(EmpId);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
