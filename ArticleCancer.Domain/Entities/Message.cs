﻿using ArticleCancer.Application.Interfaces.Entities;
using ArticleCancer.Domain.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Domain.Entities
{
    public class Message:EntityBase
    {
        public Guid MessageID { get; set; }
        public string Subject { get; set; }
        public string MessageDetails { get; set; }
        public DateTime MessageDate { get; set; }
        public bool MessageStatus { get; set; }


        public Guid? SenderUserId { get; set; }
        public AppUser SenderUser { get; set; }
        public Guid? ReceiverUserId { get; set; }
        public AppUser ReceiverUser { get; set; }
    }
}
