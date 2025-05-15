using Chat.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.DAL.Configurations
{
    public class ChatConfiguration : IEntityTypeConfiguration<Core.Models.Chat>
    {
        public void Configure(EntityTypeBuilder<Core.Models.Chat> builder)
        {
            builder
                .HasKey(chat => chat.Id);
            
            builder
                .Property(chat => chat.Id)
                .ValueGeneratedOnAdd();

            builder
                .HasMany(chat => chat.Users)
                .WithMany(user => user.Chats);
            
            builder
                .HasMany(chat => chat.Messages)
                .WithOne(message => message.Chat)
                .HasForeignKey(message => message.ChatId);
        }
    }
}
