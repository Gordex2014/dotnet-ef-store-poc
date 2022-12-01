using FluentValidation.TestHelper;
using Store.Application.DTO.Product;
using Store.Application.DTO.Validators.Product;

namespace Store.Tests.Application.DTO.Validators.Product
{
    public class UpdateProductDtoValidatorTest
    {
        private readonly UpdateProductDtoValidator _sut;

        public UpdateProductDtoValidatorTest()
        {
            _sut = new UpdateProductDtoValidator();
        }

        [Fact]
        public void Validator_ShouldHaveError_WhenTitleIsEmpty()
        {
            var dto = new UpdateProductDto
            {
                Title = string.Empty,
            };

            var result = _sut.TestValidate(dto);

            result.ShouldHaveValidationErrorFor(x => x.Title);
        }

        [Fact]
        public void Validator_ShouldHaveError_WhenPriceIsEmpty()
        {
            var dto = new UpdateProductDto { };

            var result = _sut.TestValidate(dto);

            result.ShouldHaveValidationErrorFor(x => x.Price);
        }

        [Fact]
        public void Validator_ShouldHaveError_WhenCurrencyIsEmpty()
        {
            var dto = new UpdateProductDto { };

            var result = _sut.TestValidate(dto);

            result.ShouldHaveValidationErrorFor(x => x.Currency);
        }

        [Fact]
        public void Validator_ShouldHaveError_WhenStockIsEmpty()
        {
            var dto = new UpdateProductDto { };

            var result = _sut.TestValidate(dto);

            result.ShouldHaveValidationErrorFor(x => x.Currency);
        }
    }
}
