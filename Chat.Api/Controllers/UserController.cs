using Chat.Core.Interfaces.Services;
using Chat.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController(IUserService userService): ControllerBase
    {
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                List<User> users = await userService.GetAllUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost("Authorize")]
        public async Task<IActionResult> Authorize(string login, string password)
        {
            try
            {
                User user = await userService.Authorize(login, password);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Registrate")]
        public async Task<IActionResult> Registrate(User user)
        {
            try
            {
                await userService.Registrate(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
