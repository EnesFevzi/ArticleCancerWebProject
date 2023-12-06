using ArticleCancer.Application.DTOs.Articles;
using ArticleCancer.Application.DTOs.News;
using ArticleCancer.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Application.AutoMapper.News
{
    public class NewProfile : Profile
    {
        public NewProfile()
        {
            CreateMap<NewDto, New>().ReverseMap();
            CreateMap<NewUpdateDto, New>().ReverseMap();
            CreateMap<NewUpdateDto, NewDto>().ReverseMap();
            CreateMap<NewAddDto, New>().ReverseMap();
        }
    }
}
