using Chat.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.DTO
{
    public class MessageDto
    {
        public string Text { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
        public uint SenderId { get; set; }
        public uint ChatId { get; set; }
    }
}
