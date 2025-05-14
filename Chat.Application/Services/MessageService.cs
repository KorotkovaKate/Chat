using Chat.Core.Interfaces.Repositories;
using Chat.Application.Interfaces.Services;
using Chat.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat.Application.DTO;
using Chat.Application.Mapping;

namespace Chat.Application.Services
{
    public class MessageService(IMessageRepository repository) : IMessageService
    {
        public Task<uint> AddMessage(MessageDto messageDto)
        {
            var message = MessageMapping.MapMessage(messageDto);
            var addedMessage = repository.AddMessage(message);
            return addedMessage;
        }

        public async Task DeleteMessage(uint messageId)
        {
            var messageToDelete = await repository.GetMessageInChat(messageId);
            if (messageToDelete == null) throw new ArgumentNullException("Message to delete not found"); 
            await repository.DeleteMessage(messageToDelete);
        }

        public async Task<List<GetMessageDto>> GetAllMessagesInChat(uint chatId)
        {
            var messages = await repository.GetAllMessagesInChat(chatId);
            return messages.Select(m => MessageMapping.MapToGetMessageDto(m)).ToList();
        }

        public async Task<Message> GetMessageInChat(uint messageId)
        {
            if (messageId == 0) { throw new ArgumentException("Inccorect id"); }
            var message = await repository.GetMessageInChat(messageId);
            return message;
        }

        public async Task<List<Message>> GetMessageInChatForSearch(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText)) { throw new ArgumentException("Empty searchText"); }
            var messages = await repository.GetMessageInChatForSearch(searchText);
            return messages;
        }
    }
}
