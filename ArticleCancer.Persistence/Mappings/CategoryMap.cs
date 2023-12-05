using ArticleCancer.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Persistence.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new Category
            {
                CategoryID = Guid.Parse("9019DD67-01E4-4435-A939-88AB3042C44A"),
                Name = "Meme Kanseri",
                CreatedBy = "Admin",
                CreatedDate = DateTime.Now,
                IsDeleted = false
            }
            );

        }
    }
}
