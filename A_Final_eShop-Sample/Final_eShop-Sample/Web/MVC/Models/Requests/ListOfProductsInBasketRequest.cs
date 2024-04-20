namespace MVC.Models.Requests
{
	public class ListOfProductsInBasketRequest
	{
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public double Price { get; set; }

		public int Amount { get; set; }

		public string PictureFileName { get; set; } = null!;
	}
}
