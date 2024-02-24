using ArticleCancer.Application.DTOs.ApplicationUsers;
using ArticleCancer.Application.DTOs.Articles;
using ArticleCancer.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Application.AutoMapper.ApplicationUsers
{
    public class ApplicationUserProfile : Profile
    {
        public ApplicationUserProfile()
        {
            CreateMap<ApplicationUserDto, ApplicationUser>().ReverseMap();
            CreateMap<ApplicationUserUpdateDto, ApplicationUser>().ReverseMap();
            CreateMap<ApplicationUserUpdateDto, ApplicationUserDto>().ReverseMap();
            CreateMap<ApplicationUserAddDto, ApplicationUser>().ReverseMap();
        }
    }
}
