using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.BusinessAbstraction;
using Server.Managers;
using Server.Models;

namespace Server.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private JWTManager _jwtManager;
        private IUserService _userService;
        public UserController(JWTManager jwtManager, IUserService userService)
        {
            _jwtManager = jwtManager;
            _userService = userService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            IEnumerable<User> users = await _userService.GetAllAsync();
            return Ok(users);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] int id)
        {
            User user = await _userService.GetAsync(id);
            return Ok(user);
        }
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] User user)
        {
            await _userService.CreateAsync(user);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser([FromBody] User user)
        {
            await _userService.UpdateAsync(user);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            await _userService.DeleteAsync(id);
            return Ok();
        }
        [HttpPost("/token")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] AuthData authData)
        {
            User user = await _userService.GetUserByNamePasswordAsync(authData.Login, authData.Password);
            if(user == null)
            {
                return Unauthorized();
            }
            var tokenString = _jwtManager.GenerateToken(user.Role.Name, user.Email, user.Password );
            return Ok(new { Token = tokenString, Role = user.Role.Name });
        }
    }
}
