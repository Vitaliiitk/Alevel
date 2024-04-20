using Order.Host.Data.Entities;

namespace Order.Host.Repositories.Interfaces
{
	public interface IOrderItemRepository
	{
		Task<int?> Add(string someNumberOfOrder, double totalPrice, List<OrderItems> orderItems);
		Task<Data.Entities.Order?> GetByUniqueOrderNumber(string? uniqueNumberOfOrder);
	}
}
