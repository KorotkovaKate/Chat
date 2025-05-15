using Chat.Application.DTO;
using Chat.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.Interfaces.Services
{
    public interface IMessageService
    {
        public Task<List<GetMessageDto>> GetAllMessagesInChat(uint chatId);
        public Task<Message> GetMessageInChat(uint messageId);
        public Task<List<Message>> GetMessageInChatForSearch(string searchText);
        public Task<Message> AddMessage(MessageDto messageDto);
        public Task UpdateMessage(UpdateMessageDto updateMessageDto);
        public Task DeleteMessage(uint messageId);
    }
}
