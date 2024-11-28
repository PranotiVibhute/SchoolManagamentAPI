using Asp.NetFirstCodeEF.Interface;
using Asp.NetFirstCodeEF.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetFirstCodeEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer _customerService;
        public CustomerController(ICustomer customerService)
        {
            _customerService = customerService;
        }
        [HttpGet]
        public async Task<IActionResult> GetallCustomer()
        {
            var customer = await _customerService.GetAllCustomer();
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
    }
}
