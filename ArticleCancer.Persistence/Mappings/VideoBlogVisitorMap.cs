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
    public class VideoBlogVisitorMap : IEntityTypeConfiguration<VideoBlogVisitor>
    {
        public void Configure(EntityTypeBuilder<VideoBlogVisitor> builder)
        {
            builder.HasKey(x => new { x.VideoBlogID, x.VisitorID });
        }
    }
}
