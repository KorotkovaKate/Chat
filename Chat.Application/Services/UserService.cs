using Chat.Core.Interfaces.Repositories;
using Chat.Application.Interfaces.Services;
using Chat.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat.Application.DTO;
using Chat.Application.Mapping;

namespace Chat.Application.Services
{
    public class UserService(IUserRepository repository) : IUserService
    {
        public async Task<User> Authorize(UserDto userAuthorizationDto)
        {
            if (userAuthorizationDto.UserName == null || userAuthorizationDto.Password == null) { throw new ArgumentNullException("Login or password empty"); }
            var user = await repository.Authorize(userAuthorizationDto.UserName, userAuthorizationDto.Password);
            return user;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var users = new List<User>();
            users = await repository.GetAllUsers();
            return users;
        }

        public async Task Registrate(UserDto userDto)
        {
            if (userDto == null) { throw new Exception("Empty user"); }
            var user = UserMapping.MapUser(userDto);
            await repository.Registrate(user);
        }
    }
}
