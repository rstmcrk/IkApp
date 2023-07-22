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
    public class AnnouncementConfiguration : IEntityTypeConfiguration<Announcement>
    {
        public void Configure(EntityTypeBuilder<Announcement> builder)
        {
            builder
                .HasOne(x => x.AnnouncementUser)
                .WithMany(y => y.Announcements)
                .HasForeignKey(x => x.AnnouncementUserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
