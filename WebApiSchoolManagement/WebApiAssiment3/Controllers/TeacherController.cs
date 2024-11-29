using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiAssiment3.Entities;
using WebApiAssiment3.Interface;

namespace WebApiAssiment3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacher _teacherService;
        public TeacherController(ITeacher teacherService)
        {
            _teacherService = teacherService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTeacher()
        {
            var teacher = await _teacherService.GetAllTeachers();
            return Ok(teacher);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeacherById(int id)
        {
            var obj = await _teacherService.GetTeacherById(id);
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }
        [HttpPost("AddTeacher")]
        public async Task<IActionResult>AddTeacher(Teacher teacher)
        {
            var obj=await _teacherService.addTeacher(teacher);
            if (obj == null)
            {
                return BadRequest();
            }
            return Ok(obj);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeacher(int id, Teacher teacher)
        {
            if (id != teacher.TeacherId)
            {
                return BadRequest("Id is mismatch");
            }
            var obj = await _teacherService.UpdateTeacher(id, teacher);
            if (obj == null)
                return NotFound("Id is not Found");
            return Ok(obj);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteById(int id)
        {
            var obj=await _teacherService.removeTeacher(id);
            return Ok(obj);
        }
    }
}
