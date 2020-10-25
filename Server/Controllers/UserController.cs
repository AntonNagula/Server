﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Managers;
using Server.Models;

namespace Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        List<User> users = new List<User>();
        List<Role> roles = new List<Role>();
        private JWTManager _jwtManager;
        public UserController(JWTManager jwtManager)
        {
            _jwtManager = jwtManager;
            users.Add(new User { UserId = 1, Name = "jjjj", RoleId = 1 });
            roles.Add(new Role { RoleId = 1, Name = "plokij" });
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(users);
        }
        [HttpGet("/api/Roles")]
        public async Task<IActionResult> GetRoles()
        {
            return Ok(roles);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] int id)
        {
            User user = users.FirstOrDefault(x => x.UserId == id);
            return Ok(user);
        }
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] User user)
        {
            users.Add(user);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser([FromBody] User user)
        {
            users.Add(user);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            return Ok();
        }
        [HttpPost("/token")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] AuthData authData)
        {
            var tokenString = _jwtManager.GenerateToken("d","d");
            return Ok(new { Token = tokenString });
        }
    }
}
