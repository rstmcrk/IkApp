using IkApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = IkApp.Domain.Entities.Task;

namespace IkApp.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, UserRole, string, IdentityUserClaim<string>, IdentityUserRole<string>,
                                        IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>(entity =>
            {
                entity.ToTable("Users");
            });
            builder.Entity<UserRole>(entity =>
            {
                entity.ToTable("UserRole");
            });

            builder.Entity<EmployeeChild>()
                .HasOne(x => x.Parent)
                .WithMany(y => y.EmployeeChilds)
                .HasForeignKey(x => x.ParentUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<EmployeeDetail>()
                .HasOne(x => x.EmployeeDetailUser)
                .WithOne(y => y.EmployeeDetail)
                .HasForeignKey<EmployeeDetail>(x => x.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<EmplooyeLoanedItem>()
                .HasOne(x => x.User)
                .WithMany(y => y.EmplooyeLoanedItems)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ProductType>()
                .HasOne(x => x.EmplooyeLoanedItem)
                .WithMany(y => y.ProductTypes)
                .HasForeignKey(x => x.EmplooyeLoanedItemId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Section>()
                .HasOne(x => x.SectionUser)
                .WithOne(y => y.Section)
                .HasForeignKey<Section>(x => x.SectionUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Task>()
                .HasOne(x => x.TaskUser)
                .WithOne(y => y.Task)
                .HasForeignKey<Task>(x => x.TaskUsrId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Address>()
                .HasOne(x => x.AddressUser)
                .WithOne(y => y.Address)
                .HasForeignKey<Address>(x => x.AddressUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Department>()
                .HasOne(x => x.DepartmentUser)
                .WithOne(y => y.Department)
                .HasForeignKey<Department>(x => x.DepartmentUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Announcement>()
                .HasOne(x => x.AnnouncementUser)
                .WithMany(y => y.Announcements)
                .HasForeignKey(x => x.AnnouncementUserId)
                .OnDelete(DeleteBehavior.Cascade);

        }

        public DbSet<Address> addresses { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<EmplooyeLoanedItem> EmplooyeLoanedItems { get; set; }
        public DbSet<EmployeeChild> EmployeeChildren { get; set; }
        public DbSet<EmployeeDetail> EmployeeDetails { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Task> Tasks { get; set; }

    }
}
