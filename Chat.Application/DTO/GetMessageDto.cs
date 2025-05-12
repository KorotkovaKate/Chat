using Chat.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.DTO
{
    public class GetMessageDto
    {
        public uint Id { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public string SenderName { get; set; }
    }
}
