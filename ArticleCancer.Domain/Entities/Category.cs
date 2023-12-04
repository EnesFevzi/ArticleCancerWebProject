using ArticleCancer.Application.Interfaces.Entities;
using ArticleCancer.Domain.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Domain.Entities
{
    public class Category:EntityBase
    {
        public Guid CategoryID { get; set; }
        public string Name { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
