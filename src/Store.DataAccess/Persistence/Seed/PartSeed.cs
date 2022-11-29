using Microsoft.EntityFrameworkCore;
using Store.Core.Entities;
using Store.Core.Enums;

namespace Store.DataAccess.Persistence.Seed
{
    public static class PartSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            var parts = new List<Part>
            {
                new Part()
                {
                    Id = 1,
                    Name = "ASUS Cooler",
                    Price = 30.00m,
                    Stock = 30,
                    Currency = Currencies.USD,
                    Unit = "piece",
                    Description = "A simple ASUS cooler",
                },
                new Part()
                {
                    Id = 2,
                    Name = "Corsair RAM",
                    Price = 56.00m,
                    Currency = Currencies.USD,
                    Stock = 25,
                    Unit = "piece",
                    Description = "A simple RAM module",
                },
                new Part()
                {
                    Id = 3,
                    Name = "Intel Core i7",
                    Price = 500.00m,
                    Currency = Currencies.USD,
                    Stock = 9,
                    Unit = "piece",
                    Description = "Intel Core i7 8th gen",
                },
                new Part()
                {
                    Id = 4,
                    Name = "Monitor Stand",
                    Price = 40.00m,
                    Currency = Currencies.USD,
                    Stock = 15,
                    Unit = "piece",
                    Description = "Monitor stand, just to seel in a combo",
                },
            };

            builder.Entity<Part>().HasData(parts);
        }
    }
}
