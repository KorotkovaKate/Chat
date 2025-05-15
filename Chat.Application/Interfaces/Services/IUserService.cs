using Chat.Application.DTO;
using Chat.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.Interfaces.Services
{
    public interface IUserService
    {
        public Task<User> Authorize(UserDto userAuthorizationDto);
        public Task Registrate(UserDto userDto);
        public Task<List<User>> GetAllUsers();
        public Task<User> GetUserById(uint userId);
    }
}
