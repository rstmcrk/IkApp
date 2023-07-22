using IkApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkApp.Infrastructure.Config
{
    public class SectionConfiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder
                .HasOne(x => x.SectionUser)
                .WithOne(y => y.Section)
                .HasForeignKey<Section>(x => x.SectionUserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
