using Chat.Core.Interfaces.Repositories;
using Chat.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Chat.DAL.Repositories
{
    public class MessageRepository(ChatDbContext context) : IMessageRepository
    {
        public async Task<uint> AddMessage(Message message)
        {
            var addedMessage = await context.Messages.AddAsync(message);
            await context.SaveChangesAsync();
            return addedMessage.Entity.Id;
        }

        public async Task<List<Message>> GetAllMessagesInChat(uint chatId)
        {
            var messageList = await context.Messages.AsNoTracking()
                .Include(m => m.Sender)
                .Where(message => message.ChatId == chatId).ToListAsync();
            if (messageList.Count == 0) {  return new List<Message>(); }
            return messageList;
        }
    

        public async Task<Message> GetMessageInChat(uint messageId)
        {
            var message = await context.Messages.AsNoTracking().FirstOrDefaultAsync(message => message.Id == messageId);
            if (message == null) { throw new ArgumentException("Not found messages with this id"); }
            return message;
        }

        public async Task<List<Message>> GetMessageInChatForSearch(string searchText)
        {
            var messages = await context.Messages.AsNoTracking().Where(message => EF.Functions.Like(message.Text, $"%{searchText}%")).ToListAsync();
            if (messages.Count == 0) { return new List<Message>(); }
            return messages;
        }
    }
}
