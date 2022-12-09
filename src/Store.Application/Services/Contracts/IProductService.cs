using Store.Application.DTO;
using Store.Application.DTO.Product;
using Store.Core.Entities;

namespace Store.Application.Services.Contracts
{
    public interface IProductService
    {
        Task<CreateProductResponseDto> CreateAsync(CreateProductDto createProductDto, CancellationToken cancellationToken = default);
        Task<UpdateProductResponseDto> UpdateAsync(int productId, UpdateProductDto updateProductDto, CancellationToken cancellationToken = default);
        Task<IEnumerable<ProductResponseDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<ProductCompleteResponseDto> GetByIdAsync(int productId, CancellationToken cancellationToken = default);
        Task<BaseResponseDto> DeleteAsync(int productId, CancellationToken cancellationToken = default);
        Task<IEnumerable<Product>> GetMultipleAsync(IEnumerable<int> productIds, CancellationToken cancellationToken = default);
        Task<IEnumerable<int>> UpdateMultipleProductStockAsync(BuyCartProductsDto updateMultipleProductsDto);
    }
}
