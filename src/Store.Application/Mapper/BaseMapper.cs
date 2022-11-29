using Store.Application.DTO;
using Store.Core.Entities.Base;

namespace Store.Application.Mapper
{
    public static class BaseMapper<TEntity> where TEntity : BaseEntity
    {
        public static BaseResponseDto MapEntityToBaseResponseDto(TEntity entity)
        {
            return new BaseResponseDto
            {
                Id = entity.Id,
            };
        }
    }
}
