using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Application.DTOs.Messages
{
    public class SendMessageDto
    {
        public string Subject { get; set; }
        public string MessageDetails { get; set; }
        public string ReceiverMail { get; set; }
        public DateTime MessageDate { get; set; }
        public bool MessageStatus { get; set; }

    }
}
