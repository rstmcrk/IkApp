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
    internal class DayOffConfiguration : IEntityTypeConfiguration<DayOff>
    {
        public void Configure(EntityTypeBuilder<DayOff> builder)
        {
            builder
                .HasOne(x => x.User)
                .WithOne(y => y.DayOff)
                .HasForeignKey<DayOff>(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
