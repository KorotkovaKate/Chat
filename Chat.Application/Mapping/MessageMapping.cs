using Chat.Application.DTO;
using Chat.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.Mapping
{
    public class MessageMapping
    {
        public static Message MapMessage(MessageDto messageDto) 
        {
            return new Message()
            {
                Text = messageDto.Text,
                DateTime = messageDto.DateTime,
                ChatId = messageDto.ChatId,
                SenderId = messageDto.SenderId,
            };
        }

        public static GetMessageDto MapToGetMessageDto(Message message) 
        {
            return new GetMessageDto()
            {
                Id = message.Id,
                Text = message.Text,
                DateTime = message.DateTime,
                SenderName = message.Sender.UserName
            };
        }
    }
}
