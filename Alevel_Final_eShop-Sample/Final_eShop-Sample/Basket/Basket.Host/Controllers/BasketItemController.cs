using Basket.Host.Models.Requests;
using Basket.Host.Services.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Basket.Host.Controllers
{
    [Route(ComponentDefaults.DefaultRoute)]
    [ApiController]
    [Authorize(Policy = AuthPolicy.AllowClientPolicy)]/*[Authorize(Policy = AuthPolicy.AllowClientPolicy)] this policy should be*/
    [Scope("basket.basketitem")]
    public class BasketItemController : ControllerBase
    {
        private readonly ILogger<BasketItemController> _logger;
        private readonly IBasketService _basketService;

        public BasketItemController(ILogger<BasketItemController> logger, IBasketService basketService)
        {
            _logger = logger;
            _basketService = basketService;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> AddProduct(AddProductRequest request)
        {
            string? basketId = User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;
            if (basketId != null)
            {
                await _basketService.AddProduct(basketId, request);
                return Ok();
            }
			else
			{
				return NotFound("BasketId is null");
			}
		}

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> RemoveProduct(AddProductRequest request)
        {
            string? basketId = User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;

            if (basketId != null)
			{
				await _basketService.RemoveProduct(basketId, request);
				return Ok(request.Id);
			}
			else
            {
				return NotFound("BasketId is null");
			}
		}
    }
}