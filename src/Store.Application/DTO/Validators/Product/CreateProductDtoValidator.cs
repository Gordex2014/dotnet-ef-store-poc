using FluentValidation;
using Store.Application.DTO.Product;

namespace Store.Application.DTO.Validators.Product
{
    public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Product title is required");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Product price is required");
            RuleFor(x => x.Stock).NotEmpty().WithMessage("Product initial stock is required");
            RuleFor(x => x.Currency).NotEmpty().WithMessage("Product currency is required");
        }
    }
}
