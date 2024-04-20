using MVC.Models.Requests;
using MVC.Models.Responses;
using MVC.Services.Interfaces;

namespace MVC.Services
{
	public class OrderService : IOrderService
	{
		private readonly IOptions<AppSettings> _settings;
		private readonly IHttpClientService _httpClient;
		private readonly ILogger<BasketService> _logger;
		private readonly IBasketService _basketService;

		public OrderService(IHttpClientService httpClient, IOptions<AppSettings> settings, ILogger<BasketService> logger, IBasketService basketService)
		{
			_httpClient = httpClient;
			_settings = settings;
			_logger = logger;
			_basketService = basketService;
		}

		public async Task<object> MakeAnOrder(string uniqueNumberOfOrder)
		{
			double totalPrice = 0;
			string numberOfAnOrder = uniqueNumberOfOrder;

			// We want to take products we selected from Redis cache and put them to Order's database
			var productsInBasket = await _basketService.GetAllProductsInBasket();
			var productsForOrder = productsInBasket.Select(item => new OrderItemRequest
			{
				Name = item.Name,
				Price = item.Price,
				Amount = item.Amount
			}).ToList();

			foreach (var item in productsInBasket)
			{
				totalPrice = totalPrice + (item.Price * item.Amount);
			}

			var result = await _httpClient.SendAsync<object, OrderRequest>(
				  $"{_settings.Value.OrderUrlApi}/AddOrder",
				  HttpMethod.Post,
				  new OrderRequest()
				  {
					  SomeNumberOfOrder = numberOfAnOrder,
					  TotalPrice = totalPrice,
					  OrderItems = productsForOrder
				  });

			// After http post to endpoint, clear our Redis cache basket
			await _basketService.DeleteAllProductsInBasket();
			return result;
		}

		public async Task<OrderResponse?> ShowAnOrderDetails(string orderNumber)
		{
			if (!string.IsNullOrEmpty(orderNumber))
			{
				var result = await _httpClient.SendAsync<OrderResponse, GetByOrderNumberRequest>(
					$"{_settings.Value.OrderUrlBff}/GetOrderByUniqueOrderNumber",
					HttpMethod.Post,
					new GetByOrderNumberRequest() { UniqueNumberOfOrder = orderNumber });

				return result;
			}

			return null;
		}
	}
}
