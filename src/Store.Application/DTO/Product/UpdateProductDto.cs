using Store.Core.Enums;

namespace Store.Application.DTO.Product
{
    public class UpdateProductDto
    {
        public string? Title { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public Currencies Currency { get; set; }
        public string? Description { get; set; }
    }

    public class UpdateProductResponseDto : BaseResponseDto { }
}
