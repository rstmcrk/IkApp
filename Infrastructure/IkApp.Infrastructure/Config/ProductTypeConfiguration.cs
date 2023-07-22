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
    public class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder
                .HasOne(x => x.EmplooyeLoanedItem)
                .WithMany(y => y.ProductTypes)
                .HasForeignKey(x => x.EmplooyeLoanedItemId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
