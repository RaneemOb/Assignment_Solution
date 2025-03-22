using Assignment.Core.Models;
using Assignment.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] Users user)
        {
            int result = await userService.SignUp(user.Username, user.PasswordHash, user.Role);

            if (result ==1)
                return Ok(new { message = result });

            return BadRequest(new { message = result });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Users user)
        {
            
            var foundUser = await userService.Login(user.Username, user.PasswordHash);

            if (foundUser == null)
            {
                return Unauthorized("Invalid username or password.");
            }

            // Use the loginResult object
            return Ok(new
            {
                foundUser.Username,
                foundUser.UserId,
                foundUser.Role
            });
        }

    }
}
