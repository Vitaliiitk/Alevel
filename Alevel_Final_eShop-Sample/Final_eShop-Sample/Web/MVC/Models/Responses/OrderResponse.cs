namespace MVC.Models.Responses
{
	public class OrderResponse
	{
		public int Id { get; set; }
		public string SomeNumberOfOrder { get; set; } = null!;
		public double TotalPrice { get; set; }

		public List<OrderItemsResponse> OrderItems { get; set; } = null!;
	}
}
