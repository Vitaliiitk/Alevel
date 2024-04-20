namespace MVC.Models.Responses
{
	public class OrderItemsResponse
	{
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public int Amount { get; set; }

		public double Price { get; set; }
	}
}
