using MVC.Models.Responses;

namespace MVC.Services.Interfaces
{
	public interface IOrderService
	{
		Task<object> MakeAnOrder(string uniqueNumberOfOrder);

		Task<OrderResponse?> ShowAnOrderDetails(string orderNumber);
	}
}
