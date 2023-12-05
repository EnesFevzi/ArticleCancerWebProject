using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArticleCancer.Domain.Entities;

namespace ArticleCancer.Persistence.Mappings
{
    public class ImageMap : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasData(new Image
            {
                ImageID = Guid.Parse("01673030-C382-45F8-84DC-A095BF6A7532"),
                FileName = "user-images/user.png",
                FileType = "image/png",
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false
            },
            new Image
            {
                ImageID = Guid.Parse("D16A6EC7-8C50-4AB0-89A5-02B9A551F0FA"),
                FileName = "article-images/defaultarticle.png",
                FileType = "image/png",
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false
            });
        }
    }
}
