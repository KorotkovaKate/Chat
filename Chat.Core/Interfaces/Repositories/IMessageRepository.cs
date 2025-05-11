using Chat.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Core.Interfaces.Repositories
{
    public interface IMessageRepository
    {
        public Task<List<Message>> GetAllMessagesInChat(uint chatId);
        public Task<Message> GetMessageInChat(uint messageId);
        public Task<List<Message>> GetMessageInChatForSearch(string searchText);
    }
}
