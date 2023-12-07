using ArticleCancer.Application.DTOs.Categories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Application.DTOs.VideoBlogs
{
    public class VideoBlogAddDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid CategoryId { get; set; }
        public IFormFile? Movie { get; set; }
        public IList<CategoryDto> Categories { get; set; }
    }
}
