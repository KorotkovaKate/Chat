using Chat.Application.DTO;
using Chat.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.Mapping
{
    public class UserMapping
    {
        public static User MapUser(UserDto userDto)
        {
            return new User()
            {
                UserName = userDto.UserName,
                Password = userDto.Password
            };
        }
    }
}
