using Chat.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers
{
    [ApiController]
    [Route("Chats")]
    public class ChatControllercs(IChatService chatService): ControllerBase
    {
        [HttpPost("AddChat")]
        public async Task<IActionResult> AddChat(Core.Models.Chat chat)
        {
            try
            {
                var addedchat = await chatService.AddChat(chat);
                return Ok(addedchat);
            }
            catch(Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetChatByUserName")]
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

        [HttpGet("GetChatsByUserId")]
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
