using ArticleCancer.Application.DTOs.Articles;
using ArticleCancer.Application.DTOs.VideoBlogs;
using ArticleCancer.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Application.AutoMapper.VideoBlogs
{
    public class VideoBlogProfile:Profile
    {
        public VideoBlogProfile()
        {
            CreateMap<VideoBlogDto, VideoBlog>().ReverseMap();
            CreateMap<VideoBlogUpdateDto, VideoBlog>().ReverseMap();
            CreateMap<VideoBlogUpdateDto, VideoBlogDto>().ReverseMap();
            CreateMap<VideoBlogAddDto, VideoBlog>().ReverseMap();
        }
    }
}
