using Store.Core.Entities.Base;
using Store.Core.Enums;

namespace Store.Core.Entities
{
    public class Product : BaseEntity
    {
        public string? Title { get; set; }
        public string? Slug { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public Currencies Currency { get; set; }
        public int Stock { get; set; }
        public IEnumerable<Image>? Images { get; set; }
        public IEnumerable<ProductPart>? ProductParts { get; set; }
    }
}
