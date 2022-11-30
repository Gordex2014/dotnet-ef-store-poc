using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Core.Entities;

namespace Store.DataAccess.Persistence.Configurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.ToTable("images");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Id)
                .HasColumnName("image_id")
                .IsRequired();

            builder.Property(i => i.Active)
                .HasColumnName("image_active")
                .IsRequired();

            builder.Property(i => i.Url)
                .HasColumnName("image_url")
                .IsRequired();

            builder.Property(i => i.ProductId)
                .HasColumnName("image_product_id")
                .IsRequired();

            builder.HasOne(i => i.Product)
                .WithMany(p => p.Images)
                .HasForeignKey(i => i.ProductId);
        }
    }
}
