using Basket.Host.Models;
using Basket.Host.Models.Requests;
using Basket.Host.Services.Interfaces;

namespace Basket.Host.Services
{
    public class BasketService : IBasketService
    {
        private readonly ICacheService _cacheService;

        public BasketService(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        public async Task<bool> AddProduct(string userId, AddProductRequest product)
        {
            if (!string.IsNullOrEmpty(userId))
            {
            var products = await _cacheService.GetAsync<List<Product>>(userId);

            // Check if products is null, initialize it with an empty list if null
            if (products == null)
            {
                products = new List<Product>();
            }

            var existedProduct = products.FirstOrDefault(x => x.Id == product.Id);
            if (existedProduct != null)
            {
                products[products.IndexOf(existedProduct)].Amount++;
            }
            else
            {
                products.Add(new Product() { Id = product.Id, Name = product.Name, Amount = 1, Price = product.Price, PictureFileName = product.PictureFileName });
            }

            await _cacheService.AddOrUpdateAsync(userId, products);
            return true;
			}

            return false;
		}

        public async Task<bool> RemoveProduct(string userId, AddProductRequest product)
        {
            var products = await _cacheService.GetAsync<List<Product>>(userId);

            if (products == null)
            {
                throw new Exception("The basket is already empty");
            }

            var existedProduct = products.FirstOrDefault(x => x.Id == product.Id);
            if (existedProduct == null)
            {
                throw new Exception($"Product does not already exist");
            }

            if (products[products.IndexOf(existedProduct)].Amount > 1)
            {
                products[products.IndexOf(existedProduct)].Amount--;
            }
            else
            {
                products.Remove(existedProduct);
            }

            await _cacheService.AddOrUpdateAsync(userId, products);
            return true;
        }

        public async Task<List<Product>> GetAllProducts(string userId)
        {
            var products = await _cacheService.GetAsync<List<Product>>(userId);
            if (products == null || products.Count == 0)
            {
                throw new Exception("There is no products in the basket");
            }
            else
            {
				return products;
			}
        }

        public async Task<bool> RemoveAllProducts(string userId)
        {
            return await _cacheService.DeleteAsync(userId);
        }
    }
}
