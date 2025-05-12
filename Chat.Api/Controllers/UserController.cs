using Chat.Application.DTO;
using Chat.Application.Interfaces.Services;
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
        public async Task<IActionResult> Authorize([FromBody]UserDto userAuthorizationDto)
        {
            try
            {
                User user = await userService.Authorize(userAuthorizationDto);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Registrate")]
        public async Task<IActionResult> Registrate([FromBody]UserDto userDto)
        {
            try
            {
                await userService.Registrate(userDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
