using MVC.Services.Interfaces;

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

        public async Task<string> LogAnyTestMethod()
        {
            string? userIdToLog = null;
            string testresult = "test id";

            var result = await _httpClient.SendAsync<string, object>($"{_settings.Value.BasketUrl}/AnonymousLogAnyTestMethod",
               HttpMethod.Post,
               null);

            userIdToLog = result.ToString();

            _logger.LogInformation($"MVC BasketService method LogAnyTestMethod return after http to: {result}");

            return userIdToLog;
        }
    }
}
