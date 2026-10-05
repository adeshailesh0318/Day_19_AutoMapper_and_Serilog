using Day19_AutoMapper_Serilog.Models;
using Microsoft.EntityFrameworkCore;

namespace Day19_AutoMapper_Serilog.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}