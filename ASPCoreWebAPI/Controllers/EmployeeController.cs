using ASPCoreWebAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EcommerceDbContext _dbContext;

        public EmployeeController(EcommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Get
        [HttpGet(Name = "GetEmployees")]
        public IEnumerable<Employee> Get()
        {
            return _dbContext.Employees.ToList();
        }

    

        [HttpGet("{id}")]
       public ActionResult<Employee> Get(int id)
       {
            var Employee = _dbContext.Employees.FirstOrDefault(e => e.EmployeeId == id);
            if (Employee == null)
            {
                return NotFound("Employee Not Found");
            }
            return Employee;
       }

       //Post
       [HttpPost("PostEmployee")]
        public ActionResult<Employee> PostEmployee([FromBody] Employee employee)
        {
            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();
            return Ok();
        }

        //Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Employee = _dbContext.Employees.FirstOrDefault(e => e.EmployeeId == id);
            if (Employee == null)
            {
                return NotFound("Record Not Found");
            }

            _dbContext.Employees.Remove(Employee);
            _dbContext.SaveChanges();
            return Ok();
        }

        //Put
        [HttpPut("{id}")]
        public async Task<ActionResult> updateEmployee(int id, Employee emp)
        {
            if (id != emp.EmployeeId)
                return BadRequest("Employee Id is MisMatch");

            var Employee = await _dbContext.Employees.FindAsync(id);
            if(Employee==null)
            {
                return NotFound("Record Not Found");
            }

            Employee.EmployeeName = emp.EmployeeName;
            Employee.ManagerId = emp.ManagerId;
            Employee.DepartmentId=emp.DepartmentId;
            Employee.ProjectId = emp.ProjectId;

            await _dbContext.SaveChangesAsync();

            return Ok("SuccessFully Update");
        }


        //Patch
        [HttpPatch("{id}")]
        public async Task<IActionResult> PartialUpdateEmployee(int id, [FromBody] JsonPatchDocument<Employee> emp)
        {
            if (emp == null)
                return BadRequest("Emp id can Not be Null");

            var Employee = await _dbContext.Employees.FindAsync(id);
            if(Employee == null)
            {
                return NotFound("Record Not Found");
            }

           emp.ApplyTo(Employee);

            await _dbContext.SaveChangesAsync();

            return Ok("SuccessFully Update");

        }
    }
}
