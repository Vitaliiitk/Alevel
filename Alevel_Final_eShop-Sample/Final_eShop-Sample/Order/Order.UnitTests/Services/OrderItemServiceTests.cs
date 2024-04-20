using Order.Host.Data;
using Order.Host.Data.Entities;
using Order.Host.Models.Dtos;
using Order.Host.Repositories.Interfaces;
using Order.Host.Services;
using Order.Host.Services.Interfaces;

namespace Order.UnitTests.Services
{
	public class OrderItemServiceTests
	{
		private readonly IOrderItemService _orderItemService;

		private readonly Mock<IOrderItemRepository> _orderItemRepository;
		private readonly Mock<IDbContextWrapper<ApplicationDbContext>> _dbContextWrapper;
		private readonly Mock<ILogger<OrderItemService>> _logger;

		public OrderItemServiceTests()
		{
			_orderItemRepository = new Mock<IOrderItemRepository>();
			_dbContextWrapper = new Mock<IDbContextWrapper<ApplicationDbContext>>();
			_logger = new Mock<ILogger<OrderItemService>>();

			var dbContextTransaction = new Mock<IDbContextTransaction>();
			_dbContextWrapper.Setup(s => s.BeginTransactionAsync(It.IsAny<CancellationToken>())).ReturnsAsync(dbContextTransaction.Object);

			_orderItemService = new OrderItemService(_dbContextWrapper.Object, _logger.Object, _orderItemRepository.Object);
		}

		[Fact]
		public async Task AddAsync_Success()
		{
			// arrange
			var testResult = 1;
			string someNumberOfOrder = "here is some unique id of an order";
			double totalPrice = 24.97;

			List<OrderItems> productsToOrder = new List<OrderItems>()
			{
				new OrderItems { Name = "Product1", Amount = 2, Price = 8.99 },
				new OrderItems { Name = "Product2", Amount = 1, Price = 5.99 },
				new OrderItems { Name = "Product3", Amount = 3, Price = 9.99 }
			};

			_orderItemRepository.Setup(s => s.Add(
				It.IsAny<string>(),
				It.IsAny<double>(),
				It.IsAny<List<OrderItems>>())).ReturnsAsync(testResult);

			// act
			var result = await _orderItemService.AddAsync(someNumberOfOrder, totalPrice, productsToOrder);

			// assert
			result.Should().Be(testResult);
		}

		[Fact]
		public async Task AddAsync_Failed()
		{
			// arrange
			int? testResult = null;
			string someNumberOfOrder = string.Empty;
			double totalPrice = 0;
			List<OrderItems> productsToOrder = new List<OrderItems>();

			_orderItemRepository.Setup(s => s.Add(
				It.IsAny<string>(),
				It.IsAny<double>(),
				It.IsAny<List<OrderItems>>())).ReturnsAsync(testResult);

			// act
			var result = await _orderItemService.AddAsync(someNumberOfOrder, totalPrice, productsToOrder);

			// assert
			result.Should().Be(testResult);
		}

		[Fact]
		public async Task GetByUniqueOrderNumberAsync_Success()
		{
			// arrange
			string uniqueOrderNumber = "here is some unique number of an order";
			var testOrderToReturn = new Host.Data.Entities.Order() // I did a little mistake: namespace Order coincides with class Order.cs
			{
				SomeNumberOfOrder = uniqueOrderNumber,
				TotalPrice = 24.97,
				OrderItems = new List<OrderItems>()
				{
					new OrderItems { Name = "Product1", Amount = 2, Price = 8.99 },
					new OrderItems { Name = "Product2", Amount = 1, Price = 5.99 },
					new OrderItems { Name = "Product3", Amount = 3, Price = 9.99 }
				}
			};
			var testOrderToReturnDto = new OrderDto()
			{
				SomeNumberOfOrder = uniqueOrderNumber,
				TotalPrice = 24.97,
				OrderItems = new List<OrderItemsDto>()
				{
					new OrderItemsDto { Name = "Product1", Amount = 2, Price = 8.99 },
					new OrderItemsDto { Name = "Product2", Amount = 1, Price = 5.99 },
					new OrderItemsDto { Name = "Product3", Amount = 3, Price = 9.99 }
				}
			};
			_orderItemRepository.Setup(s => s.GetByUniqueOrderNumber(
				It.IsAny<string>())).ReturnsAsync(testOrderToReturn);

			// act
			var result = await _orderItemService.GetByUniqueOrderNumberAsync(uniqueOrderNumber);

			// assert
			result.Should().NotBeNull();
			result.Should().BeEquivalentTo(testOrderToReturnDto);
		}

		[Fact]
		public async Task GetByUniqueOrderNumberAsync_Failed()
		{
			// arrange
			string? uniqueOrderNumber = null;
			var testOrderToReturn = new Host.Data.Entities.Order(); // I did a little mistake: namespace Order coincides with class Order.cs

			_orderItemRepository.Setup(s => s.GetByUniqueOrderNumber(
				It.IsAny<string>())).ReturnsAsync(testOrderToReturn);

			// act
			var result = await _orderItemService.GetByUniqueOrderNumberAsync(uniqueOrderNumber);

			// assert
			result.Should().BeNull();
		}
	}
}
