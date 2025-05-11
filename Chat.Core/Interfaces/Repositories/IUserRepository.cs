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
        public Task<User> Authorization(string login, string password);
        public Task Registration(User user);
        public Task<List<User>> GetAllUsers();
    }
}
