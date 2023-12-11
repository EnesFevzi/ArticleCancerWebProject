using ArticleCancer.Application.DTOs.Categories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Application.DTOs.Announcements
{
	public class AnnouncementAddDto
	{
		public string Title { get; set; }
		public string Content { get; set; }
		public IFormFile? Photo { get; set; }
	}
}
