using EduO.Core.Models;
using EduO.ORM.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EduO.ORM
{
    public class ApplicationDbContext : IdentityDbContext<User,Role,string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Models Configurations
            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            modelBuilder.Entity<User>().ToTable("Users", "security");
            modelBuilder.Entity<Role>().ToTable("Roles", "security");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "security");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "security");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "security");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "security");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "security");

        }

        public DbSet<Grade> Grades { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}