
using lab1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace lab1.Data
{
    public class ToursDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<TourKind> TourKinds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder();

            // set path to current directory
            builder.SetBasePath(Directory.GetCurrentDirectory());

            // get configuration from file appsettings.json
            builder.AddJsonFile("appsettings.json");

            // create configuration
            var config = builder.Build();
           
            string connectionString = config.GetConnectionString("SQLConnection");

            var options = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;
        }
    }
}
