using FluentValidation.TestHelper;
using Store.Application.DTO.Image;
using Store.Application.DTO.Validators.Image;

namespace Store.Tests.Application.DTO.Validators.Image
{
    public class UpdateImageDtoValidatorTest
    {
        private readonly UpdateImageDtoValidator _sut;

        public UpdateImageDtoValidatorTest()
        {
            _sut = new UpdateImageDtoValidator();
        }

        [Fact]
        public void Validator_ShouldHaveError_WhenUrlIsEmpty()
        {
            var dto = new UpdateImageDto
            {
                Url = string.Empty,
            };

            var result = _sut.TestValidate(dto);

            result.ShouldHaveValidationErrorFor(x => x.Url);
        }

        [Fact]
        public void Validator_ShouldHaveError_WhenProductIdIsEmpty()
        {
            var dto = new UpdateImageDto
            {
                Url = "https://www.google.com",
            };

            var result = _sut.TestValidate(dto);

            result.ShouldHaveValidationErrorFor(x => x.ProductId);
        }
    }
}
