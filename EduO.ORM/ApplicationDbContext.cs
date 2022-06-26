using EduO.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace EduO.ORM
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Grade> Grades { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}