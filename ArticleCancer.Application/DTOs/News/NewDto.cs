using ArticleCancer.Application.DTOs.Categories;
using ArticleCancer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Application.DTOs.News
{
    public class NewDto
    {
        public Guid NewID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public CategoryDto Category { get; set; }
        public DateTime CreatedDate { get; set; }
        public Image Image { get; set; }
        public AppUser User { get; set; }
        public string CreatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public int ViewCount { get; set; }
    }
}
