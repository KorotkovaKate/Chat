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
    public class UserRepository(ChatDbContext context): IUserRepository
    {
        public async Task<User> Authorization(string login, string password)
        {
            var user = await context.Users.FirstOrDefaultAsync(user => user.UserName == login && user.Password == password);
            if (user == null) { throw new Exception(); }
            return user;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await context.Users.AsNoTracking().OrderBy(user => user.UserName).ToListAsync();
        }

        public async Task Registration(User user)
        {
            try
            {
                context.Users.Add(user);
                await context.SaveChangesAsync();
            }
            catch 
            {
                throw new Exception();
            }
        }
    }
}
