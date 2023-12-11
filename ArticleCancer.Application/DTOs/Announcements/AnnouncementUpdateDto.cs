using ArticleCancer.Application.DTOs.Categories;
using ArticleCancer.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Application.DTOs.Announcements
{
	public class AnnouncementUpdateDto
	{
		public Guid AnnouncementID { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }

		public Guid? ImageID { get; set; }
		public Image Image { get; set; }
		public IFormFile? Photo { get; set; }
	}
}
