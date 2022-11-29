using Store.Application.DTO;
using Store.Application.DTO.Part;

namespace Store.Application.Services.Contracts
{
    public interface IPartService
    {
        Task<CreatePartResponseDto> CreateAsync(CreatePartDto createPartDto, CancellationToken cancellationToken = default);
        Task<UpdatePartResponseDto> UpdateAsync(int partId, UpdatePartDto updatePartDto, CancellationToken cancellationToken = default);
        Task<IEnumerable<PartResponseDto>> GetAllByProductId(int productId, CancellationToken cancellationToken = default);
        Task<BaseResponseDto> DeleteAsync(int partId, CancellationToken cancellationToken = default);
    }
}
