using System;
using Chat.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Core.Interfaces.Repositories
{
    public interface IChatRepository
    {
        public Task<List<Core.Models.Chat>> GetChatsByUserId(uint userId);
        public Task<Models.Chat> GetChatByUserName(string userName);
    }
}
