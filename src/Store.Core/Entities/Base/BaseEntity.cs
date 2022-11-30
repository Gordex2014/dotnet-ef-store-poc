namespace Store.Core.Entities.Base
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public bool Active { get; set; } = true;
    }
}
