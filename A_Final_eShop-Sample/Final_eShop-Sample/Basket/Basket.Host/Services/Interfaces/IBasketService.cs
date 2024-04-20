using Basket.Host.Models;
using Basket.Host.Models.Requests;

namespace Basket.Host.Services.Interfaces
{
    public interface IBasketService
    {
        Task<bool> AddProduct(string userId, AddProductRequest product);

        Task<bool> RemoveProduct(string userId, AddProductRequest product);

        Task<List<Product>> GetAllProducts(string userId);

        Task<bool> RemoveAllProducts(string userId);
    }
}
