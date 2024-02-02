using H5API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace H5API.Data
{
    public class H5DbContext : IdentityDbContext<User, Role, Guid>
    {
        public readonly IConfiguration _configuration;
        public DbSet<Store> Stores { get; set; }
        public DbSet<Category> Categories { get; set; }

        public H5DbContext(DbContextOptions<H5DbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        //Local Database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("LocalDb"));
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}