using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Core.Models
{
    public class Chat
    {
        public uint Id { get; set; }
        public string ChatName { get; set; }
        public List<User> Users { get; set; }
        public List<Message> Messages { get; set; }
    }
}
