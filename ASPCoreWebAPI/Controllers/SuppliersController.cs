using ASPCoreWebAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly EcommerceDbContext _dbContext;
        
        public SuppliersController(EcommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Get
        [HttpGet(Name ="Get Suppilers")]
        public IEnumerable<Supplier> Get()
        {
            return _dbContext.Suppliers.ToList();
        }


        [HttpGet("{id}")]
        public ActionResult<Supplier> Get(int id)
        {
            var Supplier=_dbContext.Suppliers.FirstOrDefault(s=>s.SupplierId == id);
            if(Supplier == null)
            {
                return NotFound("Supplier Not Found");
            }
            return Ok();
        }


        //Post
        [HttpPost("PostSupplier")]
        public ActionResult<Supplier> PostSupplier([FromBody] Supplier supplier)
        {
            _dbContext.Suppliers.Add(supplier);
            _dbContext.SaveChanges();
            return Ok();
        }


        //Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Supplier=_dbContext.Suppliers.FirstOrDefault(s=> s.SupplierId == id);
            if(Supplier==null)
            {
                return NotFound("Record Not Found");
            }
            _dbContext.Suppliers.Remove(Supplier);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
