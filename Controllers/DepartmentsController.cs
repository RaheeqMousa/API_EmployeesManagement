using API_EmployeesManagement.Data;
using API_EmployeesManagement.DTO;
using API_EmployeesManagement.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_EmployeesManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        ApplicationDBContext context = new ApplicationDBContext();

        [HttpGet("")]
        public IActionResult GetAll()
        {
            
            var departments = context.Departments.ToList();
            var depsDTO = departments.Adapt<List<DepartmentsDTO>>();
            
            return Ok(depsDTO);
        }

        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            Department dep = context.Departments.Find(id);
            return Ok(dep);
        }

        [HttpPost("create")]
        public IActionResult Create(CreateDepartmentDTO dep)
        {
            var department = dep.Adapt<Department>();

            context.Departments.Add(department);
            context.SaveChanges();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(Department dep, int id)
        {
            var department = context.Departments.Find(id);
            context.Departments.Update(dep);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var department = context.Departments.Find(id);
            context.Departments.Remove(department);
            context.SaveChanges();

            return Ok();
        }
    }
}
