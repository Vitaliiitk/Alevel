using MVC.Services.Interfaces;
using MVC.ViewModels.BasketViewModels;

namespace MVC.Controllers
{
	public class BasketController : Controller
	{
		private readonly IBasketService _basketService;
		private readonly ILogger<BasketController> _logger;

		public BasketController(IBasketService basketService, ILogger<BasketController> logger)
		{
			_basketService = basketService;
			_logger = logger;
		}

		public async Task<IActionResult> Index()
		{
			var productsInBasket = await _basketService.GetAllProductsInBasket();
			var vm = new IndexViewModel()
			{
				ProductsInCart = productsInBasket,
			};

			return View(vm);
		}

		[HttpPost]
		public async Task<IActionResult> AddProductToBasket(int id, string name, decimal price, string pictureUrl)
		{
			await _basketService.AddProduct(id, name, price, pictureUrl);

			return RedirectToAction("Index", "Catalog");
		}

		[HttpPost]
		public async Task<IActionResult> DeleteAllProductsFromBasket()
		{
			await _basketService.DeleteAllProductsInBasket();

			return RedirectToAction("Index", "Basket");
		}

		[HttpPost]
		public async Task<IActionResult> IncreaseByOneProductInBasket(int id, string name, decimal price, string pictureUrl)
		{
			await _basketService.AddProduct(id, name, price, pictureUrl);

			return RedirectToAction("Index", "Basket");
		}

		[HttpPost]
		public async Task<IActionResult> DeleteProductFromBasket(int id, string name, decimal price, string pictureUrl)
		{
			await _basketService.DeleteProduct(id, name, price, pictureUrl);
			return RedirectToAction("Index", "Basket");
		}
	}
}
