using Chat.Api.Hubs;
using Chat.Application.DTO;
using Chat.Application.Interfaces.Services;
using Chat.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Chat.Api.Controllers
{
    [ApiController]
    [Route("Messages")]
    [Authorize]
    public class MessageController(IMessageService messageService, IUserService userService, IHubContext<ChatHub> hubContext): ControllerBase
    {
        [HttpPost("AddMessage")]
        public async Task<IActionResult> AddMessage([FromBody]MessageDto messageDto)
        {
            try
            {
                var addedMessage = await messageService.AddMessage(messageDto);

                var messageOwner =  await userService.GetUserById(addedMessage.SenderId);
                
                await hubContext.Clients
                    .Group(addedMessage.ChatId.ToString())
                    .SendAsync(
                        "ReceiveMessage",
                        messageOwner.Id,
                        messageOwner.UserName,
                        addedMessage.Text,
                        DateTime.UtcNow.ToString("HH:mm"),
                        addedMessage.Id);
                
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

        [HttpPut("{chatId}/Messages/{messageId}/Edit")]
        public async Task<IActionResult> UpdateMessage(uint chatId, uint messageId, [FromBody] UpdateMessageDto updateMessageDto)
        {
            try
            {
                await messageService.UpdateMessage(updateMessageDto);

                await hubContext.Clients
                    .Group(chatId.ToString())
                    .SendAsync(
                        "EditMessage",
                        updateMessageDto.Text,
                        updateMessageDto.Id);
                
                return Ok();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpDelete("{chatId}/DeleteMessage/{messageId}/Delete")]
        public async Task<IActionResult> DeleteMessage(uint messageId, uint chatId)
        {
            try
            {
                await messageService.DeleteMessage(messageId);

                await hubContext.Clients
                    .Group(chatId.ToString())
                    .SendAsync(
                        "DeleteMessage",
                        messageId);
                
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
