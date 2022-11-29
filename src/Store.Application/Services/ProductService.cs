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
        private readonly IProductPartRepository _productPartRepository;
        private readonly IPartRepository _partRepository;

        public ProductService(IProductRepository productRepository, IImageRepository imageRepository, IProductPartRepository productPartRepository, IPartRepository partRepository)
        {
            _productRepository = productRepository;
            _imageRepository = imageRepository;
            _productPartRepository = productPartRepository;
            _partRepository = partRepository;
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

            var deletedProduct = await _productRepository.DeleteAsync(product);
            return BaseMapper<Product>.MapEntityToBaseResponseDto(deletedProduct);
        }

        // FIXME: Add pagination
        public async Task<IEnumerable<ProductResponseDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var response = new List<ProductResponseDto>();
            var products = await _productRepository.GetAllAsync(p => true);
            var productsIds = products.Select(p => p.Id);

            var images = await _imageRepository.GetAllAsync(i => productsIds.Contains(i.ProductId));

            foreach (var product in products)
            {
                var productImages = images.Where(i => i.ProductId == product.Id);

                if (productImages.Any())
                {
                    response.Add(ProductMapper.MapEntitiesToProductResponseDto(product, productImages));
                }
                else
                {
                    response.Add(ProductMapper.MapEntitiesToProductResponseDto(product, Enumerable.Empty<Image>()));
                }
            }

            return response;
        }

        public async Task<ProductCompleteResponseDto> GetByIdAsync(int productId, CancellationToken cancellationToken = default)
        {
            var product = await _productRepository.GetFirstAsync(p => p.Id == productId);
            var imagesPerProduct = await _imageRepository.GetAllAsync(i => i.ProductId == productId);
            var partsPerProductIds = (await _productPartRepository.GetAllAsync(pp => pp.ProductId == productId)).Select(pp => pp.PartId);
            var partsPerProduct = await _partRepository.GetAllAsync(pa => partsPerProductIds.Contains(pa.Id));

            var images = imagesPerProduct.Any() ? imagesPerProduct : Enumerable.Empty<Image>();
            var parts = partsPerProduct.Any() ? partsPerProduct : Enumerable.Empty<Part>();

            return ProductMapper.MapEntitiesToProductCompleteResponseDto(product, images, parts);
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
