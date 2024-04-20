using Infrastructure.Services;
using Infrastructure.Services.Interfaces;
using Order.Host.Data;
using Order.Host.Data.Entities;
using Order.Host.Models.Dtos;
using Order.Host.Repositories.Interfaces;
using Order.Host.Services.Interfaces;

namespace Order.Host.Services
{
	public class OrderItemService : BaseDataService<ApplicationDbContext>, IOrderItemService
	{
		private readonly IOrderItemRepository _orderItemRepository;
		private readonly ILogger<BaseDataService<ApplicationDbContext>> _logger;

		public OrderItemService(
	IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
	ILogger<BaseDataService<ApplicationDbContext>> logger,
	IOrderItemRepository orderItemRepository)
	: base(dbContextWrapper, logger)
		{
			_orderItemRepository = orderItemRepository;
			_logger = logger;
		}

		public Task<int?> AddAsync(string someNumberOfOrder, double totalPrice, List<OrderItems> orderItems)
		{
			return ExecuteSafeAsync(() => _orderItemRepository.Add(someNumberOfOrder, totalPrice, orderItems));
		}

		public async Task<OrderDto?> GetByUniqueOrderNumberAsync(string? uniqueNumberOfOrder)
		{
			return await ExecuteSafeAsync(async () =>
			{
				var result = await _orderItemRepository.GetByUniqueOrderNumber(uniqueNumberOfOrder);

				if (result == null)
				{
					return null;
				}

				// Mapping data from database on Dto model. Later we will use this method in Controller
				var returnOrder = new OrderDto()
				{
					Id = result.Id,
					SomeNumberOfOrder = result.SomeNumberOfOrder,
					TotalPrice = result.TotalPrice,
					OrderItems = result.OrderItems.Select(product => new OrderItemsDto
					{
						Id = product.Id,
						Name = product.Name,
						Amount = product.Amount,
						Price = product.Price
					}).ToList()
				};

				return returnOrder;
			});
		}
	}
}
