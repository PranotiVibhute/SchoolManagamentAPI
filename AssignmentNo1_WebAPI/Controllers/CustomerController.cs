using Microsoft.AspNetCore.JsonPatch;
using AssignmentNo1_WebAPI.WebAPIAssignment;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentNo1_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly EcommerceDbDevContext _dbContext;

        public CustomerController(EcommerceDbDevContext dbContext)
        {
            _dbContext = dbContext;
        }

        //GET /api/customers: List all customer
        [HttpGet(Name ="Get Customer")]
        public IEnumerable<Customer> Get()
        {
            return _dbContext.Customers.ToList();
        }


        //Get
        /* [HttpGet("{id}")]
         public ActionResult<Customer> Get(int id)
         {
             var result = _dbContext.Customers.FirstOrDefault(c => c.CustomerId == id);
             if(result==null)
             {
                 return NotFound("Record Not Exists");
             }
             return result;
         }*/


        [HttpGet("{name}")]
        public ActionResult<Customer> Get(string name)
        {
            var result=_dbContext.Customers.FirstOrDefault(c=>c.Name == name);
            if(result==null)
            {
                return NotFound("Record Not Exists");
            }
            return result;
        }


        //POST /api/customers: Add a new customer
        [HttpPost("PostCustomer")]
        public ActionResult<Customer> PostCustomer([FromBody] Customer customer)
        {
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
            return Ok() ;
        }


        //DELETE /api/customers/{id}: Delete a customer
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Customer=_dbContext.Customers.FirstOrDefault(c=>c.CustomerId==id);
            if(Customer==null)
            {
                return NotFound("Customer Not Found");
            }
            _dbContext.Customers.Remove(Customer);
            _dbContext.SaveChanges();
            return Ok();
        }


        //Put
        [HttpPut("{id}")]
        public async Task<IActionResult>  UpdateCustomer(int id, Customer updateCustomer)
        {
            
            if (id != updateCustomer.CustomerId)
                return BadRequest("Customer ID Mismatch");

            var Customer = await _dbContext.Customers.FindAsync(id);
            if (Customer == null)
                return NotFound("Customer Not Found");


            Customer.Name = updateCustomer.Name;
            Customer.Email=updateCustomer.Email;
            Customer.Phone = updateCustomer.Phone;
            Customer.Address = updateCustomer.Address;

            await _dbContext.SaveChangesAsync();

            return Ok("Successfully Update");

        }


        //Patch
        [HttpPatch("{id}")]
        public async Task<IActionResult> PartialUpdateProduct(int id, [FromBody] JsonPatchDocument<Customer> patchDoc)
        {
            //Check if patch document is Provide
            if (patchDoc == null)
                return BadRequest("Patch Document Cannot Be Null");

            //Find the Customer By ID
            var Customer = await _dbContext.Customers.FindAsync(id);
            if (Customer == null)
                return NotFound("Customer Not Found");

            //Apply the patch to the Customer Object
            patchDoc.ApplyTo(Customer);

            await _dbContext.SaveChangesAsync();

            return Ok("Successfully Update");

        }

    }
}
