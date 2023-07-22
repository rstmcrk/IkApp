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
    public class EmplooyeLoanedItemConfiguration : IEntityTypeConfiguration<EmplooyeLoanedItem>
    {
        public void Configure(EntityTypeBuilder<EmplooyeLoanedItem> builder)
        {
            builder
                .HasOne(x => x.User)
                .WithMany(y => y.EmplooyeLoanedItems)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
