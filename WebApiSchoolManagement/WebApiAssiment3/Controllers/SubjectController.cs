using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAssiment3.Context;
using WebApiAssiment3.Entities;
using WebApiAssiment3.Interface;
using WebApiAssiment3.Service;

namespace WebApiAssiment3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubject _subjectService;

        public SubjectController(ISubject subjectService)
        {
            _subjectService = subjectService;
        }
        [HttpGet]
        public async Task<IActionResult>GerAllSubject()
        {
            var sub = await _subjectService.GetAllSubjects();
            if (sub != null)
            {
                return Ok(sub);
            }
            return NotFound();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubjectById(int id)
        {
            var obj = await _subjectService.GetSubjectById(id);
            if (obj != null)
            {
                return Ok(obj);
            }
            return NotFound();
        }
        [HttpPost("Addsubject")]
        public async Task<IActionResult> AddSubject(Subject subject)
        {
            var obj = await _subjectService.AddSubject(subject);
            return Ok(obj);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubject(int id, Subject updatedSubject)
        {
            if (id != updatedSubject.SubjectId)
            {
                return BadRequest("Id is Mismatch");
            }
            var updatedResult = await _subjectService.UpdateSubject(id,updatedSubject);
            if (updatedResult == null)
            {
                return NotFound($"Subject With {id} Not found or failed");
            }
            return Ok(updatedResult);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubjectBYid(int id)
        {
            var obj = await _subjectService.DeleteSubject(id);
            //if (obj == null)
            //{
            //    return NotFound();
            //}
            return Ok(obj);
        }
    }
}
