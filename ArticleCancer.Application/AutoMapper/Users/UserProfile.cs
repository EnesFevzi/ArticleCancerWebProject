using ArticleCancer.Application.DTOs.Articles;
using ArticleCancer.Application.DTOs.Users;
using ArticleCancer.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Application.AutoMapper.Users
{
	public class UserProfile : Profile
	{
		public UserProfile()
		{
			CreateMap<AppUser, UserListDto>().ReverseMap();
			CreateMap<AppUser, UserAddDto>().ReverseMap();
			CreateMap<AppUser, UserAddDto2>().ReverseMap();
			CreateMap<AppUser, UserUpdateDto>().ReverseMap();
			CreateMap<AppUser, UserProfileDto>().ReverseMap();
			CreateMap<AppUser, UserDto>().ReverseMap();

		}
	}
}
