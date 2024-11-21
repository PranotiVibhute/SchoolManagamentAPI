using ASPCoreWebAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly EcommerceDbContext _dbContext;

        public OrdersController(EcommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        //Get
        [HttpGet(Name="GetOrders")]
        public IEnumerable<Order> Get()
        {
            return _dbContext.Orders.ToList();
        }


        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            var Order = _dbContext.Orders.FirstOrDefault(o=>o.OrderId == id);
            if(Order == null)
            {
                return NotFound("Order Not Found");
            }
            return Order;
        }

        //Post
        [HttpPost("PostOrder")]
        public ActionResult<Order> PostOrder([FromBody] Order order)
        {
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
            return Ok();
        }


        //Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Order=_dbContext.Orders.FirstOrDefault(o=>o.OrderId == id);
            if(Order == null)
            {
                return NotFound("Record Not Found");
            }
            _dbContext.Orders.Remove(Order);
            _dbContext.SaveChanges();
            return Ok();
        }

        //Put
        [HttpPut("{id}")]
        public async Task<ActionResult> updateOrder(int id,Order order)
        {
            if (id != order.OrderId)
                return BadRequest("Order Id Is Mismatch");

            var Order = await _dbContext.Orders.FindAsync(id);
            if(Order==null)
            {
                return NotFound("Record Not Found");
            }

            Order.CustomerId=order.CustomerId;
            Order.ProductId=order.ProductId;
            Order.OrderDate=order.OrderDate;
            Order.Amount=order.Amount;

            await _dbContext.SaveChangesAsync();

            return Ok("SuccessFully Update");
        }


        //Patch
        [HttpPatch("{id}")]
        public async Task<IActionResult> PartialUpdateOrder(int id, [FromBody] JsonPatchDocument<Order> order)
        {
            if(order==null)
            {
                return BadRequest("Order Can Not Be Bull");
            }

            var Order = await _dbContext.Orders.FindAsync(id);
            if (Order == null)
                return NotFound("Record Not Found");


            order.ApplyTo(Order);

            await _dbContext.SaveChangesAsync();

            return Ok("SuccessFully Update");
        }
    }
}
