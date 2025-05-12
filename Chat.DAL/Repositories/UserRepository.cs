using Chat.Core.Interfaces.Repositories;
using Chat.Application.Interfaces.Services;
using Chat.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.DAL.Repositories
{
    public class UserRepository(ChatDbContext context, IChatRepository chatRepository): IUserRepository
    {
        public async Task<User> Authorize(string login, string password)
        {
            var user = await context.Users.FirstOrDefaultAsync(user => user.UserName == login && user.Password == password);
            if (user == null) { throw new Exception("Not found user"); }
            return user;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await context.Users.AsNoTracking().OrderBy(user => user.UserName).ToListAsync();
        }

        public async Task Registrate(User user)
        {
            var checkUser = await context.Users.FirstOrDefaultAsync(check => check.UserName == user.UserName);
            if (checkUser != null) { throw new Exception("User already exists"); }
            try
            {
                context.Users.Add(user);
                await context.SaveChangesAsync();

                await chatRepository.AddChat(user);
            }
            catch 
            {
                throw new Exception();
            }
        }
    }
}
