using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Catalog.Host.Services;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Moq;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using FluentAssertions;
using Catalog.Host.Models.Response;

namespace Catalog.UnitTests.Services
{
    public class CatalogServiceTests
    {
        private readonly ICatalogService _catalogService;

        private readonly Mock<ICatalogItemRepository> _catalogItemRepository;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<IDbContextWrapper<ApplicationDbContext>> _dbContextWrapper;
        private readonly Mock<ILogger<CatalogService>> _logger;

        public CatalogServiceTests()
        {
            _catalogItemRepository = new Mock<ICatalogItemRepository>();
            _mapper = new Mock<IMapper>();
            _dbContextWrapper = new Mock<IDbContextWrapper<ApplicationDbContext>>();
            _logger = new Mock<ILogger<CatalogService>>();

            var dbContextTransaction = new Mock<IDbContextTransaction>();
            _dbContextWrapper.Setup(s => s.BeginTransactionAsync(CancellationToken.None)).ReturnsAsync(dbContextTransaction.Object);

            _catalogService = new CatalogService(_dbContextWrapper.Object, _logger.Object, _catalogItemRepository.Object, _mapper.Object);
        }

        [Fact]
        public async Task GetCatalogItemsAsync_Success()
        {
            // arrange
            var testPageIndex = 0;
            var testPageSize = 4;
            var testTotalCount = 12;

            var pagingPaginatedItemsSuccess = new PaginatedItems<CatalogItem>()
            {
                Data = new List<CatalogItem>()
            {
                new CatalogItem()
                {
                    Name = "TestName",
                },
            },
                TotalCount = testTotalCount,
            };

            var catalogItemSuccess = new CatalogItem()
            {
                Name = "TestName"
            };

            var catalogItemDtoSuccess = new CatalogItemDto()
            {
                Name = "TestName"
            };

            _catalogItemRepository.Setup(s => s.GetByPageAsync(
                It.Is<int>(i => i == testPageIndex),
                It.Is<int>(i => i == testPageSize))).ReturnsAsync(pagingPaginatedItemsSuccess);

            _mapper.Setup(s => s.Map<CatalogItemDto>(
                It.Is<CatalogItem>(i => i.Equals(catalogItemSuccess)))).Returns(catalogItemDtoSuccess);

            // act
            var result = await _catalogService.GetCatalogItemsAsync(testPageSize, testPageIndex);

            // assert
            result.Should().NotBeNull();
            result?.Data.Should().NotBeNull();
            result?.Count.Should().Be(testTotalCount);
            result?.PageIndex.Should().Be(testPageIndex);
            result?.PageSize.Should().Be(testPageSize);
        }

