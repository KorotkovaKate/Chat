using Chat.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.Interfaces.Services
{
    public interface IChatService
    {
        public Task<List<Core.Models.Chat>> GetChatsByUserId(uint userId);
        public Task<Core.Models.Chat> GetChatByUserName(string userName);
    }
}
