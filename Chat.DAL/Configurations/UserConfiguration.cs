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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user => user.Id);
            builder.Property(user => user.Id).ValueGeneratedOnAdd();
            builder.Property(user => user.UserName).HasMaxLength(60).IsRequired();
            builder.Property(user => user.Password).HasMaxLength(20).IsRequired();

            builder.HasMany(user => user.Chats).WithMany(chat => chat.Users);
            builder.HasMany(user => user.Messages).WithOne(message => message.Sender).HasForeignKey(message => message.SenderId);
        }
    }
}
