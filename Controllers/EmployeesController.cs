using API_EmployeesManagement.Models;
using API_EmployeesManagement.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_EmployeesManagement.DTO;
using Mapster;

namespace API_EmployeesManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        ApplicationDBContext context= new ApplicationDBContext();

        [HttpGet("")]
        public IActionResult GetAll() {

            var employees = context.Employees.ToList();
            var empDTO = employees.Adapt<List<EmployeesDTO>>();
            return Ok(empDTO);
        }

        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            Employee employee = context.Employees.Find(id);
            return Ok(employee);
        }

        [HttpPost("create")]
        public IActionResult Create(CreateEmployeeDTO emp)
        {
            ////manual mapping
            //var employee = new Employee
            //{
            //    Name = emp.Name,
            //    DOB = emp.DOB,
            //    Image = emp.Image,
            //    Status = emp.Status,
            //    Email = emp.Email,
            //    Phone = emp.Phone,
            //};

            var employee = emp.Adapt<Employee>();

            context.Employees.Add(employee);
            context.SaveChanges();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(Employee emp,int id)
        {
            var employee = context.Employees.Find(id);
            context.Employees.Update(employee);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var employee=context.Employees.Find(id);
            context.Employees.Remove(employee);
            context.SaveChanges();

            return Ok();
        }


    }
}
