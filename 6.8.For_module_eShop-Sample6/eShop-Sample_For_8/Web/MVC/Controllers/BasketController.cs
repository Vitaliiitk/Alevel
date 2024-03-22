using Microsoft.AspNetCore.Mvc;
using MVC.Services;
using MVC.Services.Interfaces;
using MVC.ViewModels.BasketViewModels;
using System.Runtime;

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
            var basket = await _basketService.LogAnyTestMethod();
            if (basket == null)
            {
                return View("Error");
            }
            var vm = new IndexViewModel()
            {
                TextMessage = basket
            };

            _logger.LogInformation($"MVC BasketController's method Index return: {vm}");

            return View(vm);
        }
    }
}
