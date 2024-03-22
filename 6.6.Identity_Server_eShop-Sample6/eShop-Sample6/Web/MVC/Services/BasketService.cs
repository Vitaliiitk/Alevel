using MVC.Services.Interfaces;
using MVC.ViewModels;

namespace MVC.Services
{
    public class BasketService : IBasketService
    {
        private readonly IOptions<AppSettings> _settings;
        private readonly IHttpClientService _httpClient;
        private readonly ILogger<BasketService> _logger;

        public BasketService(IHttpClientService httpClient, IOptions<AppSettings> settings, ILogger<BasketService> logger)
        {
            _httpClient = httpClient;
            _settings = settings;
            _logger = logger;
        }

        public async Task<Basket> LogAnyTestMethod()
        {
            string? testMessage = null;

/*            object objectToSerialize = new { testTestToDisplayOnMVC = "" };*/

            var result = await _httpClient.SendAsync<Basket, object>($"{_settings.Value.BasketUrl}/AnonymousLogAnyTestMethod",
               HttpMethod.Post,
               null);

            _logger.LogInformation($"MVC BasketService method LogAnyTestMethod return after http to: {result.testString}");

            return new Basket()
            {
                testString = result.testString
            };
        }
    }
}
