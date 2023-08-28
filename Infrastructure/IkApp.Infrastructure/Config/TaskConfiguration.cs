using IkApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = IkApp.Domain.Entities.Task;

namespace IkApp.Infrastructure.Config
{
    public class TaskConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder
               .HasOne(x => x.TaskUser)
               .WithOne(y => y.Task)
               .HasForeignKey<Task>(x => x.TaskUserId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
