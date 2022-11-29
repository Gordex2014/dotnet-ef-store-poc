using Store.Core.Entities;
using Store.DataAccess.Persistence;
using Store.DataAccess.Repositories.Contracts;

namespace Store.DataAccess.Repositories
{
    public class PartRepository : BaseRepository<Part>, IPartRepository
    {
        public PartRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
