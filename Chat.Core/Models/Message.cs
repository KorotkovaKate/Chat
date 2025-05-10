using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Core.Models
{
    public class Message
    {
        public uint Id { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public uint SenderId {  get; set; }
        public User Sender { get; set; }
        public uint ChatId { get; set; }
        public Chat Chat { get; set; }
    }
}
