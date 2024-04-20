using System.ComponentModel.DataAnnotations;

namespace Order.Host.Models.Dtos
{
	public class OrderItemsDto
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public int Amount { get; set; }
		public double Price { get; set; }
	}
}
