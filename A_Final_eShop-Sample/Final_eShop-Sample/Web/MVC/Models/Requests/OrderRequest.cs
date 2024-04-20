namespace MVC.Models.Requests
{
	public class OrderRequest
	{
		public string SomeNumberOfOrder { get; set; } = null!;

		public double TotalPrice { get; set; }

		public List<OrderItemRequest> OrderItems { get; set; } = null!;
	}
}
