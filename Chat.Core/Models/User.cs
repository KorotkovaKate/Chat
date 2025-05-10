using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Core.Models
{
    public class User
    {
        public uint Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<Chat> Chats { get; set; }
        public List<Message> Messages { get; set; }
    }
}
