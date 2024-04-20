namespace MVC.Models.Requests
{
	public class OrderItemRequest
	{
		public string Name { get; set; } = null!;

		public int Amount { get; set; }

		public double Price { get; set; }
	}
}
