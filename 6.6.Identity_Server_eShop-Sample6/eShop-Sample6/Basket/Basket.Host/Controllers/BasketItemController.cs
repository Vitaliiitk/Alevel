using Basket.Host.Models.Requests;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Basket.Host.Controllers
{
    [Route(ComponentDefaults.DefaultRoute)]
    [ApiController]
    [Authorize(Policy = AuthPolicy.AllowClientPolicy)]
    [Scope("basket.basketitem")]
    public class BasketItemController : ControllerBase
    {
        private readonly ILogger<BasketItemController> _logger;

        public BasketItemController(ILogger<BasketItemController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(typeof(object), (int)HttpStatusCode.OK)]
        public IActionResult Add(CreateProductRequest request)
        {
            var result = new CreateProductRequest()
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                AvailableStock = request.AvailableStock,
                CatalogBrandId = request.CatalogBrandId,
                CatalogTypeId = request.CatalogTypeId,
                PictureFileName = request.PictureFileName,
            };

            _logger.LogInformation($"lets's imagine that we added a new item to database with next parameters: name = {result.Name}, description = {result.Description}," +
                                   $"price = {result.Price}, availability = {result.AvailableStock}, brand id = {result.CatalogBrandId}, type id = , {result.CatalogTypeId}, picture file name = {result.PictureFileName}");

            return Ok();
        }
    }
}