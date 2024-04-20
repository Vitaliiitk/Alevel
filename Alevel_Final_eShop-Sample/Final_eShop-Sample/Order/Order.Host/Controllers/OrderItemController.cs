using System.Net;
using Infrastructure;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Order.Host.Data.Entities;
using Order.Host.Models.Requests;
using Order.Host.Models.Responses;
using Order.Host.Services.Interfaces;

namespace Order.Host.Controllers
{
	[ApiController]
	[Authorize(Policy = AuthPolicy.AllowClientPolicy)]
	[Scope("order.orderitem")]
	[Route(ComponentDefaults.DefaultRoute)]
	public class OrderItemController : ControllerBase
	{
		private readonly ILogger<OrderItemController> _logger;
		private readonly IOrderItemService _orderItemService;

		public OrderItemController(
			ILogger<OrderItemController> logger,
			IOrderItemService orderItemService)
		{
			_logger = logger;
			_orderItemService = orderItemService;
		}

		[HttpPost]
		[ProducesResponseType(typeof(OrderResponse), (int)HttpStatusCode.OK)]
		public async Task<IActionResult> AddOrder(OrderRequest request)
		{
			var orderItems = request.OrderItems.Select(item => new OrderItems
			{
				Name = item.Name,
				Amount = item.Amount,
				Price = item.Price
			}).ToList();

			var result = await _orderItemService.AddAsync(request.SomeNumberOfOrder, request.TotalPrice, orderItems);
			return Ok(new OrderResponse() { Id = result.Value, SomeNumberOfOrder = request.SomeNumberOfOrder, TotalPrice = request.TotalPrice });
		}
	}
}
