using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Core.Entities;

namespace Store.DataAccess.Persistence.Configurations
{
    public class ProductPartConfiguration : IEntityTypeConfiguration<ProductPart>
    {
        public void Configure(EntityTypeBuilder<ProductPart> builder)
        {
            builder.ToTable("products_parts");

            builder.HasKey(pp => pp.Id);

            builder.Property(pp => pp.Id)
                .HasColumnName("product_part_id")
                .IsRequired();

            builder.Property(i => i.Active)
                .HasColumnName("product_part_active")
                .IsRequired();

            builder.Property(pp => pp.ProductId)
                .HasColumnName("product_part_product_id")
                .IsRequired();

            builder.Property(pp => pp.PartId)
                .HasColumnName("product_part_part_id")
                .IsRequired();

            builder.Property(pp => pp.PartsRequired)
                .HasColumnName("product_part_parts_required")
                .IsRequired();

            builder.HasOne(pp => pp.Product)
                .WithMany(p => p.ProductParts)
                .HasForeignKey(pp => pp.ProductId);

            builder.HasOne(pp => pp.Part)
                .WithMany(p => p.ProductParts)
                .HasForeignKey(pp => pp.PartId);
        }
    }
}
