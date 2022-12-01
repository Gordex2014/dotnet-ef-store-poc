using Store.Application.Utils;

namespace Store.Tests.Application.Utils
{
    public class SlugUtilsTest
    {
        private const string PRODUCT_1 = "Corsair Gaming Mouse";
        private const string PRODUCT_2 = "A rare/ product name";

        [Fact]
        public void CreateSlug_WhenCalled_ShouldReturnACorrectValue()
        {
            var product1Slug = SlugUtils.CreateSlug(PRODUCT_1);
            var product2Slug = SlugUtils.CreateSlug(PRODUCT_2);

            Assert.Equal("corsair-gaming-mouse", product1Slug);
            Assert.Equal("a-rare-product-name", product2Slug);
        }
    }
}
