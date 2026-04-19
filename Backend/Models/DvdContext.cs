using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Backend.Models;
using System.IO;

namespace Backend.Context
{
    public class DvdContext : DbContext
    {
        public DbSet<Movie> Movies {get; set;}
        public DbSet<Admin> Admins {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
            
                var connectionString = config.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}