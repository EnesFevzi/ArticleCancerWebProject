using ArticleCancer.Application.DTOs.Announcements;
using ArticleCancer.Application.DTOs.Articles;
using ArticleCancer.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Application.AutoMapper.Announcements
{
	public class AnnouncementProfile : Profile
	{
		public AnnouncementProfile()
		{
			CreateMap<AnnouncementDto, Announcement>().ReverseMap();
			CreateMap<AnnouncementUpdateDto, Announcement>().ReverseMap();
			CreateMap<AnnouncementUpdateDto, AnnouncementDto>().ReverseMap();
			CreateMap<AnnouncementAddDto, Announcement>().ReverseMap();
		}
	}
}
