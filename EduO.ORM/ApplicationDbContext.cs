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


            //one-to-one relation using FluentApi
            // added using Convention approach
            //The easiest way to configure this type of relationship is to use by the Convention approach,
            modelBuilder.Entity<Teacher>().HasOne(e => e.User).WithOne(s => s.Teacher).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Student>().HasOne(e => e.User).WithOne(s => s.Student).OnDelete(DeleteBehavior.NoAction);


            //one-to-many relation using FluentApi
            modelBuilder.Entity<Grade>().HasMany(e => e.Students).WithOne(s => s.Grade).HasForeignKey(s => s.GradeId);
            modelBuilder.Entity<Grade>().HasMany(e => e.Courses).WithOne(s => s.Grade).HasForeignKey(s => s.GradeId);
            modelBuilder.Entity<CourseType>().HasMany(e => e.Courses).WithOne(s => s.CourseType).HasForeignKey(s => s.CourseTypeId);


            //many-To-many relation using FluentApi  
            modelBuilder.Entity<GradesTeachers>().HasKey(s => new { s.GrdaeId, s.TeacherId });
            modelBuilder.Entity<GradesTeachers>().HasOne(ss => ss.Grade).WithMany(s => s.GradesTeachers).HasForeignKey(ss => ss.GrdaeId);
            modelBuilder.Entity<GradesTeachers>().HasOne(ss => ss.Teacher).WithMany(s => s.GradesTeachers).HasForeignKey(ss => ss.TeacherId);

            modelBuilder.Entity<StudentsTeachers>().HasKey(s => new { s.StudentId, s.TeacherId });
            modelBuilder.Entity<StudentsTeachers>().HasOne(ss => ss.Teacher).WithMany(s => s.StudentsTeachers).HasForeignKey(ss => ss.TeacherId);
            modelBuilder.Entity<StudentsTeachers>().HasOne(ss => ss.Student).WithMany(s => s.StudentsTeachers).HasForeignKey(ss => ss.StudentId);

            modelBuilder.Entity<StudentsCourses>().HasKey(s => new { s.StudentId, s.CourseId });
            modelBuilder.Entity<StudentsCourses>().HasOne(ss => ss.Course).WithMany(s => s.StudentsCourses).HasForeignKey(ss => ss.CourseId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<StudentsCourses>().HasOne(ss => ss.Student).WithMany(s => s.StudentsCourses).HasForeignKey(ss => ss.StudentId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TeacherCourses>().HasKey(s => new { s.TeacherId, s.CourseId });
            modelBuilder.Entity<TeacherCourses>().HasOne(ss => ss.Course).WithMany(s => s.TeacherCourses).HasForeignKey(ss => ss.CourseId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<TeacherCourses>().HasOne(ss => ss.Teacher).WithMany(s => s.TeacherCourses).HasForeignKey(ss => ss.TeacherId).OnDelete(DeleteBehavior.NoAction);

        }

        public DbSet<ExClass> ExClass { get; set; }

        public DbSet<Grade> Grades { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseType> CourseTypes { get; set; }
        public DbSet<Fee> Fees { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<GradesTeachers> GradesTeachers { get; set; }
        public DbSet<StudentsTeachers> StudentsTeachers { get; set; }
        public DbSet<StudentsCourses> StudentsCourses { get; set; }
        public DbSet<TeacherCourses> TeacherCourses { get; set; }
    }
}