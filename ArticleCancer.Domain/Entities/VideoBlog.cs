using ArticleCancer.Application.Interfaces.Entities;
using ArticleCancer.Domain.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Domain.Entities
{
    public class VideoBlog:EntityBase
    {
        public Guid VideoBlogID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int ViewCount { get; set; } = 0;

        public Guid VideoID { get; set; }
        public Video Video { get; set; }

        public Guid CategoryID { get; set; }
        public Category Category { get; set; }
        public Guid UserID { get; set; }
        public AppUser User { get; set; }
    }
}
