using System.Collections.Generic;
using Basket.Host.Models;
using Basket.Host.Models.Requests;
using Basket.Host.Services;
using Basket.Host.Services.Interfaces;

namespace Basket.UnitTests.Services
{
    public class BasketServiceTest
    {
        private readonly IBasketService _basketService;
        private readonly Mock<ICacheService> _cacheService;

        private readonly AddProductRequest _testProduct = new AddProductRequest()
        {
            Id = 1,
            Name = "Test",
            Price = 22,
            PictureFileName = "sometest.jpg"
        };

        public BasketServiceTest()
        {
            _cacheService = new Mock<ICacheService>();
            _basketService = new BasketService(_cacheService.Object);
        }

        [Fact]
        public async Task AddProduct_Success()
        {
			// arrange
			var userId = "user id is a key";
			var listOfProducts = new List<Product>();
			_cacheService.Setup(x => x.GetAsync<List<Product>>(userId)).ReturnsAsync(listOfProducts);
			_cacheService.Setup(x => x.AddOrUpdateAsync(userId, It.IsAny<List<Product>>()));

			// act
			var result = await _basketService.AddProduct(userId, _testProduct);

			// assert
			result.Should().Be(true);
		}

        [Fact]
        public async Task AddProduct_Failed()
		{
			// arrange
			string userId = string.Empty;

			// act
			var result = await _basketService.AddProduct(userId, _testProduct);

			// assert
			result.Should().Be(false);
		}

        [Fact]
        public async Task RemoveProduct_Success()
		{
			// arrange
			var userId = "user id is a key";
			var expectedProducts = new List<Product>
			{
				new Product { Id = 1, Name = "Product 1", Amount = 2, Price = 10, PictureFileName = "some.jpg" },
				new Product { Id = 3, Name = "Product 3", Amount = 5, Price = 10, PictureFileName = "some3.jpg" },
			};
			var products = _cacheService.Setup(x => x.GetAsync<List<Product>>(userId)).ReturnsAsync(expectedProducts);

			// act
			var result = await _basketService.RemoveProduct(userId, _testProduct);

			// assert
			result.Should().Be(true);
		}

        [Fact]
        public async Task RemoveProduct_ProductNotFound()
		{
			// Arrange
			string userId = "user id as a key";

			var products = new List<Product>
			{
				new Product { Id = 4, Name = "Product 4", Amount = 1, Price = 10, PictureFileName = "some4.jpg" },
				new Product { Id = 2, Name = "Product 2", Amount = 2, Price = 10, PictureFileName = "some2.jpg" }
			};
			_cacheService.Setup(x => x.GetAsync<List<Product>>(userId)).ReturnsAsync(products);

			// Act & Assert
			await Assert.ThrowsAsync<Exception>(() => _basketService.RemoveProduct(userId, _testProduct));
		}

        [Fact]
        public async Task<List<Product>> GetAllProduct_Success()
		{
			// arrange
			var userId = "user id is a key";

			var expectedProducts = new List<Product>
			{
				new Product { Id = 1, Name = "Product 1", Amount = 2, Price = 10, PictureFileName = "some.jpg" },
				new Product { Id = 3, Name = "Product 3", Amount = 5, Price = 10, PictureFileName = "some3.jpg" },
			};
			var products = _cacheService.Setup(x => x.GetAsync<List<Product>>(userId)).ReturnsAsync(expectedProducts);

			// act
			var result = await _basketService.GetAllProducts(userId);

			// assert
			return result;
		}

        [Fact]
        public async Task GetAllProduct_Failed()
		{
			// arrange
			string userId = "some real key";
			var expectedProducts = new List<Product>();

			var products = _cacheService.Setup(x => x.GetAsync<List<Product>>(userId)).ReturnsAsync(expectedProducts);

			// act
			Func<Task> result = async () => await _basketService.GetAllProducts(userId);

			// assert
			await Assert.ThrowsAsync<Exception>(result);
		}

        [Fact]
        public async Task RemoveAllProduct_Success()
		{
			// arrange
			var userId = "user id is a key";
			_cacheService.Setup(x => x.DeleteAsync(userId)).ReturnsAsync(true);

			// act
			var result = await _basketService.RemoveAllProducts(userId);

			// assert
			result.Should().Be(true);
		}

        [Fact]
        public async Task RemoveAllProduct_Failed()
		{
			// arrange
			string userId = "some real key";

			_cacheService.Setup(x => x.DeleteAsync(userId)).ReturnsAsync(false);

			// act
			var result = await _basketService.RemoveAllProducts(userId);

			// assert
			result.Should().Be(false);
		}
	}
}
