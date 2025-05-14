using Chat.Application.DTO;
using Chat.Application.Interfaces.Services;
using Chat.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Api.Controllers
{
    [ApiController]
    [Route("Messages")]
    public class MessageController(IMessageService messageService): ControllerBase
    {
        [HttpPost("AddMessage")]
        public async Task<IActionResult> AddMessage([FromBody]MessageDto messageDto)
        {
            try
            {
                var addedMessage = await messageService.AddMessage(messageDto);
                return Ok(addedMessage);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllMessagesInChat/{chatId}")]
        public async Task<IActionResult> GetAllMessagesInChat(uint chatId)
        {
            try
            {
                var allMessagesInChat = await messageService.GetAllMessagesInChat(chatId);
                return Ok(allMessagesInChat);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetMessageInChat/{messageId}")]
        public async Task<IActionResult> GetMessageInChat(uint messageId)
        {
            try
            {
                var message = await messageService.GetMessageInChat(messageId);
                return Ok(message);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("GetMessageInChatForSearch/{searchText}")]
        public async Task<IActionResult> GetMessageInChatForSearch(string searchText)
        {
            try
            {
                var message = await messageService.GetMessageInChatForSearch(searchText);
                return Ok(message);
            }
            catch (Exception ex)
            { 
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteMessage/{messageId}")]
        public async Task<IActionResult> DeleteMessage(uint messageId)
        {
            try
            {
                await messageService.DeleteMessage(messageId);
                
                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
