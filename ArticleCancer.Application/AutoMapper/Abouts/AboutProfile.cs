using ArticleCancer.Application.DTOs.Abouts;
using ArticleCancer.Application.DTOs.Categories;
using ArticleCancer.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Application.AutoMapper.Abouts
{
    public class AboutProfile:Profile
    {
        public AboutProfile()
        {
            CreateMap<AboutDto, About>().ReverseMap();
            CreateMap<AboutAddDto, About>().ReverseMap();
            CreateMap<AboutUpdateDto, About>().ReverseMap();
            CreateMap<AboutUpdateDto, AboutDto>().ReverseMap();
        }
    }
}
