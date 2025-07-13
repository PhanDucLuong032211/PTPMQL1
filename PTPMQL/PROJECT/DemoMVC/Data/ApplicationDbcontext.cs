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
        public DbSet<DemoMVC.Models.HeThongPhanPhoi> HeThongPhanPhoi { get; set; } = default!;
        public DbSet<DemoMVC.Models.DaiLy> DaiLy { get; set; } = default!;

        // Add other DbSets for your models here when needed
        // Example:
        // public DbSet<Movie> Movies { get; set; }
    }
}