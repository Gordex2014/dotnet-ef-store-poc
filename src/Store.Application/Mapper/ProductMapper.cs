using Store.Application.DTO.Product;
using Store.Application.Utils;
using Store.Core.Entities;

namespace Store.Application.Mapper
{
    public static class ProductMapper
    {
        public static Product MapCreateProductDtoToEntity(CreateProductDto createProductDto)
        {
            return new Product
            {
                Title = createProductDto.Title,
                Price = createProductDto.Price,
                Currency = createProductDto.Currency,
                Stock = createProductDto.Stock,
                Slug = SlugUtils.CreateSlug(createProductDto.Title!),
                Description = createProductDto.Description,
            };
        }

        public static CreateProductResponseDto MapEntityToCreateProductResponseDto(Product product)
        {
            return new CreateProductResponseDto
            {
                Id = product.Id,
            };
        }

        public static Product MapUpdateProductDtoToEntity(int productId ,UpdateProductDto updateProductDto)
        {
            return new Product
            {
                Id = productId,
                Title = updateProductDto.Title,
                Price = updateProductDto.Price,
                Currency = updateProductDto.Currency,
                Stock = updateProductDto.Stock,
                Slug = SlugUtils.CreateSlug(updateProductDto.Title!),
                Description = updateProductDto.Description,
            };
        }

        public static UpdateProductResponseDto MapEntityToUpdateProductResponseDto(Product product)
        {
            return new UpdateProductResponseDto
            {
                Id = product.Id,
            };
        }

        public static ProductResponseDto MapEntitiesToProductResponseDto(Product product, IEnumerable<Image> images)
        {
            return new ProductResponseDto
            {
                Id = product.Id,
                Title = product.Title,
                Price = product.Price,
                Currency = product.Currency,
                Stock = product.Stock,
                Slug = product.Slug,
                Description = product.Description,
                Images = images.Select(image => ImageMapper.MapEntityToImageResponseDto(image)),
            };
        }

        public static ProductCompleteResponseDto MapEntitiesToProductCompleteResponseDto(Product product, IEnumerable<Image> images, IEnumerable<Part> parts)
        {
            return new ProductCompleteResponseDto
            {
                Id = product.Id,
                Title = product.Title,
                Price = product.Price,
                Currency = product.Currency,
                Stock = product.Stock,
                Slug = product.Slug,
                Description = product.Description,
                Images = images.Select(image => ImageMapper.MapEntityToImageResponseDto(image)),
                Parts = parts.Select(part => PartMapper.MapEntityToPartResponseDto(part)),
            };
        }
    }
}
