﻿using ArticleCancer.Application.DTOs.Categories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Application.DTOs.News
{
    public class NewAddDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid CategoryId { get; set; }
        public IFormFile? Photo { get; set; }
        public IList<CategoryDto> Categories { get; set; }
    }
}
