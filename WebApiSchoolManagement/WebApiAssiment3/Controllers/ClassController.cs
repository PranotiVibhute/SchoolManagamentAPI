using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiAssiment3.Entities;
using WebApiAssiment3.Interface;

namespace WebApiAssiment3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClass _classService;

        public ClassController(IClass classService)
        {
            _classService = classService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllClasses()
        {
            var cls= await _classService.GetAllClasses();
            if (cls == null)
            {
                return NotFound();
            }
            return Ok(cls);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClassById(int id)
        {
            var obj = await _classService.GetClassById(id);
            return Ok(obj);
        }
        [HttpPost("AddClass")]
        public async Task<IActionResult> AddClass(Class @class)
        {
            var obj = await _classService.AddClass(@class);
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var obj = await _classService.DeleteByid(id);
            return Ok(obj);
        }
    }
}
