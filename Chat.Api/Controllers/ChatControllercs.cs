using Chat.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers
{
    [ApiController]
    [Route("Chats")]
    public class ChatControllercs(IChatService chatService): ControllerBase
    {

        [HttpGet("GetChatByUserName/{userName}")]
        public async Task<IActionResult> GetChatByUserName(string userName)
        {
            try
            {
                var chat = await chatService.GetChatByUserName(userName);
                return Ok(chat);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetChatsByUserId/{userId}")]
        public async Task<IActionResult> GetChatsByUserId(uint userId)
        {
            try
            {
                var chats = await chatService.GetChatsByUserId(userId);
                return Ok(chats);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
