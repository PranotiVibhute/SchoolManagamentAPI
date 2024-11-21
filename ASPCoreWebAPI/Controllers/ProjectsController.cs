using ASPCoreWebAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly EcommerceDbContext _dbContext;
        public ProjectsController(EcommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        //Get
        [HttpGet(Name ="Get Projects")]
        public IEnumerable<Project> Get()
        {
            return _dbContext.Projects.ToList();
        }


        [HttpGet("{id}")]
        public ActionResult<Project> Get(int id)
        {
            var Project = _dbContext.Projects.FirstOrDefault(p=>p.ProjectId == id);
            if(Project == null)
            {
                return NotFound("Project Not Found");
            }
            return Project;
        }


        //Post
        [HttpPost("PostProject")]
        public ActionResult<Project> PostProject([FromBody] Project project)
        {
            _dbContext.Projects.Add(project);
            _dbContext.SaveChanges();
            return Ok();
        }


        //Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var project = _dbContext.Projects.FirstOrDefault(p=>p.ProjectId==id);
            if(project == null)
            {
                return NotFound("Record Not Found");
            }
            _dbContext.Projects.Remove(project);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
