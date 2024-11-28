using Asp.NetFirstCodeEF.Entities;
using Asp.NetFirstCodeEF.Interface;
using Asp.NetFirstCodeEF.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetFirstCodeEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _employeeService;
        public EmployeeController(IEmployee employeeservice)
        {
            _employeeService = employeeservice;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var employees = await _employeeService.GetAllEmployee();//employees=variable
            if (employees == null)
            {
                return NotFound();
            }
            return Ok(employees);
        }
        [HttpGet]
        [Route("[action]/id")]
        public async Task<IActionResult> GetEmployeesById(int id)
        {
            try
            {
                var employees = await _employeeService.GetEmployeesByID(id);
                if (employees == null) return NotFound();
                return Ok(employees);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SaveEmployees(Employee employeeModel)
        {
            try
            {
                var model =  await _employeeService.AddEmployee(employeeModel);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        [Route("[action]/id")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                var model = await _employeeService.DeleteEmployeByID(id);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
