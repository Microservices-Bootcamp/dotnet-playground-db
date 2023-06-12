using Microsoft.EntityFrameworkCore;
using Products.Controllers.Dtos;

namespace Products.Database
{
    public class PlaygroundDb : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public PlaygroundDb(DbContextOptions<PlaygroundDb> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ef_example_db");
            modelBuilder.Entity<Product>().HasData(new List<Product> { { new Product { Name = "Product A", Price = 100, Sku = "PA" } } });
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }

    public static class DbExtension
    {
        public static IServiceCollection AddPlayGroundDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PlaygroundDb>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("Postgres"));
            });
            return services;
        }
    }
}

