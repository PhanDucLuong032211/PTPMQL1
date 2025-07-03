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

        // Add other DbSets for your models here when needed
        // Example:
        // public DbSet<Movie> Movies { get; set; }
    }
}