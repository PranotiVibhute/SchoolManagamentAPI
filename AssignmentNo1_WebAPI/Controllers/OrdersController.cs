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
    public class OrdersController : ControllerBase
    {
        private readonly EcommerceDbDevContext _dbContext;

        public OrdersController(EcommerceDbDevContext dbContext)
        {
            _dbContext = dbContext;
        }


        //GET /api/orders: List all orders
        [HttpGet(Name ="Get All Orders")]
        public IEnumerable<Order> Get()
        {
            return _dbContext.Orders.ToList();
        }

        //Get
        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            var result=_dbContext.Orders.FirstOrDefault(o=>o.OrderId==id);
            if(result==null)
            {
                return NotFound("Record Not Exists");
            }
            return result;
        }



        //POST /api/orders: Place a new order
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
            var Order=_dbContext.Orders.FirstOrDefault(o=>o.OrderId==id);
            if(Order==null)
            {
                return NotFound("Record Not Found");
            }
            _dbContext.Orders.Remove(Order);
            _dbContext.SaveChanges();
            return Ok();
        }


        //Put
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id,Order updateOrder)
        {
           
            if (id != updateOrder.OrderId)
                return BadRequest("Order Id Mismatch");


            var Order = await _dbContext.Orders.FindAsync(id);
            if(Order==null)
            {
                return NotFound("Order Not Found");
            }


            Order.ProductId = updateOrder.ProductId;
            Order.CustomerId = updateOrder.CustomerId;
            Order.OrderDate = updateOrder.OrderDate;
            Order.Quantity = updateOrder.Quantity;

            await _dbContext.SaveChangesAsync();

            return Ok("SuccessFully Update");
        }


        //Patch
        [HttpPatch("{id}")]
        public async Task<IActionResult> PartialUpdateOrder(int id, [FromBody] JsonPatchDocument<Order> patchDoc)
        {
            if (patchDoc == null)
                return BadRequest("Patch Document Cannot Be Null");

            var Order = await _dbContext.Orders.FindAsync(id);
            if (Order == null)
                return NotFound("Order Not Found");


            patchDoc.ApplyTo(Order);

            await _dbContext.SaveChangesAsync();

            return Ok("Successfully Update");

        }

    }
}
