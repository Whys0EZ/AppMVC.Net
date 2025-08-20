// using System.Data.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AppMVC.Net.Models.Contacts;
using AppMVC.Net.Models.FaultCodes;

namespace AppMVC.Net.Models
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure entity relationships, indexes, etc. here if needed
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // Example: Set table name to match the entity name
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    // Skip AspNet tables
                    entityType.SetTableName(tableName.Substring(6));
                }
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        // public DbSet<Product> Products { get; set; }
        // public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; } // DbSet for Contact model

        public DbSet<Fault_Code> FaultCodes { get; set; } // DbSet for FaultCode model
    }
}
