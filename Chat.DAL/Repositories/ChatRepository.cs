using Chat.Core.Interfaces.Repositories;
using Chat.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.DAL.Repositories
{
    public class ChatRepository(ChatDbContext context) : IChatRepository
    {
        public async Task<Core.Models.Chat> GetChatByUserName(string userName)
        {
            var chat = await context.Chats.AsNoTracking().FirstOrDefaultAsync(chat => chat.Users.Any(user => user.UserName == userName));
            if (chat == null) { throw new Exception(); }
            return chat;
        }

        public async Task<List<Core.Models.Chat>> GetChatsByUserId(uint userId)
        {
            return await context.Chats.AsNoTracking().Where(chat => chat.Users.Any(user => user.Id == userId)).ToListAsync();
        }
    }
}
