using ArticleCancer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Persistence.Mappings
{
    public class NewMap: IEntityTypeConfiguration<New>
    {
        public void Configure(EntityTypeBuilder<New> builder)
    {
        builder.HasData(new New
        {
            NewID = Guid.Parse("20042866-5942-4772-99EC-75B17944BED8"),
            Title = "Asp.net Core Deneme Makalesi 1",
            Content = "Asp.net Core Sed porttitor lectus nibh. Nulla porttitor accumsan tincidunt. Vivamus suscipit tortor eget felis porttitor volutpat. Praesent sapien massa, convallis a pellentesque nec, egestas non nisi. Sed porttitor lectus nibh. Nulla porttitor accumsan tincidunt. Proin eget tortor risus. Donec rutrum congue leo eget malesuada. Curabitur non nulla sit amet nisl tempus convallis quis ac lectus. Sed porttitor lectus nibh. Curabitur aliquet quam id dui posuere blandit. Mauris blandit aliquet elit, eget tincidunt nibh pulvinar a. Curabitur aliquet quam id dui posuere blandit. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla porttitor accumsan tincidunt. Pellentesque in ipsum id orci porta dapibus. Vivamus magna justo, lacinia eget consectetur sed, convallis at tellus. Praesent sapien massa, convallis a pellentesque nec, egestas non nisi.",
            ViewCount = 15,
            CategoryID = Guid.Parse("9019DD67-01E4-4435-A939-88AB3042C44A"),
            ImageID = Guid.Parse("D16A6EC7-8C50-4AB0-89A5-02B9A551F0FA"),
            CreatedBy = "Admin Test",
            CreatedDate = DateTime.Now,
            IsDeleted = false,
            UserID = Guid.Parse("CB94223B-CCB8-4F2F-93D7-0DF96A7F065C")
        },
        new New
        {

            NewID = Guid.Parse("FF859916-D03B-4291-8E99-B4311F2B9D3B"),
            Title = "Visual Studio Deneme Makalesi 1",
            Content = "Visual Studio Sed porttitor lectus nibh. Nulla porttitor accumsan tincidunt. Vivamus suscipit tortor eget felis porttitor volutpat. Praesent sapien massa, convallis a pellentesque nec, egestas non nisi. Sed porttitor lectus nibh. Nulla porttitor accumsan tincidunt. Proin eget tortor risus. Donec rutrum congue leo eget malesuada. Curabitur non nulla sit amet nisl tempus convallis quis ac lectus. Sed porttitor lectus nibh. Curabitur aliquet quam id dui posuere blandit. Mauris blandit aliquet elit, eget tincidunt nibh pulvinar a. Curabitur aliquet quam id dui posuere blandit. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla porttitor accumsan tincidunt. Pellentesque in ipsum id orci porta dapibus. Vivamus magna justo, lacinia eget consectetur sed, convallis at tellus. Praesent sapien massa, convallis a pellentesque nec, egestas non nisi.",
            ViewCount = 15,
            CategoryID = Guid.Parse("9019DD67-01E4-4435-A939-88AB3042C44A"),
            ImageID = Guid.Parse("D16A6EC7-8C50-4AB0-89A5-02B9A551F0FA"),
            CreatedBy = "Admin Test",
            CreatedDate = DateTime.Now,
            IsDeleted = false,
            UserID = Guid.Parse("CB94223B-CCB8-4F2F-93D7-0DF96A7F065C")
        });
    }
}
}
