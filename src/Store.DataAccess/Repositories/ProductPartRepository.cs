using Store.Core.Entities;
using Store.DataAccess.Persistence;
using Store.DataAccess.Repositories.Contracts;

namespace Store.DataAccess.Repositories
{
    public class ProductPartRepository : BaseRepository<ProductPart>, IProductPartRepository
    {
        public ProductPartRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
