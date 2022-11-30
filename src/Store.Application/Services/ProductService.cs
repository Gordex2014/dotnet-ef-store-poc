using Store.Application.DTO;
using Store.Application.DTO.Product;
using Store.Application.Mapper;
using Store.Application.Services.Contracts;
using Store.Core.Entities;
using Store.DataAccess.Repositories.Contracts;

namespace Store.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IImageRepository _imageRepository;

        public ProductService(IProductRepository productRepository, IImageRepository imageRepository)
        {
            _productRepository = productRepository;
            _imageRepository = imageRepository;
        }

        public async Task<CreateProductResponseDto> CreateAsync(CreateProductDto createProductDto, CancellationToken cancellationToken = default)
        {
            var newProduct = ProductMapper.MapCreateProductDtoToEntity(createProductDto);

            var createdProduct = await _productRepository.AddAsync(newProduct);
            return ProductMapper.MapEntityToCreateProductResponseDto(createdProduct);
        }

        public async Task<BaseResponseDto> DeleteAsync(int productId, CancellationToken cancellationToken = default)
        {
            var product = await _productRepository.GetFirstAsync(p => p.Id == productId);

            var imagesDeleted = await _imageRepository.DeleteManyAsync(i => i.ProductId == productId);
            var deletedProduct = await _productRepository.DeleteAsync(product);
            return BaseMapper<Product>.MapEntityToBaseResponseDto(deletedProduct);
        }

        // FIXME: Add pagination
        public async Task<IEnumerable<ProductResponseDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var response = new List<ProductResponseDto>();
            var products = await _productRepository.GetAllAsync(p => true);

            foreach (var product in products)
            {
                response.Add(ProductMapper.MapEntitiesToProductResponseDto(product));
            }

            return response;
        }

        public async Task<ProductCompleteResponseDto> GetByIdAsync(int productId, CancellationToken cancellationToken = default)
        {
            var product = await _productRepository.GetFirstAsync(p => p.Id == productId);

            return ProductMapper.MapEntitiesToProductCompleteResponseDto(product);
        }

        public async Task<UpdateProductResponseDto> UpdateAsync(int productId, UpdateProductDto updateProductDto, CancellationToken cancellationToken = default)
        {
            await _productRepository.GetFirstAsync(p => p.Id == productId);

            var newProduct = ProductMapper.MapUpdateProductDtoToEntity(productId, updateProductDto);
            var updatedProduct = await _productRepository.UpdateAsync(newProduct);
            return ProductMapper.MapEntityToUpdateProductResponseDto(updatedProduct);
        }
    }
}
