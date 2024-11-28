using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using WebApiAssiment3.Entities;
using WebApiAssiment3.Interface;

namespace WebApiAssiment3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _studentService;
        public StudentController(IStudent studentService)
        {
            _studentService = studentService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStudent()
        {
            var stud = await _studentService.GetAllStudents();
            if (stud == null)
            {
                return NotFound();
            }
            return Ok(stud);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var obj = await _studentService.GetStudentById(id);
            return Ok(obj);
        }

        [HttpPost("AddStudent")]
        public async Task<IActionResult> AddStudent(Student student)
        {
           var obj=await _studentService.AddStudent(student);
            return Ok(obj);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, Student updateStudent)
        {
            if (id != updateStudent.StudentId)
            {
                return BadRequest("ID is mismatch");
            }
            var result = await _studentService.UpdateStudent(id, updateStudent);
            if (result == null)
            {
                return BadRequest("Id is not Found");
            }
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentbyId(int id)
        {
            var stud = await _studentService.DeleteStudentById(id);
            return Ok(stud);
        }

    }
}
