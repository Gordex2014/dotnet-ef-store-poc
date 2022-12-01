using Moq;
using Store.Application.DTO;
using Store.Application.DTO.Image;
using Store.Application.Services;
using Store.Core.Entities;
using Store.DataAccess.Repositories.Contracts;

namespace Store.Tests.Application.Services
{
    public class ImageServiceTest
    {
        private readonly Mock<IImageRepository> _mockImageRepository;
        private readonly Mock<IProductRepository> _mockProductRepository;

        public ImageServiceTest()
        {
            _mockImageRepository = new Mock<IImageRepository>();
            _mockProductRepository = new Mock<IProductRepository>();
        }

        [Fact]
        public async Task CreateAsync_WhenCalled_ReturnsCreateImageResponseDto()
        {
            var createImageDto = new CreateImageDto
            {
                ProductId = 1,
                Url = "https://www.google.com/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png"
            };
            _mockImageRepository.Setup(ir => ir.AddAsync(It.IsAny<Image>())).ReturnsAsync(new Image() { Id = 1 });
            var sut = new ImageService(_mockImageRepository.Object, _mockProductRepository.Object);

            var result = await sut.CreateAsync(createImageDto);

            Assert.IsType<CreateImageResponseDto>(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task DeleteAsync_WhenCalled_ReturnsBaseResponseDto()
        {
            _mockImageRepository.Setup(ir => ir.DeleteAsync(It.IsAny<Image>())).ReturnsAsync(new Image() { Id = 2 });
            var sut = new ImageService(_mockImageRepository.Object, _mockProductRepository.Object);

            var result = await sut.DeleteAsync(2);

            Assert.IsType<BaseResponseDto>(result);
            Assert.Equal(2, result.Id);
        }

        [Fact]
        public async Task GetAllByProductId_WhenCalled_ReturnsImagesByProduct()
        {
            var availableImages = new List<Image>
            {
                new Image { Id = 1, ProductId = 1 },
                new Image { Id = 2, ProductId = 1 },
                new Image { Id = 3, ProductId = 2 },
            };
            _mockImageRepository.Setup(ir => ir.GetAllAsync(i => i.ProductId == 1)).ReturnsAsync(availableImages.GetRange(0, 2));
            _mockImageRepository.Setup(ir => ir.GetAllAsync(i => i.ProductId == 2)).ReturnsAsync(availableImages.GetRange(2, 1));
            var sut = new ImageService(_mockImageRepository.Object, _mockProductRepository.Object);

            var result1 = await sut.GetAllByProductId(1);
            var result2 = await sut.GetAllByProductId(2);

            Assert.IsAssignableFrom<IEnumerable<ImageResponseDto>>(result1);
            Assert.Equal(3, result2.First().Id);
            Assert.Equal(2, result1.ToList()[1].Id);
        }

        [Fact]
        public async Task UpdateAsync_WhenCalled_ReturnsUpdateImageResponseDto()
        {
            var updateImageDto = new UpdateImageDto
            {
                ProductId = 5,
            };
            _mockImageRepository.Setup(ir => ir.UpdateAsync(It.IsAny<Image>())).ReturnsAsync(new Image() { Id = 10 });
            var sut = new ImageService(_mockImageRepository.Object, _mockProductRepository.Object);

            var result = await sut.UpdateAsync(3, updateImageDto);

            Assert.IsType<UpdateImageResponseDto>(result);
            Assert.Equal(10, result.Id);
        }
    }
}
