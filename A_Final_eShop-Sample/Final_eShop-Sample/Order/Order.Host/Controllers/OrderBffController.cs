using System.Net;
using Infrastructure;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Order.Host.Configurations;
using Order.Host.Models.Dtos;
using Order.Host.Models.Requests;
using Order.Host.Services.Interfaces;

namespace Order.Host.Controllers
{
	[ApiController]
	[Authorize(Policy = AuthPolicy.AllowEndUserPolicy)]
	[Route(ComponentDefaults.DefaultRoute)]
	public class OrderBffController : ControllerBase
	{
		private readonly ILogger<OrderBffController> _logger;
		private readonly IOrderItemService _orderItemService;
		private readonly IOptions<OrderConfig> _config;

		public OrderBffController(ILogger<OrderBffController> logger, IOrderItemService orderItemService, IOptions<OrderConfig> config)
		{
			_logger = logger;
			_orderItemService = orderItemService;
			_config = config;
		}

		[HttpPost]
		[ProducesResponseType(typeof(OrderDto), (int)HttpStatusCode.OK)]
		[ProducesResponseType((int)HttpStatusCode.NotFound)]
		public async Task<IActionResult> GetOrderByUniqueOrderNumber(GetByOrderNumberRequest request)
		{
			_logger.LogInformation($"This is a request from MVC our endpoint receives {request.UniqueNumberOfOrder}");

			if (User?.Identity?.IsAuthenticated != true)
			{
				_logger.LogInformation("Need authorization to access this method");
				return Unauthorized();
			}

			var result = await _orderItemService.GetByUniqueOrderNumberAsync(request.UniqueNumberOfOrder);
			if (result != null)
			{
				_logger.LogInformation($"Method \"GetByUniqueOrderNumberAsync\" from orderBffController sends httpPost to database, returns data: {JsonConvert.SerializeObject(result)}");

				return Ok(result);
			}

			_logger.LogInformation($"Method \"GetByUniqueOrderNumberAsync\" from orderBffController sends httpPost to database, returns: {JsonConvert.SerializeObject(result)}");
			return NotFound(result);
		}
	}
}
