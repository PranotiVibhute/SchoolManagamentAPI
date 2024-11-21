using Microsoft.AspNetCore.JsonPatch;
using ASPCoreWebAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly EcommerceDbContext _dbContext;

        public CategoriesController(EcommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Get
        [HttpGet(Name ="Get Categories")]
        public IEnumerable<Category> Get()
        {
            return _dbContext.Categories.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Category> Get(int id)
        {
            var Category = _dbContext.Categories.FirstOrDefault(c=>c.CategoryId == id);
            if(Category == null)
            {
                return NotFound("Category Not Found");
            }
            return Category;
        }


        //Post
        [HttpPost("PostCategory")]
        public ActionResult<Category> PostCategory([FromBody] Category category)
        {
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
            return Ok();
        }


        //Delete
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var Category=_dbContext.Categories.FirstOrDefault(c=>c.CategoryId == id);
            if(Category == null)
            {
                return NotFound("Record Not Found");
            }
            _dbContext.Categories.Remove(Category);
            _dbContext.SaveChanges();
            return Ok();    
        }

        //Put
        [HttpPut("{id}")]
        public async Task<IActionResult> updateCategory(int id, [FromBody] Category category)
        {
            if (id != category.CategoryId)
                return BadRequest("Category Id Mismatch");

            var Category = await _dbContext.Categories.FindAsync(id);
            if(category == null)
            {
                return NotFound("Record Not Found");
            }

            Category.CategoryName = category.CategoryName;

            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        //Patch
        [HttpPatch("{id}")]
        public async Task<IActionResult> PartialUpdateCategory(int id, [FromBody] JsonPatchDocument<Category> category)
        {
            if (category != null)
                return BadRequest("Category Can not Be Null");

            var Category = await _dbContext.Categories.FindAsync(id);
            if(Category==null)
            {
                return NotFound("Record Not Exists");
            }

            category.ApplyTo(Category);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
