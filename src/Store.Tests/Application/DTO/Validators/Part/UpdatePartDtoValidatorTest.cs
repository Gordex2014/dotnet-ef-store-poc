using FluentValidation.TestHelper;
using Store.Application.DTO.Part;
using Store.Application.DTO.Validators.Part;

namespace Store.Tests.Application.DTO.Validators.Part
{
    public class UpdatePartDtoValidatorTest
    {
        private readonly UpdatePartDtoValidator _sut;

        public UpdatePartDtoValidatorTest()
        {
            _sut = new UpdatePartDtoValidator();
        }

        [Fact]
        public void Validator_ShouldHaveError_WhenNameIsEmpty()
        {
            var dto = new UpdatePartDto
            {
                Name = string.Empty,
            };

            var result = _sut.TestValidate(dto);

            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public void Validator_ShouldHaveError_WhenPriceIsEmpty()
        {
            var dto = new UpdatePartDto { };

            var result = _sut.TestValidate(dto);

            result.ShouldHaveValidationErrorFor(x => x.Price);
        }

        [Fact]
        public void Validator_ShouldHaveError_WhenCurrencyIsEmpty()
        {
            var dto = new UpdatePartDto { };

            var result = _sut.TestValidate(dto);

            result.ShouldHaveValidationErrorFor(x => x.Currency);
        }

        [Fact]
        public void Validator_ShouldHaveError_WhenStockIsEmpty()
        {
            var dto = new UpdatePartDto { };

            var result = _sut.TestValidate(dto);

            result.ShouldHaveValidationErrorFor(x => x.Currency);
        }

        [Fact]
        public void Validator_ShouldHaveError_WhenUnitIsEmpty()
        {
            var dto = new UpdatePartDto 
            {
                Unit = string.Empty,
            };

            var result = _sut.TestValidate(dto);

            result.ShouldHaveValidationErrorFor(x => x.Unit);
        }
    }
}
