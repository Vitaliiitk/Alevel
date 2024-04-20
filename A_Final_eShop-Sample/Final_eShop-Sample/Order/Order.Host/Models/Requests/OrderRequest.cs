using System.ComponentModel.DataAnnotations;
using Order.Host.Data.Entities;

namespace Order.Host.Models.Requests
{
	public class OrderRequest
	{
		[StringLength(100, MinimumLength = 0, ErrorMessage = "Unique number of an order is limited to 100 characters.")]
		[Required]
		public string SomeNumberOfOrder { get; set; } = null!;

		[Range(0, double.MaxValue, ErrorMessage = "Total price value of an order must be non-negative.")]
		[Required]
		public double TotalPrice { get; set; }

		public List<OrderItemRequest> OrderItems { get; set; } = null!;
	}
}
