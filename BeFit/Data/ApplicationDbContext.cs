using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BeFit.Models;

namespace BeFit.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            string ADMIN_USER_ID = "02174cf0–9412–4cfe-afbf-59f706d72cf6";
            string ADMIN_ROLE_ID = "341743f0-asd2–42de-afbf-59kmkkmk72cf6";

            // seed admin role
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "SuperAdmin",
                NormalizedName = "SUPERADMIN",
                Id = ADMIN_ROLE_ID,
                ConcurrencyStamp = ADMIN_ROLE_ID
            });

            // seed admin user
            var adminUser = new IdentityUser
            {
                Id = ADMIN_USER_ID,
                Email = "admin@gmail.com",
                EmailConfirmed = true,
                UserName = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM"
            };

            // set admin user password
            PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
            adminUser.PasswordHash = ph.HashPassword(adminUser, "Adminadmin1!");

            //seed user
            builder.Entity<IdentityUser>().HasData(adminUser);

            // give admin role to admin user
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ADMIN_ROLE_ID,
                UserId = ADMIN_USER_ID
            });
        }
        public DbSet<BeFit.Models.TrainingPlan>? TrainingPlan { get; set; }
        public DbSet<BeFit.Models.TrainingDay>? TrainingDay { get; set; }
        public DbSet<BeFit.Models.Exercise>? Exercise { get; set; }
        public DbSet<BeFit.Models.TrainingDayExercise>? TrainingDayExercise { get; set; }
        public DbSet<BeFit.Models.WeightGoal>? WeightGoal { get; set; }
        public DbSet<BeFit.Models.WeightMeasurement>? WeightMeasurement { get; set; }
        public DbSet<BeFit.Models.User>? User { get; set; }
    }
}