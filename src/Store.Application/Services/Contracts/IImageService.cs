using Store.Application.DTO;
using Store.Application.DTO.Image;

namespace Store.Application.Services.Contracts
{
    public interface IImageService
    {
        Task<CreateImageResponseDto> CreateAsync(CreateImageDto createImageDto, CancellationToken cancellationToken = default);
        Task<UpdateImageResponseDto> UpdateAsync(int imageId, UpdateImageDto updateImageDto, CancellationToken cancellationToken = default);
        Task<IEnumerable<ImageResponseDto>> GetAllByProductId(int productId, CancellationToken cancellationToken = default);
        Task<BaseResponseDto> DeleteAsync(int imageId, CancellationToken cancellationToken = default);
    }
}
