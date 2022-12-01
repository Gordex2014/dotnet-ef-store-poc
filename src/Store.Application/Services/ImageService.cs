using Store.Application.DTO;
using Store.Application.DTO.Image;
using Store.Application.Mapper;
using Store.Application.Services.Contracts;
using Store.Core.Entities;
using Store.DataAccess.Repositories.Contracts;

namespace Store.Application.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IProductRepository _productRepository;

        public ImageService(IImageRepository imageRepository, IProductRepository productRepository)
        {
            _imageRepository = imageRepository;
            _productRepository = productRepository;
        }

        public async Task<CreateImageResponseDto> CreateAsync(CreateImageDto createImageDto, CancellationToken cancellationToken = default)
        {
            await _productRepository.GetFirstAsync(p => p.Id == createImageDto.ProductId);

            var image = ImageMapper.MapCreateImageDtoToEntity(createImageDto);

            var newImage = await _imageRepository.AddAsync(image);

            var response = ImageMapper.MapEntityToCreateImageResponseDto(newImage);
            return response;
        }

        public async Task<BaseResponseDto> DeleteAsync(int imageId, CancellationToken cancellationToken = default)
        {
            var image = await _imageRepository.GetFirstAsync(i => i.Id == imageId);

            var deletedImage = await _imageRepository.DeleteAsync(image);

            return BaseMapper<Image>.MapEntityToBaseResponseDto(deletedImage);
        }

        public async Task<IEnumerable<ImageResponseDto>> GetAllByProductId(int productId, CancellationToken cancellationToken = default)
        {
            var images = await _imageRepository.GetAllAsync(i => i.ProductId == productId);
            var imagesResponse = images.Select(x => ImageMapper.MapEntityToImageResponseDto(x));

            return imagesResponse;
        }

        public async Task<UpdateImageResponseDto> UpdateAsync(int imageId, UpdateImageDto updateImageDto, CancellationToken cancellationToken = default)
        {
            var image = await _imageRepository.GetFirstAsync(i => i.Id == imageId);

            await _productRepository.GetFirstAsync(p => p.Id == image.ProductId);

            var imageToUpdate = ImageMapper.MapUpdateImageDtoToEntity(imageId, updateImageDto);

            var affectedImage = await _imageRepository.UpdateAsync(imageToUpdate);
            return ImageMapper.MapEntityToUpdateImageResponseDto(affectedImage);
        }
    }
}
