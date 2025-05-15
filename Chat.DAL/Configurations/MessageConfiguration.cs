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
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder
                .HasKey(message  => message.Id);
            
            builder
                .Property(message => message.Id)
                .ValueGeneratedOnAdd();

            builder
                .HasOne(message => message.Sender)
                .WithMany(user => user.Messages)
                .HasForeignKey(message => message.SenderId);
            
            builder
                .HasOne(message => message.Chat)
                .WithMany(chat => chat.Messages)
                .HasForeignKey(message => message.ChatId);
        }
    }
}
