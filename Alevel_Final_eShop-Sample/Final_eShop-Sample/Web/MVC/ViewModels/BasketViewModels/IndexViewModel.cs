using MVC.Models.Responses;

namespace MVC.ViewModels.BasketViewModels;

public class IndexViewModel
{
    public List<ListOfProductsInBasketResponse> ProductsInCart { get; set; }
}
