using Basket.Host.Configurations;
using Basket.Host.Models.Responses;
using Basket.Host.Services.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Basket.Host.Controllers
{
	[Route(ComponentDefaults.DefaultRoute)]
	[ApiController]
	[Authorize(Policy = AuthPolicy.AllowEndUserPolicy)]
	public class BasketBffController : ControllerBase
	{
		private readonly ILogger<BasketBffController> _logger;
		private readonly IOptions<BasketConfig> _config;
		private readonly IBasketService _basketService;

		public BasketBffController(ILogger<BasketBffController> logger, IOptions<BasketConfig> config, IBasketService basketService)
		{
			_logger = logger;
			_config = config;
			_basketService = basketService;
		}

		[HttpPost]
		[ProducesResponseType(typeof(List<ProductsResponse>), (int)HttpStatusCode.OK)]
		[ProducesResponseType((int)HttpStatusCode.NotFound)]
		public async Task<IActionResult> GetAllProducts()
		{
			string? basketId = User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;
			if (basketId != null)
			{
				try
				{
					var allProductsInBasket = await _basketService.GetAllProducts(basketId);
					return Ok(allProductsInBasket);
				}
				catch (Exception)
				{
					return NotFound();
				}
			}

			return NotFound();
		}

		[HttpPost]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		[ProducesResponseType((int)HttpStatusCode.NotFound)]
		public async Task<IActionResult> RemoveAllProducts()
		{
			string? basketId = User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;
			if (basketId != null)
			{
				var resultOfDeletion = await _basketService.RemoveAllProducts(basketId);
				if (resultOfDeletion)
				{
					return Ok(basketId);
				}
			}

			return NotFound();
		}
	}
}
