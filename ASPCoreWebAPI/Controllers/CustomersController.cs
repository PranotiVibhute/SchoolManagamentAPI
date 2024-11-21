using ASPCoreWebAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly EcommerceDbContext _dbContext;

        public CustomersController(EcommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Get
        [HttpGet(Name="GetCustomer")]
         public IEnumerable<Object> Get()
         {
             return _dbContext.Customers.Select(c => new {c.CustomerId,c.CustomerName}).ToList();
         }

        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            var customer = _dbContext.Customers.FirstOrDefault(c => c.CustomerId == id);
            if (customer == null)
            {
                return NotFound("Customer Not Found");
            }
            return customer;
        }

        //Post
        [HttpPost("PostCustomer")]
        public ActionResult<Customer> PostCustomer([FromBody] Customer customer)
        {
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
            return Ok();
        }


        //Delete
        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var customer = _dbContext.Customers.FirstOrDefault(c => c.CustomerId == id);
            if (customer == null)
            {
                return NotFound("Record Not Found");
            }

            _dbContext.Customers.Remove(customer);
            _dbContext.SaveChanges();
            return Ok();
        }


        //Put
        [HttpPut("{id}")]
        public async Task<ActionResult> updateCustomer(int id,Customer updateCustomer)
        {
            if (id != updateCustomer.CustomerId)
                return BadRequest("Customer Id Not Match");

            var Customer = await _dbContext.Customers.FindAsync(id);
            if(Customer==null)
            {
                return NotFound("Record Not Found");
            }

            Customer.CustomerName = updateCustomer.CustomerName;
            Customer.CustomerEmail = updateCustomer.CustomerEmail;
            Customer.City= updateCustomer.City;

            await _dbContext.SaveChangesAsync();

            return Ok("SuccessFully Update");
        }


        //Patch
        [HttpPatch("{id}")]
        public async Task<IActionResult> PartialUpdateCustomer(int id, [FromBody] JsonPatchDocument<Customer> patchDoc)
        {
            if (patchDoc == null)
                return BadRequest("patchDoc can not be Null");

            var Customer = await _dbContext.Customers.FindAsync(id);
            if(Customer==null)
            {
                return NotFound("Record Not Found");

            }

            patchDoc.ApplyTo(Customer);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }

    }
}


