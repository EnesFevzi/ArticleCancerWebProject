using ArticleCancer.Domain.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Domain.Entities
{
	public class Announcement:EntityBase
	{
		public Guid AnnouncementID { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public int ViewCount { get; set; } = 0;

		public Guid? ImageID { get; set; }
		public Image Image { get; set; }

		public Guid UserID { get; set; }
		public AppUser User { get; set; }
	}
}
