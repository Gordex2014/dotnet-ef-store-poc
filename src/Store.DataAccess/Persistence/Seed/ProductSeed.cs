using Microsoft.EntityFrameworkCore;
using Store.Core.Entities;
using Store.Core.Enums;

namespace Store.DataAccess.Persistence.Seed
{
    public static class ProductSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            var products = new List<Product>
            {
                new Product()
                {
                    Id = 1,
                    Title = "Budget Computer",
                    Slug = "budget-computer",
                    Price = 500.00m,
                    Currency = Currencies.USD,
                    Stock = 4,
                    Description = "A budget PC, can run a bunch of games in medium quality"
                },
                new Product()
                {
                    Id = 2,
                    Title = "Asus Keyboard",
                    Slug = "asus-keyboard",
                    Price = 50.00m,
                    Currency = Currencies.USD,
                    Stock = 5,
                    Description = "Asus keyboard for productivity"
                },
                new Product()
                {
                    Id = 3,
                    Title = "Gaming PC",
                    Slug = "gaming-pc",
                    Price = 1900.00m,
                    Currency = Currencies.USD,
                    Stock = 2,
                    Description = "A gaming desktop PC that can run most of the games"
                }
            };

            builder.Entity<Product>().HasData(products);
        }
    }
}
