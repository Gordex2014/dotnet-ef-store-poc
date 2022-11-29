using Store.Application.DTO.Part;
using Store.Core.Entities;

namespace Store.Application.Mapper
{
    public static class PartMapper
    {
        public static Part MapCreatePartDtoToEntity(CreatePartDto createPartDto)
        {
            return new Part
            {
                Name = createPartDto.Name,
                Price = createPartDto.Price,
                Currency = createPartDto.Currency,
                Stock = createPartDto.Stock,
                Unit = createPartDto.Unit,
                Description = createPartDto.Description,
            };
        }

        public static CreatePartResponseDto MapEntityToCreatePartResponseDto(Part part)
        {
            return new CreatePartResponseDto
            {
                Id = part.Id,
            };
        }

        public static Part MapUpdatePartDtoToEntity(int partId, UpdatePartDto updatePartDto)
        {
            return new Part
            {
                Id = partId,
                Name = updatePartDto.Name,
                Price = updatePartDto.Price,
                Currency = updatePartDto.Currency,
                Stock = updatePartDto.Stock,
                Unit = updatePartDto.Unit,
                Description = updatePartDto.Description,
            };
        }

        public static UpdatePartResponseDto MapEntityToUpdatePartResponseDto(Part part)
        {
            return new UpdatePartResponseDto
            {
                Id = part.Id,
            };
        }

        public static PartResponseDto MapEntityToPartResponseDto(Part part)
        {
            return new PartResponseDto
            {
                Id = part.Id,
                Name = part.Name,
                Price = part.Price,
                Currency = part.Currency,
                Stock = part.Stock,
                Unit = part.Unit,
                Description = part.Description,
            };
        }
    }
}
