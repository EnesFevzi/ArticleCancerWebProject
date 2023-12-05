using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Application.DTOs.Categories
{
    public class CategoryUpdateDto
    {
        public Guid CategoryID { get; set; }
        public string Name { get; set; }
    }
}
