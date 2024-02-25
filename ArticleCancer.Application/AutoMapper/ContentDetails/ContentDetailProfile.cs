using ArticleCancer.Application.DTOs.ApplicationUsers;
using ArticleCancer.Application.DTOs.ContentDetails;
using ArticleCancer.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Application.AutoMapper.ContentDetails
{
    public class ContentDetailProfile : Profile
    {
        public ContentDetailProfile()
        {
            CreateMap<ContentDetailDto, ContentDetail>().ReverseMap();
           // CreateMap<ContentDetailUpdateDto, ContentDetail>().ReverseMap();
           // CreateMap<ContentDetailUpdateDto, ContentDetailDto>().ReverseMap();
           // CreateMap<ContentDetailAddDto, ContentDetail>().ReverseMap();
        }
    }
}
