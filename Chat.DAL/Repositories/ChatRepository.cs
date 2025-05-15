using Chat.Core.Interfaces.Repositories;
using Chat.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Chat.DAL.Repositories
{
    public class ChatRepository(ChatDbContext context) : IChatRepository
    {
        public async Task AddChat(User user)
        {
            var chats = new List<Core.Models.Chat>();
            var users = await context.Users.ToListAsync();

            foreach (var tempUser in users)
            {
                if (tempUser.Id == user.Id) { continue; }
                var chatUsers = new List<User>() { user, tempUser };
                var chat = new Core.Models.Chat();
                chat.ChatName = tempUser.UserName;
                chat.Users = chatUsers;
                chat.Messages = new List<Message>();

                context.Users.Attach(chat.Users[0]);
                context.Users.Attach(chat.Users[1]);

                chats.Add(chat);
            }

            await context.Chats.AddRangeAsync(chats);
            await context.SaveChangesAsync();
        }

        public async Task<Core.Models.Chat> GetChatByUserName(string userName)
        {
            var chat = await context.Chats
                .AsNoTracking()
                .Include(chat => chat.Users)
                .FirstOrDefaultAsync(chat => chat.Users.Any(user => user.UserName == userName));
            
            if (chat == null) { throw new Exception("No chats with this userName"); }
            
            return chat;
        }

        public async Task<List<Core.Models.Chat>> GetChatsByUserId(uint userId)
        {
            var chat = await context.Chats.AsNoTracking().Where(chat => chat.Users.Any(user => user.Id == userId)).ToListAsync();
            
            if (chat == null) { throw new Exception("No chats is found"); }
            
            return chat;

        }
    }
}
