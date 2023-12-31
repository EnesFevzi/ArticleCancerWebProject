﻿using ArticleCancer.Application.Interfaces.Entities;
using ArticleCancer.Domain.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Domain.Entities
{
    public class About : EntityBase
    {
        public Guid AboutID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public Guid ImageID { get; set; }
        public Image Image { get; set; }
    }
}
