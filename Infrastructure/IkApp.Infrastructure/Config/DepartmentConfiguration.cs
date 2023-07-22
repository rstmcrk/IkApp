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
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder
                .HasOne(x => x.DepartmentUser)
                .WithOne(y => y.Department)
                .HasForeignKey<Department>(x => x.DepartmentUserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
