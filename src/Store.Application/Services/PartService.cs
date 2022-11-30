using Store.Application.DTO;
using Store.Application.DTO.Part;
using Store.Application.Mapper;
using Store.Application.Services.Contracts;
using Store.Core.Entities;
using Store.DataAccess.Repositories.Contracts;

namespace Store.Application.Services
{
    internal class PartService : IPartService
    {
        private readonly IPartRepository _partRepository;
        private readonly IProductRepository _productRepository;
        private readonly IProductPartRepository _productPartRepository;

        public PartService(IPartRepository partRepository, IProductRepository productRepository, IProductPartRepository productPartRepository)
        {
            _partRepository = partRepository;
            _productRepository = productRepository;
            _productPartRepository = productPartRepository;
        }

        public async Task<CreatePartResponseDto> CreateAsync(CreatePartDto createPartDto, CancellationToken cancellationToken = default)
        {
            var part = PartMapper.MapCreatePartDtoToEntity(createPartDto);

            var newPart = await _partRepository.AddAsync(part);
            return PartMapper.MapEntityToCreatePartResponseDto(newPart);
        }

        public async Task<BaseResponseDto> DeleteAsync(int partId, CancellationToken cancellationToken = default)
        {
            var part = await _partRepository.GetFirstAsync(p => p.Id == partId);

            var deletedPart = await _partRepository.DeleteAsync(part);
            return BaseMapper<Part>.MapEntityToBaseResponseDto(deletedPart);
        }

        public async Task<IEnumerable<PartResponseDto>> GetAllByProductId(int productId, CancellationToken cancellationToken = default)
        {
            await _productRepository.GetFirstAsync(pr => pr.Id == productId);

            var selectedProductParts = await _productPartRepository.GetAllAsync(pp => pp.ProductId == productId);
            
            return selectedProductParts.Select(pp => PartMapper.MapEntityToPartResponseDto(pp.Part!));
        }

        public async Task<UpdatePartResponseDto> UpdateAsync(int partId, UpdatePartDto updatePartDto, CancellationToken cancellationToken = default)
        {
            await _partRepository.GetFirstAsync(pa => pa.Id == partId);

            var newPart = PartMapper.MapUpdatePartDtoToEntity(partId, updatePartDto);
            var affectedPart = await _partRepository.UpdateAsync(newPart);

            return PartMapper.MapEntityToUpdatePartResponseDto(affectedPart);
        }
    }
}
