using Chat.Core.Interfaces.Repositories;
using Chat.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Chat.DAL.Repositories
{
    public class MessageRepository(ChatDbContext context) : IMessageRepository
    {
        public async Task<List<Message>> GetAllMessagesInChat(uint chatId)
        {
            return await context.Messages.AsNoTracking().Where(message => message.ChatId == chatId).ToListAsync();
        }
    

        public async Task<Message> GetMessageInChat(uint messageId)
        {
            var message = await context.Messages.AsNoTracking().FirstOrDefaultAsync(message => message.Id == messageId);
            if (message == null) { throw new ArgumentException(); }
            return message;
        }

        public async Task<List<Message>> GetMessageInChatForSearch(string searchText)
        {
            return await context.Messages.AsNoTracking().Where(message => EF.Functions.Like(message.Text, $"%{searchText}%")).ToListAsync();
        }
    }
}
