using System;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Controllers.Dtos;

namespace Products.Database
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.Sku);
            builder.Property(x => x.Sku).IsRequired().HasColumnName("sku");
            builder.Property(x => x.Name).IsRequired().HasColumnName("name");
            builder.Property(x => x.Price).IsRequired().HasColumnName("price");
        }
    }
}

