using Chat.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        public Task<User> Authorize(string login, string password);
        public Task Registrate(User? user);
        public Task<List<User>> GetAllUsers();
        public Task<User?> GetUserById(uint id);
    }
}
