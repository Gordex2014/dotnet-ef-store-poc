using FluentValidation;
using Store.Application.DTO.Image;

namespace Store.Application.DTO.Validators.Image
{
    public class CreateImageDtoValidator : AbstractValidator<CreateImageDto>
    {
        public CreateImageDtoValidator()
        {
            RuleFor(x => x.Url).NotEmpty().WithMessage("Image Url is required");
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("Product Id is required");
        }
    }
}
