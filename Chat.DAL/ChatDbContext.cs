using Chat.Core.Models;
using Chat.DAL.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.DAL
{
    public class ChatDbContext(DbContextOptions<ChatDbContext> options): DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Core.Models.Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ChatConfiguration());
            modelBuilder.ApplyConfiguration(new MessageConfiguration());
            base.OnModelCreating(modelBuilder);
        }

    }
}
