using FluentValidation.TestHelper;
using Store.Application.DTO.Part;
using Store.Application.DTO.Validators.Part;

namespace Store.Tests.Application.DTO.Validators.Part
{
    public class CreatePartDtoValidatorTest
    {
        private readonly CreatePartDtoValidator _sut;

        public CreatePartDtoValidatorTest()
        {
            _sut = new CreatePartDtoValidator();
        }

        [Fact]
        public void Validator_ShouldHaveError_WhenNameIsEmpty()
        {
            var dto = new CreatePartDto
            {
                Name = string.Empty,
            };

            var result = _sut.TestValidate(dto);

            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public void Validator_ShouldHaveError_WhenPriceIsEmpty()
        {
            var dto = new CreatePartDto { };

            var result = _sut.TestValidate(dto);

            result.ShouldHaveValidationErrorFor(x => x.Price);
        }

        [Fact]
        public void Validator_ShouldHaveError_WhenCurrencyIsEmpty()
        {
            var dto = new CreatePartDto { };

            var result = _sut.TestValidate(dto);

            result.ShouldHaveValidationErrorFor(x => x.Currency);
        }

        [Fact]
        public void Validator_ShouldHaveError_WhenStockIsEmpty()
        {
            var dto = new CreatePartDto { };

            var result = _sut.TestValidate(dto);

            result.ShouldHaveValidationErrorFor(x => x.Currency);
        }

        [Fact]
        public void Validator_ShouldHaveError_WhenUnitIsEmpty()
        {
            var dto = new CreatePartDto
            {
                Unit = string.Empty,
            };

            var result = _sut.TestValidate(dto);

            result.ShouldHaveValidationErrorFor(x => x.Unit);
        }
    }
}
