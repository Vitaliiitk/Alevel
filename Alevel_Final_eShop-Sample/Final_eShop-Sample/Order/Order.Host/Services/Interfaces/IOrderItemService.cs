using Order.Host.Data.Entities;
using Order.Host.Models.Dtos;

namespace Order.Host.Services.Interfaces
{
	public interface IOrderItemService
	{
		Task<int?> AddAsync(string someNumberOfOrder, double totalPrice, List<OrderItems> orderItems);
		Task<OrderDto?> GetByUniqueOrderNumberAsync(string? uniqueNumberOfOrder);
	}
}
