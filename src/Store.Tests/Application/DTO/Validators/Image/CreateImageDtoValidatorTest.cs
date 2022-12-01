using FluentValidation.TestHelper;
using Store.Application.DTO.Image;
using Store.Application.DTO.Validators.Image;

namespace Store.Tests.Application.DTO.Validators.Image
{
    public class CreateImageDtoValidatorTest
    {
        private readonly CreateImageDtoValidator _sut;

        public CreateImageDtoValidatorTest()
        {
            _sut = new CreateImageDtoValidator();
        }

        [Fact]
        public void Validator_ShouldHaveError_WhenUrlIsEmpty()
        {
            var dto = new CreateImageDto
            {
                Url = string.Empty,
            };

            var result = _sut.TestValidate(dto);

            result.ShouldHaveValidationErrorFor(x => x.Url);
        }

        [Fact]
        public void Validator_ShouldHaveError_WhenProductIdIsEmpty()
        {
            var dto = new CreateImageDto
            {
                Url = "https://www.google.com",
            };

            var result = _sut.TestValidate(dto);

            result.ShouldHaveValidationErrorFor(x => x.ProductId);
        }
    }
}
