using MVC.Services.Interfaces;
using MVC.ViewModels;
using MVC.ViewModels.OrderViewModels;

namespace MVC.Controllers
{
	public class OrderController : Controller
	{
		private readonly IOrderService _orderService;
		private readonly ILogger<OrderController> _logger;

		public OrderController(IOrderService orderService, ILogger<OrderController> logger)
		{
			_orderService = orderService;
			_logger = logger;
		}

		// This way we can transfer from MakeOrder number of an order to View and in View later use it for our purpose to display order's detail from Order's database
		public async Task<IActionResult> Index(string uniqueOrderNumber)
		{
			var responseFromApiOrderBff = await _orderService.ShowAnOrderDetails(uniqueOrderNumber);
			var listOfProducts = responseFromApiOrderBff.OrderItems.Select(item => new OrderProducts()
			{
				Name = item.Name,
				Amount = item.Amount,
				Price = item.Price
			}).ToList();

			var viewModel = new IndexViewModel()
			{
				SomeNumberOfOrder = responseFromApiOrderBff.SomeNumberOfOrder,
				TotalPrice = responseFromApiOrderBff.TotalPrice,
				OrderProducts = listOfProducts
			};

			return View(viewModel);
		}

		[HttpPost]
		public async Task<IActionResult> MakeAnOrder()
		{
			string? basketId = User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier"))?.Value;
			var uniqueNumberForOrder = DateTime.Now.ToString();
			string orderNumber = $"{basketId}_{uniqueNumberForOrder}";

			await _orderService.MakeAnOrder(orderNumber);

			return RedirectToAction("Index", "Order", new { uniqueOrderNumber = orderNumber });
		}
	}
}
