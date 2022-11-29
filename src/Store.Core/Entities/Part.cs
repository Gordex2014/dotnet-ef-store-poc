using Store.Core.Entities.Base;
using Store.Core.Enums;

namespace Store.Core.Entities
{
    public class Part : BaseEntity
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public Currencies Currency { get; set; }
        public int Stock { get; set; }
        public string? Unit { get; set; }
        public string? Description { get; set; }
        public IEnumerable<ProductPart>? ProductParts { get; set; }
    }
}
