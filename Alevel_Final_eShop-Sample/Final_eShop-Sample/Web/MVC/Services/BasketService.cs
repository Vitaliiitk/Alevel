using MVC.Models.Requests;
using MVC.Models.Responses;
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

		public async Task<List<ListOfProductsInBasketResponse>> GetAllProductsInBasket()
		{
			var result = await _httpClient.SendAsync<List<ListOfProductsInBasketResponse>, object>(
			$"{_settings.Value.BasketUrlBff}/GetAllProducts",
			HttpMethod.Post,
			null);

			return result;
		}

		public async Task DeleteAllProductsInBasket()
		{
			await _httpClient.SendAsync<object, object>(
			$"{_settings.Value.BasketUrlBff}/RemoveAllProducts",
			HttpMethod.Post,
			null);
		}

		public async Task AddProduct(int id, string name, decimal price, string pictureUrl)
		{
			// TResponse,	TRequest
			await _httpClient.SendAsync<object, AddProductRequest>(
			$"{_settings.Value.BasketUrlApi}/AddProduct",
			HttpMethod.Post,
			new AddProductRequest()
			{
				Id = id,
				Name = name,
				Price = price,
				PictureFileName = pictureUrl
			});
		}

		public async Task DeleteProduct(int id, string name, decimal price, string pictureUrl)
		{
			// TResponse,	TRequest
			  await _httpClient.SendAsync<object, DeleteProductRequest>(
			  $"{_settings.Value.BasketUrlApi}/RemoveProduct",
			  HttpMethod.Post,
			  new DeleteProductRequest()
			  {
				  Id = id,
				  Name = name,
				  Price = price,
				  PictureFileName = pictureUrl
			  });
		}
	}
}
