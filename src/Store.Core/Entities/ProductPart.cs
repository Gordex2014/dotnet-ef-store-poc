using Store.Core.Entities.Base;

namespace Store.Core.Entities
{
    public class ProductPart : BaseEntity
    {
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }
        public int PartId { get; set; }
        public virtual Part? Part { get; set; }
        public int PartsRequired { get; set; }
    }
}
