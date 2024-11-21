using Microsoft.AspNetCore.JsonPatch;
using AssignmentNo1_WebAPI.WebAPIAssignment;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AssignmentNo1_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly EcommerceDbDevContext _dbDevContext;

        public ProductsController(EcommerceDbDevContext dbDevContext)
        {
            _dbDevContext = dbDevContext;
        }

        // GET /api/products: List all products
        [HttpGet(Name = "Get Products")]
        public IEnumerable<Product> Get()
        {
            return _dbDevContext.Products.ToList();
        }

        //Get
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var Product = _dbDevContext.Products.FirstOrDefault(p => p.ProductId == id);
            if (Product == null)
            {
                return NotFound("Record Not Exist");
            }
            return Product;
        }

        //Get
        /*[HttpGet("{name}")]
        public ActionResult<Product> Get(string name)
        {
            var Product=_dbDevContext.Products.FirstOrDefault(p=>p.Name==name);
            if(Product==null)
            {
                return NotFound("Record Not Exists");
            }
            return Product;
        }*/

        //POST /api/products: Add a new product
        [HttpPost("PostProduct")]
        public ActionResult<Product> PostProduct([FromBody] Product product)
        {
            _dbDevContext.Products.Add(product);
            _dbDevContext.SaveChanges();
            return Ok();
        }


        //DELETE /api/products/{id}: Delete a product
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var Product = _dbDevContext.Products.FirstOrDefault(p => p.ProductId == id);
            if (Product == null)
            {
                return NotFound("Record Not Found");
            }
            _dbDevContext.Products.Remove(Product);
            _dbDevContext.SaveChanges();
            return Ok("Record Deleted");
        }

        //Put
        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateProduct(int id, Product updateProduct)
        {
            if (id != updateProduct.ProductId)
                return BadRequest("Product ID Mismatch");

            var Product = await _dbDevContext.Products.FindAsync(id);
            if (Product == null)
                return NotFound("Product Not Found");

            //update entire Product Object
            Product.Name = updateProduct.Name;
            Product.Description = updateProduct.Description;
            Product.Price = updateProduct.Price;
            Product.Stock = updateProduct.Stock;
            Product.Category = updateProduct.Category;

            await _dbDevContext.SaveChangesAsync();

            return Ok("Update SuccessFully");

            
        }

        //Patch
        [HttpPatch("{id}")]
        public async Task<IActionResult> PartialUpdateProduct(int id, [FromBody] JsonPatchDocument<Product> patchDoc)
        {
            //Check if patch document is Provide
            if (patchDoc == null)
                return BadRequest("Patch Document Cannot Be Null");

            //Find the Product By ID
            var Product = await _dbDevContext.Products.FindAsync(id);
            if (Product == null)
                return NotFound("Product Not Found");

            //Apply the patch to the product Object
            patchDoc.ApplyTo(Product);

            
            await _dbDevContext.SaveChangesAsync();

            return Ok("Update SuccessFully");

        }
    }
}
