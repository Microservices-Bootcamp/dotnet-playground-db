using Microsoft.EntityFrameworkCore;
using Products.Controllers.Dtos;

namespace Products.Database
{
    public class PlaygroundDb : DbContext
    {
        DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("User ID = admin; Password = admdotin; Host = localhost; Port = 5434;Database = ef_example_db; Pooling = true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Product>().HasKey(x => x.Sku);
        }
    }
}

