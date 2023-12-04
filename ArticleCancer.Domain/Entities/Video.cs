using ArticleCancer.Application.Interfaces.Entities;
using ArticleCancer.Domain.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Domain.Entities
{
    public class Video:EntityBase
    {
        public Guid VideoID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string VideoURL { get; set; }


        public Guid CategoryID { get; set; }
        public Category Category { get; set; }
        public Guid UserID { get; set; }
        public AppUser Users { get; set; }
    }
}
