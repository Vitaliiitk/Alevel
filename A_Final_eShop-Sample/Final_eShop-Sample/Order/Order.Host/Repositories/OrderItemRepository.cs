using Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Order.Host.Data;
using Order.Host.Data.Entities;
using Order.Host.Repositories.Interfaces;

namespace Order.Host.Repositories
{
	public class OrderItemRepository : IOrderItemRepository
	{
		private readonly ApplicationDbContext _dbContext;
		private readonly ILogger<OrderItemRepository> _logger;

		public OrderItemRepository(
	IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
	ILogger<OrderItemRepository> logger)
		{
			_dbContext = dbContextWrapper.DbContext;
			_logger = logger;
		}

		public async Task<int?> Add(string someNumberOfOrder, double totalPrice, List<OrderItems> orderItems)
		{
			var order = new Data.Entities.Order
			{
				SomeNumberOfOrder = someNumberOfOrder,
				TotalPrice = totalPrice
			};
			var item = await _dbContext.AddAsync(order);

			await _dbContext.SaveChangesAsync();

			foreach (var product in orderItems)
			{
				product.OrderId = order.Id;
				_dbContext.OrderItems.Add(product);
			}

			await _dbContext.SaveChangesAsync();

			return order.Id;
		}

		public async Task<Data.Entities.Order?> GetByUniqueOrderNumber(string? uniqueNumberOfOrder)
		{
			var itemByUniqueNumber = await _dbContext.Orders
				.Include(i => i.OrderItems)
				.FirstOrDefaultAsync(i => i.SomeNumberOfOrder == uniqueNumberOfOrder);

			if (itemByUniqueNumber != null)
			{
				return itemByUniqueNumber;
			}
			else
			{
				return null;
			}
		}
	}
}
