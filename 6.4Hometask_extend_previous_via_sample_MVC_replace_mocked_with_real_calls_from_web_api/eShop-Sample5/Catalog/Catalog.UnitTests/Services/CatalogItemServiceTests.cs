using Catalog.Host.Data.Entities;

namespace Catalog.UnitTests.Services
{
    public class CatalogItemServiceTests
    {
        private readonly ICatalogItemService _catalogItemService;

        private readonly Mock<ICatalogItemRepository> _catalogItemRepository;
        private readonly Mock<IDbContextWrapper<ApplicationDbContext>> _dbContextWrapper;
        private readonly Mock<ILogger<CatalogService>> _logger;

        private readonly CatalogItem _testItem = new CatalogItem()
        {
            Name = "test name",
            Description = "test description",
            Price = 12,
            AvailableStock = 10,
            CatalogBrandId = 2,
            CatalogTypeId = 3,
            PictureFileName = "test.png"
        };

        public CatalogItemServiceTests()
        {
            _catalogItemRepository = new Mock<ICatalogItemRepository>();
            _dbContextWrapper = new Mock<IDbContextWrapper<ApplicationDbContext>>();
            _logger = new Mock<ILogger<CatalogService>>();

            var dbContextTransaction = new Mock<IDbContextTransaction>();
            _dbContextWrapper.Setup(s => s.BeginTransactionAsync(CancellationToken.None)).ReturnsAsync(dbContextTransaction.Object);

            _catalogItemService = new CatalogItemService(_dbContextWrapper.Object, _logger.Object, _catalogItemRepository.Object);
        }

        [Fact]
        public async Task Add_Success()
        {
            // arrange
            var addItemSuccess = 13;

            _catalogItemRepository.Setup(s => s.Add(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<decimal>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<string>())).ReturnsAsync(addItemSuccess);

            // act
            var result = await _catalogItemService.AddAsync(_testItem.Name, _testItem.Description, _testItem.Price, _testItem.AvailableStock, _testItem.CatalogBrandId, _testItem.CatalogTypeId, _testItem.PictureFileName);

            // assert
            result.Should().Be(addItemSuccess);
        }

        [Fact]
        public async Task Add_Failed()
        {
            // arrange
            int? addItemSuccess = null;

            _catalogItemRepository.Setup(s => s.Add(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<decimal>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<string>())).ReturnsAsync(addItemSuccess);

            // act
            var result = await _catalogItemService.AddAsync(_testItem.Name, _testItem.Description, _testItem.Price, _testItem.AvailableStock, _testItem.CatalogBrandId, _testItem.CatalogTypeId, _testItem.PictureFileName);

            // assert
            result.Should().Be(addItemSuccess);
        }

        [Fact]
        public async Task Update_Success()
        {
            // arrange
            int testId = 1;

            _catalogItemRepository.Setup(s => s.Update(
                It.Is<int>(i => i == testId),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<decimal>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<string>())).ReturnsAsync(testId);

            // act
            var result = await _catalogItemService.UpdateAsync(testId, _testItem.Name, _testItem.Description, _testItem.Price, _testItem.AvailableStock, _testItem.CatalogBrandId, _testItem.CatalogTypeId, _testItem.PictureFileName);

            // assert
            result.Should().Be(testId);
        }

        [Fact]
        public async Task Update_Failed()
        {
            // arrange
            int testId = 0;

            _catalogItemRepository.Setup(s => s.Update(
                It.Is<int>(i => i == testId),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<decimal>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<string>())).Returns(Task.FromResult<int?>(null));

            // act
            var result = await _catalogItemService.UpdateAsync(testId, _testItem.Name, _testItem.Description, _testItem.Price, _testItem.AvailableStock, _testItem.CatalogBrandId, _testItem.CatalogTypeId, _testItem.PictureFileName);

            // assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task Delete_Success()
        {
            // arrange
            var deleteItemId = 13;

            _catalogItemRepository.Setup(s => s.Delete(
                It.Is<int>(i => i == deleteItemId))).ReturnsAsync(true);

            // act
            var result = await _catalogItemService.DeleteAsync(deleteItemId);

            // assert
            result.Should().Be(true);
        }

        [Fact]
        public async Task Delete_Failed()
        {
            // arrange
            int deleteItemId = 0;

            _catalogItemRepository.Setup(s => s.Delete(
                It.Is<int>(i => i == deleteItemId))).ReturnsAsync(false);

            // act
            var result = await _catalogItemService.DeleteAsync(deleteItemId);

            // assert
            result.Should().Be(false);
        }
    }
}
