using ArticleCancer.Application.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Domain.Entities
{
    public class NewVisitor : IEntityBase
    {
        public NewVisitor()
        {
        }

        public NewVisitor(Guid newId, int visitorId)
        {
            NewID = newId;
            VisitorID = visitorId;
        }


        public Guid NewID { get; set; }
        public New New { get; set; }
        public int VisitorID { get; set; }
        public Visitor Visitor { get; set; }
    }
}
