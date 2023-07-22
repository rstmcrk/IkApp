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
    public class EmployeeDetailConfiguration : IEntityTypeConfiguration<EmployeeDetail>
    {
        public void Configure(EntityTypeBuilder<EmployeeDetail> builder)
        {
            builder
                .HasOne(x => x.EmployeeDetailUser)
                .WithOne(y => y.EmployeeDetail)
                .HasForeignKey<EmployeeDetail>(x => x.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
