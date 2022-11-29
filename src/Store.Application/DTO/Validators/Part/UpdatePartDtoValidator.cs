using FluentValidation;
using Store.Application.DTO.Part;

namespace Store.Application.DTO.Validators.Part
{
    public class UpdatePartDtoValidator : AbstractValidator<UpdatePartDto>
    {
        public UpdatePartDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required");
            RuleFor(x => x.Currency).NotEmpty().WithMessage("Currency is required");
            RuleFor(x => x.Stock).NotEmpty().WithMessage("Stock is required");
            RuleFor(x => x.Unit).NotEmpty().WithMessage("Unit is required");
        }
    }
}
