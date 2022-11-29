namespace Store.Application.DTO.Image
{
    public class CreateImageDto
    {
        public string? Url { get; set; }
        public int ProductId { get; set; }
    }

    public class CreateImageResponseDto : BaseResponseDto { }
}
