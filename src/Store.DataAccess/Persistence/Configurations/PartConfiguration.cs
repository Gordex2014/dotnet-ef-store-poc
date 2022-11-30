using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Core.Entities;

namespace Store.DataAccess.Persistence.Configurations
{
    public class PartConfiguration : IEntityTypeConfiguration<Part>
    {
        public void Configure(EntityTypeBuilder<Part> builder)
        {
            builder.ToTable("parts");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("part_id")
                .IsRequired();

            builder.Property(i => i.Active)
                .HasColumnName("part_active")
                .IsRequired();

            builder.Property(p => p.Name)
                .HasColumnName("part_name")
                .IsRequired();

            builder.Property(p => p.Price)
                .HasColumnName("part_price")
                .IsRequired();

            builder.Property(p => p.Currency)
                .HasColumnName("part_currency")
                .HasConversion<string>()
                .IsRequired();

            builder.Property(p => p.Stock)
                .HasColumnName("part_stock")
                .IsRequired();

            builder.Property(p => p.Unit)
                .HasColumnName("part_unit")
                .IsRequired();

            builder.Property(p => p.Description)
                .HasColumnName("part_description");

            builder.HasMany(p => p.ProductParts)
                .WithOne(pp => pp.Part)
                .HasForeignKey(pp => pp.PartId);
        }
    }
}
