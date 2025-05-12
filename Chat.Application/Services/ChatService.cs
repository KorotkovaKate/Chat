using Chat.Core.Interfaces.Repositories;
using Chat.Application.Interfaces.Services;
using Chat.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.Services
{

    public class ChatService(IChatRepository repository, IUserService userService) : IChatService
    {
        public async Task<Core.Models.Chat> GetChatByUserName(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName)) { throw new ArgumentException("Empty input userName"); }

            try
            {
                return await repository.GetChatByUserName(userName);
            }
            catch
            {
                throw new Exception("Something goes wrong");
            }
        }

        public async Task<List<Core.Models.Chat>> GetChatsByUserId(uint userId)
        {
            if (userId == 0) { throw new ArgumentException("Inccorect id"); }

            try
            {
                List<Core.Models.Chat> chats = await repository.GetChatsByUserId(userId);
                return chats;
            }
            catch
            {
                throw new Exception("Something goes wrong");
            }
        }
    }
}
