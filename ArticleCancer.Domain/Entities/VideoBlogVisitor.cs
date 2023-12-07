using ArticleCancer.Application.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Domain.Entities
{
    public class VideoBlogVisitor : IEntityBase
    {
        public VideoBlogVisitor()
        {
        }

        public VideoBlogVisitor(Guid videoBlogId, int visitorId)
        {
            VideoBlogID = videoBlogId;
            VisitorID = visitorId;
        }


        public Guid VideoBlogID { get; set; }
        public New New { get; set; }
        public int VisitorID { get; set; }
        public Visitor Visitor { get; set; }
    }
}
