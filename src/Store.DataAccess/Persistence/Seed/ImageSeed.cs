using Microsoft.EntityFrameworkCore;
using Store.Core.Entities;

namespace Store.DataAccess.Persistence.Seed
{
    public static class ImageSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            var images = new List<Image>
            {
                new Image()
                {
                    Id = 1,
                    ProductId = 1,
                    Url = "https://cdn.thewirecutter.com/wp-content/media/2021/03/cheap-desktop-pc-2048px-dell-inspiron.jpg",
                },
                new Image()
                {
                    Id = 2,
                    ProductId = 1,
                    Url = "https://rukminim1.flixcart.com/image/416/416/kcw9w280/cpu/t/7/t/home-desktop-series-budget-pc-pro-original-imaftwj5hkupvuyn.jpeg?q=70",
                },
                new Image()
                {
                    Id = 3,
                    ProductId = 2,
                    Url = "https://ae01.alicdn.com/kf/H73cf9845043d47308a6314fc29e498a9a/US-English-laptop-keyboard-for-ASUS-vivobook-14-X409-x409fa-X409FB-X409DA-X409BA-QWERTY-notebook-pc.jpg_Q90.jpg_.webp",
                },
                new Image()
                {
                    Id = 4,
                    ProductId = 3,
                    Url = "https://cdn.shopify.com/s/files/1/0061/7594/8882/products/SY-PCBuild-Frost.png?v=1658745338",
                }
            };

            builder.Entity<Image>().HasData(images);
        }
    }
}
