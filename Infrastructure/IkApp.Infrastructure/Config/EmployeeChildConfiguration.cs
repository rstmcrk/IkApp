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
    public class EmployeeChildConfiguration : IEntityTypeConfiguration<EmployeeChild>
    {
        public void Configure(EntityTypeBuilder<EmployeeChild> builder)
        {
            builder
                .HasOne(x => x.Parent)
                .WithMany(y => y.EmployeeChilds)
                .HasForeignKey(x => x.ParentUserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
