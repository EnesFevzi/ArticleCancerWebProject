﻿using ArticleCancer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Application.DTOs.Announcements
{
	public class AnnouncementListDto
	{
		public ICollection<Announcement> Announcements { get; set; }
		public virtual int CurrentPage { get; set; } = 1;
		public virtual int PageSize { get; set; } = 3;
		public virtual int TotalCount { get; set; }
		public virtual int TotalPages => (int)Math.Ceiling(decimal.Divide(TotalCount, PageSize));
		public virtual bool ShowPrevious => CurrentPage > 1;
		public virtual bool ShowNext => CurrentPage < TotalPages;
		public virtual bool IsAscending { get; set; } = false;
	}
}
