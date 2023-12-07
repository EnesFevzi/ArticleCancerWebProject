using ArticleCancer.Application.DTOs.Categories;
using ArticleCancer.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Application.DTOs.VideoBlogs
{
    public class VideoBlogUpdateDto
    {
        public Guid VideoBlogID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid CategoryId { get; set; }

        public Guid? VideoID { get; set; }
        public Video Video { get; set; }
        public IFormFile? Movie { get; set; }
        public IList<CategoryDto> Categories { get; set; }
    }
}
