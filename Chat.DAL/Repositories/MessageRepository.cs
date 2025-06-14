﻿using Chat.Core.Interfaces.Repositories;
using Chat.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Chat.DAL.Repositories
{
    public class MessageRepository(ChatDbContext context) : IMessageRepository
    {
        public async Task<Message> AddMessage(Message message)
        {
            var addedMessage = await context.Messages.AddAsync(message);
            
            await context.SaveChangesAsync();
            
            return addedMessage.Entity;
        }

        public async Task UpdateMessage(uint messageId, string textToEdit)
        {
            try
            {
                await context.Messages
                    .Where(message => message.Id == messageId)
                    .ExecuteUpdateAsync(message => 
                        message.SetProperty(message => message.Text, textToEdit));
            }
            catch (Exception e)
            {
                throw new Exception("Error updating message", e);
            }
        }

        public async Task DeleteMessage(Message message)
        {
            try
            {
                context.Messages.Remove(message);
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("An error occured while deleting the message", e);
            }
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
            var message = await context.Messages
                .AsNoTracking()
                .FirstOrDefaultAsync(message => message.Id == messageId);
            
            if (message == null) { throw new ArgumentException("Not found messages with this id"); }
            
            return message;
        }

        public async Task<List<Message>> GetMessageInChatForSearch(string searchText)
        {
            var messages = await context.Messages
                .AsNoTracking()
                .Where(message => EF.Functions
                    .Like(message.Text, $"%{searchText}%"))
                .ToListAsync();
            
            if (messages.Count == 0) { return new List<Message>(); }
            
            return messages;
        }
    }
}