        [Fact]
        public async Task GetCatalogItemsAsync_Failed()
        {
            // arrange
            var testPageIndex = 1000;
            var testPageSize = 10000;

            _catalogItemRepository.Setup(s => s.GetByPageAsync(
                It.Is<int>(i => i == testPageIndex),
                It.Is<int>(i => i == testPageSize))).Returns((Func<PaginatedItemsResponse<CatalogItemDto>>)null!);

            // act
            var result = await _catalogService.GetCatalogItemsAsync(testPageSize, testPageIndex);

            // assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task GetAllCatalogBrandsAsync_Success()
        {
            // arrange
           var testBrands = new List<string> { "test brand 1", "test brand 2", "test brand 3" };

           _catalogItemRepository.Setup(s => s.GetAllBrandsAsync()).Returns(Task.FromResult(testBrands));

            // act
            var result = await _catalogService.GetAllCatalogBrandsAsync();

            // assert
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
        }

        [Fact]
        public async Task GetAllCatalogBrandsAsync_Failed()
        {
            // arrange
            var testBrands = new List<string>();

            _catalogItemRepository.Setup(s => s.GetAllBrandsAsync()).Returns(Task.FromResult(testBrands));

            // act
            var result = await _catalogService.GetAllCatalogBrandsAsync();

            // assert
            result.Should().BeEmpty();
        }

        [Fact]
        public async Task GetAllCatalogTypesAsync_Success()
        {
            // arrange
            var testTypes = new List<string> { "test type 1", "test type 2", "test type3" };

            _catalogItemRepository.Setup(s => s.GetAllTypesAsync()).Returns(Task.FromResult(testTypes));

            // act
            var result = await _catalogService.GetAllCatalogTypesAsync();

            // assert
            result.Should().NotBeNull();
            result.Should().NotBeEmpty();
        }

        [Fact]
        public async Task GetAllCatalogTypesAsync_Failed()
        {
            // arrange
            var testTypes = new List<string>();

            _catalogItemRepository.Setup(s => s.GetAllTypesAsync()).Returns(Task.FromResult(testTypes));

            // act
            var result = await _catalogService.GetAllCatalogTypesAsync();

            // assert
            result.Should().BeEmpty();
        }

        [Fact]
        public async Task GetByIdAsync_Success()
        {
            // arrange
            var testId = 1;

            var itemSuccess = new CatalogItem()
            {
                Name = "test name",
                Description = "test description",
                Price = 10,
                PictureFileName = "test.png",
                CatalogType = new CatalogType()
                {
                    Id = 2,
                    Type = "test type",
                },
                CatalogBrand = new CatalogBrand()
                {
                    Id = 3,
                    Brand = "test brand",
                },
                AvailableStock = 10
            };

            _catalogItemRepository.Setup(s => s.GetById(
                It.Is<int>(i => i == testId))).ReturnsAsync(itemSuccess);

            // act
            var result = await _catalogService.GetByIdAsync(testId);

            // assert
            result.Should().NotBeNull();
            result?.Name.Should().NotBeNull();
            result?.CatalogBrand.Brand.Should().NotBeNull();
            result?.CatalogType.Type.Should().NotBeNull();
        }

        [Fact]
        public async Task GetByIdAsync_Failed()
        {
            // arrange
            var testId = 0;
            var itemIsEmpty = new CatalogItem();

            _catalogItemRepository.Setup(s => s.GetById(
                It.Is<int>(i => i == testId))).ReturnsAsync(itemIsEmpty);

            // act
            var result = await _catalogService.GetByIdAsync(testId);

            // assert
            result.Should().BeNull();
            result?.Name.Should().BeNull();
            result?.CatalogBrand.Brand.Should().BeNull();
            result?.CatalogType.Type.Should().BeNull();
        }

        [Fact]
        public async Task GetItemsByBrandAsync_Success()
        {
            // arrange
            var testPageIndex = 0;
            var testPageSize = 4;
            var testTotalCount = 12;
            var testBrandId = 2;

            var pagingPaginatedItemsByBrandSuccess = new PaginatedItems<CatalogItem>()
            {
                Data = new List<CatalogItem>()
            {
                new CatalogItem()
                {
                    Name = "TestName",
                },
            },
                TotalCount = testTotalCount,
            };

            var catalogItemSuccess = new CatalogItem()
            {
                Name = "TestName"
            };

            var catalogItemDtoSuccess = new CatalogItemDto()
            {
                Name = "TestName"
            };

            _catalogItemRepository.Setup(s => s.GetByBrandAsync(
                It.Is<int>(i => i == testPageIndex),
                It.Is<int>(i => i == testPageSize),
                It.Is<int>(i => i == testBrandId))).ReturnsAsync(pagingPaginatedItemsByBrandSuccess);

            _mapper.Setup(s => s.Map<CatalogItemDto>(
                It.Is<CatalogItem>(i => i.Equals(catalogItemSuccess)))).Returns(catalogItemDtoSuccess);

            // act
            var result = await _catalogService.GetItemsByBrandAsync(testPageIndex, testPageSize, testBrandId);

            // assert
            result.Should().NotBeNull();
            result?.Data.Should().NotBeNull();
            result?.Count.Should().Be(testTotalCount);
            result?.PageIndex.Should().Be(testPageIndex);
            result?.PageSize.Should().Be(testPageSize);
        }

        [Fact]
        public async Task GetItemsByBrandAsync_Failed()
        {
            // arrange
            var testPageIndex = 1000;
            var testPageSize = 10000;
            var testBrandId = 0;

            _catalogItemRepository.Setup(s => s.GetByBrandAsync(
                It.Is<int>(i => i == testPageIndex),
                It.Is<int>(i => i == testPageSize),
                It.Is<int>(i => i == testBrandId))).Returns((Func<PaginatedItemsResponse<CatalogItemDto>>)null!);

            // act
            var result = await _catalogService.GetItemsByBrandAsync(testPageIndex, testPageSize, testBrandId);

            // assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task GetItemsByTypeAsync_Success()
        {
            // arrange
            var testPageIndex = 0;
            var testPageSize = 4;
            var testTotalCount = 12;
            var testTypeId = 2;

            var pagingPaginatedItemsByTypeSuccess = new PaginatedItems<CatalogItem>()
            {
                Data = new List<CatalogItem>()
            {
                new CatalogItem()
                {
                    Name = "TestName",
                },
            },
                TotalCount = testTotalCount,
            };

            var catalogItemSuccess = new CatalogItem()
            {
                Name = "TestName"
            };

            var catalogItemDtoSuccess = new CatalogItemDto()
            {
                Name = "TestName"
            };

            _catalogItemRepository.Setup(s => s.GetByTypeAsync(
                It.Is<int>(i => i == testPageIndex),
                It.Is<int>(i => i == testPageSize),
                It.Is<int>(i => i == testTypeId))).ReturnsAsync(pagingPaginatedItemsByTypeSuccess);

            _mapper.Setup(s => s.Map<CatalogItemDto>(
                It.Is<CatalogItem>(i => i.Equals(catalogItemSuccess)))).Returns(catalogItemDtoSuccess);

            // act
            var result = await _catalogService.GetItemsByTypeAsync(testPageIndex, testPageSize, testTypeId);

            // assert
            result.Should().NotBeNull();
            result?.Data.Should().NotBeNull();
            result?.Count.Should().Be(testTotalCount);
            result?.PageIndex.Should().Be(testPageIndex);
            result?.PageSize.Should().Be(testPageSize);
        }

        [Fact]
        public async Task GetItemsByTypeAsync_Failed()
        {
            // arrange
            var testPageIndex = 1000;
            var testPageSize = 10000;
            var testTypeId = 0;

            _catalogItemRepository.Setup(s => s.GetByTypeAsync(
                It.Is<int>(i => i == testPageIndex),
                It.Is<int>(i => i == testPageSize),
                It.Is<int>(i => i == testTypeId))).Returns((Func<PaginatedItemsResponse<CatalogItemDto>>)null!);

            // act
            var result = await _catalogService.GetItemsByTypeAsync(testPageIndex, testPageSize, testTypeId);

            // assert
            result.Should().BeNull();
        }
    }
}
