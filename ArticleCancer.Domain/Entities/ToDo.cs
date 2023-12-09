using ArticleCancer.Application.Interfaces.Entities;
using ArticleCancer.Domain.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Domain.Entities
{
    public class ToDo : EntityBase
    {
        public Guid ToDoID { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public Guid UserID { get; set; }
        public AppUser User { get; set; }
    }
}
