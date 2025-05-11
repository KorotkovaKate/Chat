using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Core.Interfaces.Services
{
    public interface IChatService
    {
        public Task<List<Core.Models.Chat>> GetChatsByUserId(uint userId);
        public Task<Models.Chat> GetChatByUserName(string userName);
        public Task<uint> AddChat(Core.Models.Chat chat);
    }
}
