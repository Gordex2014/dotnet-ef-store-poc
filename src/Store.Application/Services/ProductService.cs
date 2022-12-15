using Microsoft.VisualBasic;
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

        public async Task<IEnumerable<int>> UpdateMultipleProductStockAsync(BuyCartProductsDto updateMultipleProductsDto)
        {
            var productIds = updateMultipleProductsDto.Products!.Select(p => p.ProductId).ToList();

            var products = await _productRepository.GetAllAsync(p => productIds.Contains(p.Id));

            if (products.Count < productIds.Count)
            {
                var matchedProducts = from id in productIds
                                      join product in products on id equals product.Id
                                      select product.Id;

                var nonMatchedIds = productIds.Where(l => !matchedProducts.Contains(l)).ToList();

                var errorMessage = nonMatchedIds.Count > 1 ? $"Products with ids {string.Join(",", nonMatchedIds)} non registered" : $"Product with id {nonMatchedIds.FirstOrDefault()} not found";

                throw new Exception(errorMessage);
            }

            // Check if stock is available
            var newProductInfo = from productToUpdate in updateMultipleProductsDto.Products
                                 join product in products on productToUpdate.ProductId equals product.Id
                                 select new
                                 {
                                     ProductId = productToUpdate.ProductId,
                                     QuantityRemaining = product.Stock - productToUpdate.Quantity
                                 };


            foreach (var productInfo in newProductInfo)
            {
                if (productInfo.QuantityRemaining < 0)
                {
                    throw new Exception($"Not enough stock for product {productInfo.ProductId}");
                }
            }

            foreach (var product in products)
            {
                var quantity = updateMultipleProductsDto.Products!.First(p => p.ProductId == product.Id).Quantity;
                product.Stock -= quantity;
            }

            await _productRepository.UpdateManyAsync(products);

            return productIds;
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

        public async Task<IEnumerable<Product>> GetMultipleAsync(IEnumerable<int> productIds, CancellationToken cancellationToken = default)
        {
            var products = await _productRepository.GetAllAsync(p => productIds.Contains(p.Id));
            return products;
        }
    }
}
