using Moq;
using Store.Application.DTO;
using Store.Application.DTO.Part;
using Store.Application.Services;
using Store.Core.Entities;
using Store.Core.Enums;
using Store.DataAccess.Repositories.Contracts;

namespace Store.Tests.Application.Services
{
    public class PartServiceTest
    {
        private readonly Mock<IPartRepository> _mockPartRepository;
        private readonly Mock<IProductRepository> _mockProductRepository;
        private readonly Mock<IProductPartRepository> _mockProductPartRepository;

        public PartServiceTest()
        {
            _mockPartRepository = new Mock<IPartRepository>();
            _mockProductRepository = new Mock<IProductRepository>();
            _mockProductPartRepository = new Mock<IProductPartRepository>();
        }

        [Fact]
        public async Task CreateAsync_WhenCalled_ReturnsCreatePartResponseDto()
        {
            var createPartDto = new CreatePartDto
            {
                Name = "Part 1",
                Price = 10,
                Stock = 10,
                Currency = Currencies.USD
            };
            _mockPartRepository.Setup(pr => pr.AddAsync(It.IsAny<Part>())).ReturnsAsync(new Part() { Id = 1 });
            var sut = new PartService(_mockPartRepository.Object, _mockProductRepository.Object, _mockProductPartRepository.Object);

            var result = await sut.CreateAsync(createPartDto);

            Assert.IsType<CreatePartResponseDto>(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task DeleteAsync_WhenCalled_ReturnsBaseResponseDto()
        {
            _mockPartRepository.Setup(pr => pr.DeleteAsync(It.IsAny<Part>())).ReturnsAsync(new Part() { Id = 2 });
            var sut = new PartService(_mockPartRepository.Object, _mockProductRepository.Object, _mockProductPartRepository.Object);

            var result = await sut.DeleteAsync(2);

            Assert.IsType<BaseResponseDto>(result);
            Assert.Equal(2, result.Id);
        }

        [Fact]
        public async Task GetAllByProductId_WhenCalled_ReturnsPartsByProduct()
        {
            var availableParts = new List<ProductPart>
            {
                new ProductPart { Id = 1, ProductId  = 1, PartId = 1, Product = new Product { Id = 1 }, Part = new Part { Id = 1 } },
                new ProductPart { Id = 2, ProductId  = 1, PartId = 2, Product = new Product { Id = 1 }, Part = new Part { Id = 2 } },
                new ProductPart { Id = 3, ProductId  = 2, PartId = 3, Product = new Product { Id = 2 }, Part = new Part { Id = 3 } },
            };
            _mockProductPartRepository.Setup(pr => pr.GetAllAsync(pp => pp.ProductId == 1)).ReturnsAsync(availableParts.GetRange(0, 2));
            _mockProductPartRepository.Setup(pr => pr.GetAllAsync(pp => pp.ProductId == 2)).ReturnsAsync(availableParts.GetRange(2, 1));
            var sut = new PartService(_mockPartRepository.Object, _mockProductRepository.Object, _mockProductPartRepository.Object);

            var result1 = await sut.GetAllByProductId(1);
            var result2 = await sut.GetAllByProductId(2);

            Assert.IsAssignableFrom<IEnumerable<PartResponseDto>>(result1);
            Assert.Equal(2, result1.Count());
            Assert.Equal(1, result1.ToList()[0].Id);
            Assert.Equal(3, result2.ToList()[0].Id);
        }

        [Fact]
        public async Task UpdateAsync_WhenCalled_ReturnsUpdatePartResponseDto()
        {
            var updatePartDto = new UpdatePartDto
            {
                Name = "Part 1",
                Price = 10,
                Stock = 10,
                Currency = Currencies.USD,
            };
            _mockPartRepository.Setup(pr => pr.UpdateAsync(It.IsAny<Part>())).ReturnsAsync(new Part() { Id = 1 });
            var sut = new PartService(_mockPartRepository.Object, _mockProductRepository.Object, _mockProductPartRepository.Object);

            var result = await sut.UpdateAsync(1, updatePartDto);

            Assert.IsType<UpdatePartResponseDto>(result);
            Assert.Equal(1, result.Id);
        }
    }
}
