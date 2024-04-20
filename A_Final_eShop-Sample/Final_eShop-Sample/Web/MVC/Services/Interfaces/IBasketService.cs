using MVC.Models.Responses;

namespace MVC.Services.Interfaces
{
    public interface IBasketService
    {
		Task AddProduct(int id, string name, decimal price, string pictureUrl);
		Task DeleteProduct(int id, string name, decimal price, string pictureUrl);
		Task<List<ListOfProductsInBasketResponse>> GetAllProductsInBasket();
		Task DeleteAllProductsInBasket();
	}
}
