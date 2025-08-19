using System.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace AppMVC.Net.Models
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure entity relationships, indexes, etc. here if needed
            // foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            // {
            //     // Example: Set table name to match the entity name
            //     var tableName = entityType.GetTableName();
            //     if(tableName.StartsWith("AspNet"))
            //     {
            //         // Skip AspNet tables
            //         entityType.SetTableName(tableName.Substring(6));
            //     }
            // }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        // public DbSet<Product> Products { get; set; }
        // public DbSet<Category> Categories { get; set; }
    }
}
