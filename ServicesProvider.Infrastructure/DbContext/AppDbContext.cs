using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ServicesProvider.Core.Domain.Entities;
using ServicesProvider.Core.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesProvider.Infrastructure.DbContext
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<CoreActivity> CoreActivities { get; set; }

        public virtual DbSet<AppServices> Services { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().HasData(SharedData.SeedCategories);
            builder.Entity<CoreActivity>().HasData(SharedData.SeedCoreActivities);
            builder.Entity<AppServices>().HasData(SharedData.SeedServices);

            //add Roles
            //builder.Entity<AppRole>().HasData(new AppRole { Id = Guid.NewGuid(), Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = Guid.NewGuid().ToString() });
            //builder.Entity<AppRole>().HasData(new AppRole { Id = Guid.NewGuid(), Name = "Manager", NormalizedName = "MANAGER", ConcurrencyStamp=Guid.NewGuid().ToString() });
            //builder.Entity<AppRole>().HasData(new AppRole { Id = Guid.NewGuid(), Name = "User", NormalizedName = "USER", ConcurrencyStamp = Guid.NewGuid().ToString() });

            
           

       

           
        }
    }
}
