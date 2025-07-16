using DemoMVC.Models;
using Microsoft.EntityFrameworkCore;


namespace DemoMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Student> Student { get; set; }
      public DbSet<DaiLy> DaiLies { get; set; } = null!;
        public DbSet<HeThongPhanPhoi> HeThongPhanPhois { get; set; } = null!;

        // Add other DbSets for your models here when needed
        // Example:
        // public DbSet<Movie> Movies { get; set; }
    }
}