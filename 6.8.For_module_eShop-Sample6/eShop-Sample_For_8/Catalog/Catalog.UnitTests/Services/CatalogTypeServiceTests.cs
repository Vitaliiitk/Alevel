using System.Threading;
using Catalog.Host.Data.Entities;

namespace Catalog.UnitTests.Services
{
    public class CatalogTypeServiceTests
    {
        private readonly ICatalogTypeService _catalogTypeService;

        private readonly Mock<ICatalogTypeRepository> _catalogTypeRepository;
        private readonly Mock<IDbContextWrapper<ApplicationDbContext>> _dbContextWrapper;
        private readonly Mock<ILogger<CatalogService>> _logger;

        private readonly CatalogType _testType = new CatalogType()
        {
            Type = "test type name",
            Id = 3,
        };

        public CatalogTypeServiceTests()
        {
            _catalogTypeRepository = new Mock<ICatalogTypeRepository>();
            _dbContextWrapper = new Mock<IDbContextWrapper<ApplicationDbContext>>();
            _logger = new Mock<ILogger<CatalogService>>();

            var dbContextTransaction = new Mock<IDbContextTransaction>();
            _dbContextWrapper.Setup(s => s.BeginTransactionAsync(CancellationToken.None)).ReturnsAsync(dbContextTransaction.Object);

            _catalogTypeService = new CatalogTypeService(_dbContextWrapper.Object, _logger.Object, _catalogTypeRepository.Object);
        }

        [Fact]
        public async Task Add_Success()
        {
            // arrange
            // var addTypeSuccess = 13;
            _catalogTypeRepository.Setup(s => s.Add(
                It.IsAny<int>(),
                It.IsAny<string>())).ReturnsAsync(_testType.Id);

            // act
            var result = await _catalogTypeService.AddAsync(_testType.Id, _testType.Type);

            // assert
            result.Should().Be(_testType.Id);
        }

        [Fact]
        public async Task Add_Failed()
        {
            // arrange
            int? addItemFailed = null;

            _catalogTypeRepository.Setup(s => s.Add(
                It.IsAny<int>(),
                It.IsAny<string>())).ReturnsAsync(addItemFailed);

            // act
            var result = await _catalogTypeService.AddAsync(_testType.Id, _testType.Type);

            // assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task Update_Success()
        {
            // arrange
            // int testId = 1;
            _catalogTypeRepository.Setup(s => s.Update(
                It.Is<int>(i => i == _testType.Id),
                It.IsAny<string>())).ReturnsAsync(_testType.Id);

            // act
            var result = await _catalogTypeService.UpdateAsync(_testType.Id, _testType.Type);

            // assert
            result.Should().Be(_testType.Id);
        }

        [Fact]
        public async Task Update_Failed()
        {
            // arrange
            _catalogTypeRepository.Setup(s => s.Update(
                It.Is<int>(i => i == _testType.Id),
                It.IsAny<string>())).Returns(Task.FromResult<int?>(null));

            // act
            var result = await _catalogTypeService.UpdateAsync(_testType.Id, _testType.Type);

            // assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task Delete_Success()
        {
            // arrange
            var deleteItemIdTest = 13;

            _catalogTypeRepository.Setup(s => s.Delete(
                It.Is<int>(i => i == deleteItemIdTest))).ReturnsAsync(true);

            // act
            var result = await _catalogTypeService.DeleteAsync(deleteItemIdTest);

            // assert
            result.Should().Be(true);
        }

        [Fact]
        public async Task Delete_Failed()
        {
            // arrange
            int deleteItemId = 0;

            _catalogTypeRepository.Setup(s => s.Delete(
                It.Is<int>(i => i == deleteItemId))).ReturnsAsync(false);

            // act
            var result = await _catalogTypeService.DeleteAsync(deleteItemId);

            // assert
            result.Should().Be(false);
        }
    }
}
