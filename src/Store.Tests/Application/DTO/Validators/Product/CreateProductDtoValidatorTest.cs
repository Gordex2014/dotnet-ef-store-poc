using FluentValidation.TestHelper;
using Store.Application.DTO.Product;
using Store.Application.DTO.Validators.Product;

namespace Store.Tests.Application.DTO.Validators.Product
{
    public class CreateProductDtoValidatorTest
    {
        private readonly CreateProductDtoValidator _sut;

        public CreateProductDtoValidatorTest()
        {
            _sut = new CreateProductDtoValidator();
        }

        [Fact]
        public void Validator_ShouldHaveError_WhenTitleIsEmpty()
        {
            var dto = new CreateProductDto
            {
                Title = string.Empty,
            };

            var result = _sut.TestValidate(dto);

            result.ShouldHaveValidationErrorFor(x => x.Title);
        }

        [Fact]
        public void Validator_ShouldHaveError_WhenPriceIsEmpty()
        {
            var dto = new CreateProductDto { };

            var result = _sut.TestValidate(dto);

            result.ShouldHaveValidationErrorFor(x => x.Price);
        }

        [Fact]
        public void Validator_ShouldHaveError_WhenCurrencyIsEmpty()
        {
            var dto = new CreateProductDto { };

            var result = _sut.TestValidate(dto);

            result.ShouldHaveValidationErrorFor(x => x.Currency);
        }

        [Fact]
        public void Validator_ShouldHaveError_WhenStockIsEmpty()
        {
            var dto = new CreateProductDto { };

            var result = _sut.TestValidate(dto);

            result.ShouldHaveValidationErrorFor(x => x.Currency);
        }
    }
}
