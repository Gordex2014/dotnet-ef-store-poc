using Store.Core.Entities;
using Store.DataAccess.Persistence;
using Store.DataAccess.Repositories.Contracts;

namespace Store.DataAccess.Repositories
{
    public class ImageRepository : BaseRepository<Image>, IImageRepository
    {
        public ImageRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
