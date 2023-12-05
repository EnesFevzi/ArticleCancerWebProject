using ArticleCancer.Application.DTOs.Categories;
using ArticleCancer.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Application.DTOs.Articles
{
    public class ArticleUpdateDto
    {
        public Guid ArticleID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid CategoryId { get; set; }

        public Guid? ImageID { get; set; }
        public Image Image { get; set; }
        public IFormFile? Photo { get; set; }
        public IList<CategoryDto> Categories { get; set; }
    }
}
