using ASPCoreWebAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly EcommerceDbContext _dbContext;

        public ProductsController(EcommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Get
        [HttpGet(Name = "GetProducts")]
        public IEnumerable<Product> Get()
        {
            return _dbContext.Products.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var Product = _dbContext.Products.FirstOrDefault(p => p.ProductId == id);
            if (Product == null)
            {
                return NotFound("Product Not Found");
            }
            return Product;
        }


        //Post
        [HttpPost("PostProduct")]
        public ActionResult<Product> PostProduct([FromBody] Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return Ok();
        }


        //Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Product = _dbContext.Products.FirstOrDefault(p => p.ProductId == id);
            if (Product == null)
            {
                return NotFound("Record Not Found");
            }

            _dbContext.Products.Remove(Product);
            _dbContext.SaveChanges();
            return Ok();

        }

    }
}
