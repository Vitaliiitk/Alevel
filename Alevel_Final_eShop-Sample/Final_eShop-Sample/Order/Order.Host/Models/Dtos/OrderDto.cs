using System.ComponentModel.DataAnnotations;

namespace Order.Host.Models.Dtos
{
	public class OrderDto
	{
		public int Id { get; set; }
		public string SomeNumberOfOrder { get; set; } = null!;
		public double TotalPrice { get; set; }

		public List<OrderItemsDto> OrderItems { get; set; } = null!;
	}
}
