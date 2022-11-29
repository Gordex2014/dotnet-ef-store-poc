using Store.Application.DTO;
using Store.Application.DTO.Image;
using Store.Core.Entities;

namespace Store.Application.Mapper
{
    public static class ImageMapper
    {
        public static Image MapCreateImageDtoToEntity(CreateImageDto createImageDto)
        {
            return new Image
            {
                Url = createImageDto.Url,
                ProductId = createImageDto.ProductId,
            };
        }

        public static CreateImageResponseDto MapEntityToCreateImageResponseDto(Image image)
        {
            return new CreateImageResponseDto
            {
                Id = image.Id,
            };
        }

        public static Image MapUpdateImageDtoToEntity(int imageId, UpdateImageDto updateImageDto)
        {
            return new Image
            {
                Id = imageId,
                Url = updateImageDto.Url,
                ProductId = updateImageDto.ProductId,
            };
        }

        public static UpdateImageResponseDto MapEntityToUpdateImageResponseDto(Image image)
        {
            return new UpdateImageResponseDto
            {
                Id = image.Id,
            };
        }

        public static ImageResponseDto MapEntityToImageResponseDto(Image image)
        {
            return new ImageResponseDto
            {
                Id = image.Id,
                Url = image.Url,
            };
        }
    }
}
