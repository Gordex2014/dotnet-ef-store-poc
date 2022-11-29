using Store.Core.Enums;

namespace Store.Application.DTO.Part
{
    public class CreatePartDto
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public Currencies Currency { get; set; }
        public int Stock { get; set; }
        public string? Unit { get; set; }
        public string? Description { get; set; }
    }

    public class CreatePartResponseDto : BaseResponseDto { }
}
