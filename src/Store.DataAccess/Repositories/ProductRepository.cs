using Store.Core.Entities;
using Store.DataAccess.Persistence;
using Store.DataAccess.Repositories.Contracts;

namespace Store.DataAccess.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
