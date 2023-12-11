using ArticleCancer.Application.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Domain.Entities
{
	public class AnnouncementVisitor : IEntityBase
	{
		public AnnouncementVisitor()
		{
		}

		public AnnouncementVisitor(Guid announcementId, int visitorId)
		{
			AnnouncementID = announcementId;
			VisitorID = visitorId;
		}


		public Guid AnnouncementID { get; set; }
		public Announcement Announcement { get; set; }
		public int VisitorID { get; set; }
		public Visitor Visitor { get; set; }
	}
}
