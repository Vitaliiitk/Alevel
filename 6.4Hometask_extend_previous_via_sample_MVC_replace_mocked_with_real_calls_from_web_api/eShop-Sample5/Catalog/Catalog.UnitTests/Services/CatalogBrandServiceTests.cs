using Catalog.Host.Data.Entities;

namespace Catalog.UnitTests.Services
{
    public class CatalogBrandServiceTests
    {
        private readonly ICatalogBrandService _catalogBrandService;

        private readonly Mock<ICatalogBrandRepository> _catalogBrandRepository;
        private readonly Mock<IDbContextWrapper<ApplicationDbContext>> _dbContextWrapper;
        private readonly Mock<ILogger<CatalogService>> _logger;

        private readonly CatalogBrand _testBrand = new CatalogBrand()
        {
            Brand = "test brand name",
            Id = 3,
        };

        public CatalogBrandServiceTests()
        {
            _catalogBrandRepository = new Mock<ICatalogBrandRepository>();
            _dbContextWrapper = new Mock<IDbContextWrapper<ApplicationDbContext>>();
            _logger = new Mock<ILogger<CatalogService>>();

            var dbContextTransaction = new Mock<IDbContextTransaction>();
            _dbContextWrapper.Setup(s => s.BeginTransactionAsync(CancellationToken.None)).ReturnsAsync(dbContextTransaction.Object);

            _catalogBrandService = new CatalogBrandService(_dbContextWrapper.Object, _logger.Object, _catalogBrandRepository.Object);
        }

        [Fact]
        public async Task Add_Success()
        {
            // arrange
            // var addBrandSuccess = 13;
            _catalogBrandRepository.Setup(s => s.Add(
                It.IsAny<int>(),
                It.IsAny<string>())).ReturnsAsync(_testBrand.Id);

            // act
            var result = await _catalogBrandService.AddAsync(_testBrand.Id, _testBrand.Brand);

            // assert
            result.Should().Be(_testBrand.Id);
        }

        [Fact]
        public async Task Add_Failed()
        {
            // arrange
            int? addItemFailed = null;

            _catalogBrandRepository.Setup(s => s.Add(
                It.IsAny<int>(),
                It.IsAny<string>())).ReturnsAsync(addItemFailed);

            // act
            var result = await _catalogBrandService.AddAsync(_testBrand.Id, _testBrand.Brand);

            // assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task Update_Success()
        {
            // arrange
            // int testId = 1;
            _catalogBrandRepository.Setup(s => s.Update(
                It.Is<int>(i => i == _testBrand.Id),
                It.IsAny<string>())).ReturnsAsync(_testBrand.Id);

            // act
            var result = await _catalogBrandService.UpdateAsync(_testBrand.Id, _testBrand.Brand);

            // assert
            result.Should().Be(_testBrand.Id);
        }

        [Fact]
        public async Task Update_Failed()
        {
            // arrange
            _catalogBrandRepository.Setup(s => s.Update(
                It.Is<int>(i => i == _testBrand.Id),
                It.IsAny<string>())).Returns(Task.FromResult<int?>(null));

            // act
            var result = await _catalogBrandService.UpdateAsync(_testBrand.Id, _testBrand.Brand);

            // assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task Delete_Success()
        {
            // arrange
            var deleteItemIdTest = 13;

            _catalogBrandRepository.Setup(s => s.Delete(
                It.Is<int>(i => i == deleteItemIdTest))).ReturnsAsync(true);

            // act
            var result = await _catalogBrandService.DeleteAsync(deleteItemIdTest);

            // assert
            result.Should().Be(true);
        }

        [Fact]
        public async Task Delete_Failed()
        {
            // arrange
            int deleteItemId = 0;

            _catalogBrandRepository.Setup(s => s.Delete(
                It.Is<int>(i => i == deleteItemId))).ReturnsAsync(false);

            // act
            var result = await _catalogBrandService.DeleteAsync(deleteItemId);

            // assert
            result.Should().Be(false);
        }
    }
}
