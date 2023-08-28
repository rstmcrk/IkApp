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
    public class JobConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder
                .HasOne(x => x.JobUser)
                .WithMany(y => y.Jobs)
                .HasForeignKey(x => x.JobUserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
