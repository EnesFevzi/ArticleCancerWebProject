using ArticleCancer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Application.DTOs.ToDos
{
    public class ToDoDto
    {
        public Guid ToDoID { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public AppUser User { get; set; }
        public string Status { get; set; }
    }
}
