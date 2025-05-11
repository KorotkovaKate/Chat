using Chat.Core.Interfaces.Repositories;
using Chat.Core.Interfaces.Services;
using Chat.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.Services
{
    public class MessageService(IMessageRepository repository) : IMessageService
    {
        public Task<uint> AddMessage(Message message)
        {
            var addedMessage = repository.AddMessage(message);
            return addedMessage;
        }

        public async Task<List<Message>> GetAllMessagesInChat(uint chatId)
        {
            var messages = await repository.GetAllMessagesInChat(chatId);
            return messages;
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
