using Microsoft.EntityFrameworkCore;
using Store.Core.Entities;
using Store.DataAccess.Persistence.Seed;
using System.Reflection;

namespace Store.DataAccess.Persistence
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product>? Products { get; set; }
        public DbSet<Part>? Parts { get; set; }
        public DbSet<Image>? Images { get; set; }
        public DbSet<ProductPart>? ProductsParts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Seed data
            PartSeed.Seed(modelBuilder);
            ImageSeed.Seed(modelBuilder);
            ProductSeed.Seed(modelBuilder);
            ProductPartSeed.Seed(modelBuilder);

        }
    }
}
