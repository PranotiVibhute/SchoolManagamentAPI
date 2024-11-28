using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAssiment3.Context;
using WebApiAssiment3.Entities;
using WebApiAssiment3.Interface;
using WebApiAssiment3.Service;

namespace WebApiAssiment3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _userService;
        public UserController(IUser userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var obj = await _userService.GetAllUsers();
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpPost("AddUser")]
        public async Task<IActionResult>SaveUser(User users)
        {
            var obj=await _userService.AddUsers(users);
            return Ok(obj);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User updatedUser)
        { 
            if (id != updatedUser.UserId)
                return BadRequest("User ID mismatch");

            var updatedUserResult = await _userService.UpdateUser(id, updatedUser);
            if (updatedUserResult == null)
                return NotFound(" not found or update failed");

            return Ok(updatedUserResult);

        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteUserById(int id)
        {
            var obj=await _userService.DeleteUserById(id);
            return Ok(obj);
        }
                      
    }
}
