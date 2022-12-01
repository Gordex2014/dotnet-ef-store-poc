using Moq;
using Store.Application.DTO;
using Store.Application.DTO.Product;
using Store.Application.Services;
using Store.Core.Entities;
using Store.Core.Enums;
using Store.DataAccess.Repositories.Contracts;

namespace Store.Tests.Application.Services
{
    public class ProductServiceTest
    {
        private readonly Mock<IProductRepository> _mockProductRepository;
        private readonly Mock<IImageRepository> _mockImageRepository;

        public ProductServiceTest()
        {
            _mockProductRepository = new Mock<IProductRepository>();
            _mockImageRepository = new Mock<IImageRepository>();
        }

        [Fact]
        public async Task CreateAsync_WhenCalled_ReturnsCreateProductResponseDto()
        {
            var createProductDto = new CreateProductDto
            {
                Title = "Test Product",
                Price = 100,
                Stock = 10,
                Currency = Currencies.USD
            };
            _mockProductRepository.Setup(pr => pr.AddAsync(It.IsAny<Product>())).ReturnsAsync(new Product() { Id = 1 });
            var sut = new ProductService(_mockProductRepository.Object, _mockImageRepository.Object);

            var result = await sut.CreateAsync(createProductDto);

            Assert.IsType<CreateProductResponseDto>(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task DeleteAsync_WhenCalled_ReturnsBaseResponseDto()
        {
            _mockProductRepository.Setup(pr => pr.DeleteAsync(It.IsAny<Product>())).ReturnsAsync(new Product() { Id = 2 });
            var sut = new ProductService(_mockProductRepository.Object, _mockImageRepository.Object);

            var result = await sut.DeleteAsync(2);

            Assert.IsType<BaseResponseDto>(result);
            Assert.Equal(2, result.Id);
        }

        [Fact]
        public async Task GetAllAsync_WhenCalled_ReturnsAllProducts()
        {
            var availableProducts = new List<Product>
            {
                new Product { Id = 1, Title = "Test Product 1", Price = 100, Stock = 10, Currency = Currencies.USD },
                new Product { Id = 2, Title = "Test Product 2", Price = 200, Stock = 20, Currency = Currencies.USD },
                new Product { Id = 3, Title = "Test Product 3", Price = 300, Stock = 30, Currency = Currencies.USD },
            };
            _mockProductRepository.Setup(pr => pr.GetAllAsync(p => true)).ReturnsAsync(availableProducts);
            var sut = new ProductService(_mockProductRepository.Object, _mockImageRepository.Object);

            var result = await sut.GetAllAsync();

            Assert.IsAssignableFrom<IEnumerable<ProductResponseDto>>(result);
            Assert.Equal(3, result.Count());
        }

        [Fact]
        public async Task GetByIdAsync_WhenCalled_ReturnsProductCompleteResponseDto()
        {
            var product = new Product { Id = 1, Title = "Test Product 1", Price = 100, Stock = 10, Currency = Currencies.USD };
            _mockProductRepository.Setup(pr => pr.GetFirstAsync(p => p.Id == 1)).ReturnsAsync(product);
            var sut = new ProductService(_mockProductRepository.Object, _mockImageRepository.Object);

            var result = await sut.GetByIdAsync(1);

            Assert.IsType<ProductCompleteResponseDto>(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task UpdateAsync_WhenCalled_ReturnsUpdateProductResponseDto()
        {
            const int productId = 1;

            var updateProductDto = new UpdateProductDto
            {
                Title = "Test Product",
                Price = 100,
                Stock = 10,
                Currency = Currencies.USD
            };
            _mockProductRepository.Setup(pr => pr.UpdateAsync(It.IsAny<Product>())).ReturnsAsync(new Product() { Id = productId });
            var sut = new ProductService(_mockProductRepository.Object, _mockImageRepository.Object);

            var result = await sut.UpdateAsync(productId, updateProductDto);

            Assert.IsType<UpdateProductResponseDto>(result);
            Assert.Equal(productId, result.Id);
        }
    }
}
