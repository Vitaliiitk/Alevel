using Basket.Host.Configuration;
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

        public BasketBffController(
            ILogger<BasketBffController> logger,
            IOptions<BasketConfig> config)
        {
            _logger = logger;
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(typeof(object), (int)HttpStatusCode.OK)]
        public IActionResult AnonymousLogAnyTestMethod()
        {
            string message = "This is a test message to log";

            _logger.LogInformation(message);

            return Ok(message);
        }

        [HttpPost]
        [ProducesResponseType(typeof(object), (int)HttpStatusCode.OK)]
        public IActionResult ShouldReadUserIdAndLogIt()
        {
            string userId = User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;

            _logger.LogInformation($"Probably this is an user's id: {userId}");

            return Ok(userId);
        }
    }
}
