using Chat.Core.Interfaces.Repositories;
using Chat.Core.Interfaces.Services;
using Chat.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.Services
{
    public class UserService(IUserRepository repository) : IUserService
    {
        public async Task<User> Authorize(string login, string password)
        {
            var user = await repository.Authorize(login, password);
            if (login == null || password == null) { throw new ArgumentNullException("Login or password empty"); }
            return user;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var users = new List<User>();
            users = await repository.GetAllUsers();
            return users;
        }

        public async Task Registrate(User user)
        {
            if (user == null) { throw new Exception("Empty user"); }
            await repository.Registrate(user);
        }
    }
}
