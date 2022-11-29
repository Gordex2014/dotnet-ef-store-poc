using Store.Core.Entities.Base;

namespace Store.Core.Entities
{
    public class Image : BaseEntity
    {
        public string? Url { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
