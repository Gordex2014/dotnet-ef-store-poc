using Store.Application.DTO.Image;
using Store.Application.DTO.Part;
using Store.Core.Enums;

namespace Store.Application.DTO.Product
{
    public class ProductResponseDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Slug { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public Currencies Currency { get; set; }
        public int Stock { get; set; }
        public IEnumerable<ImageResponseDto>? Images { get; set; }
    }

    public class ProductCompleteResponseDto : ProductResponseDto
    {
        public IEnumerable<PartResponseDto>? Parts { get; set; }
    }
}
