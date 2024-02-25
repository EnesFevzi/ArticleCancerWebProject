using ArticleCancer.Application.DTOs.Messages;
using ArticleCancer.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Application.AutoMapper.Messages
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<MessageDto, Message>().ReverseMap();
            CreateMap<SendMessageDto, Message>().ReverseMap();
            CreateMap<SendMessageDto, MessageDto>().ReverseMap();
        }
    }
}
