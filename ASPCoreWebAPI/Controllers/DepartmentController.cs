using ASPCoreWebAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly EcommerceDbContext _dbContext;

        public DepartmentController(EcommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        //Get
        [HttpGet(Name = "GetDepartments")]
        public IEnumerable<Department> Get()
        {
            return _dbContext.Departments.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Department> Get(int id)
        {
            var Department = _dbContext.Departments.FirstOrDefault(d => d.DepartmentId == id);
            if (Department == null)
            {
                return NotFound("Department Not Found");
            }
            return Department;
        }


        //Post
        [HttpPost("PostDepartment")]
        public ActionResult<Department> PostDepartment([FromBody] Department department)
        {
            _dbContext.Departments.Add(department);
            _dbContext.SaveChanges();
            return Ok();
        }


        //Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Department = _dbContext.Departments.FirstOrDefault(d => d.DepartmentId == id);
            if (Department == null)
            {
                return NotFound("Record Not Found");
            }

            _dbContext.Departments.Remove(Department);
            _dbContext.SaveChanges();
            return Ok();

        }

        //put
        [HttpPut("{id}")]
        public async Task<ActionResult> updateDepartment(int id,Department department)
        {
            if (id != department.DepartmentId)
                return BadRequest("Department Id Mismatch");

            var Department = await _dbContext.Departments.FindAsync(id);

            if(Department==null)
            {
                return NotFound("Record Not Found");
            }

            Department.DepartmentName = department.DepartmentName;

            await _dbContext.SaveChangesAsync();

            return Ok("Update SuccessFully");
        }

        //Patch
        [HttpPatch("{id}")]
        public async Task<IActionResult> PartitalUpdateDepartment(int id, [FromBody] JsonPatchDocument<Department> department)
        {
            if (department == null)
                return BadRequest("department can not be Null");

            var Department = await _dbContext.Departments.FindAsync(id);
            if(Department == null)
            {
                return NotFound("Record Not Found");
            }

           department.ApplyTo(Department);

            await _dbContext.SaveChangesAsync();

            return Ok("Update SuccessFully");
        }
    }
}