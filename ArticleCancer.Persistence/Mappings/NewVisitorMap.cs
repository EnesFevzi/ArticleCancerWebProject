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
    public class NewVisitorMap : IEntityTypeConfiguration<NewVisitor>
    {
        public void Configure(EntityTypeBuilder<NewVisitor> builder)
        {
            builder.HasKey(x => new { x.NewID, x.VisitorID });
        }
    }
}
