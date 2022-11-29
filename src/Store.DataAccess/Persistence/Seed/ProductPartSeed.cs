using Microsoft.EntityFrameworkCore;
using Store.Core.Entities;

namespace Store.DataAccess.Persistence.Seed
{
    public static class ProductPartSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            var productPart = new List<ProductPart>
            {
                new ProductPart()
                {
                    Id = 1,
                    PartId = 1,
                    ProductId = 1,
                    PartsRequired = 1,
                },
                new ProductPart()
                {
                    Id = 2,
                    PartId = 2,
                    ProductId = 1,
                    PartsRequired = 2,
                },
            };

            builder.Entity<ProductPart>().HasData(productPart);
        }
    }
}
