using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Core.Entities;

namespace Store.DataAccess.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("products");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("product_id")
                .IsRequired();

            builder.Property(p => p.Title)
                .HasColumnName("product_title")
                .IsRequired();

            builder.Property(p => p.Slug)
                .HasColumnName("product_slug")
                .IsRequired();

            builder.Property(p => p.Price)
                .HasColumnName("product_price")
                .IsRequired();

            builder.Property(p => p.Currency)
                .HasColumnName("product_currency")
                .HasConversion<string>()
                .IsRequired();

            builder.Property(p => p.Stock)
                .HasColumnName("product_stock")
                .IsRequired();

            builder.Property(p => p.Description)
                .HasColumnName("product_description");

            builder.HasMany(p => p.Images)
                .WithOne(i => i.Product)
                .HasForeignKey(i => i.ProductId);

            builder.HasMany(p => p.ProductParts)
                .WithOne(pp => pp.Product)
                .HasForeignKey(pp => pp.ProductId);
        }
    }
}
