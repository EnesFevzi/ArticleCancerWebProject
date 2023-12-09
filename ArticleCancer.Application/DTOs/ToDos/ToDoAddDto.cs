using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Application.DTOs.ToDos
{
    public class ToDoAddDto
    {
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } =DateTime.Now;
        public string Status { get; set; }
    }
}

