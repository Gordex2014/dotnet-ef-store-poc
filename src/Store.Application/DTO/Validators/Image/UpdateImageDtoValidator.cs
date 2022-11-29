using FluentValidation;
using Store.Application.DTO.Image;

namespace Store.Application.DTO.Validators.Image
{
    public class UpdateImageDtoValidator : AbstractValidator<UpdateImageDto>
    {
        public UpdateImageDtoValidator()
        {
            RuleFor(x => x.Url).NotEmpty().WithMessage("Image Url is required");
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("Product Id is required");
        }
    }
}
