namespace Store.Application.DTO.Image
{
    public class UpdateImageDto
    {
        public string? Url { get; set; }
        public int ProductId { get; set; }
    }

    public class UpdateImageResponseDto : BaseResponseDto { }
}
