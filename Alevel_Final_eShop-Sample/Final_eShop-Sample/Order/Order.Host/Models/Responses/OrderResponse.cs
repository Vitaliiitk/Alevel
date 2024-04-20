using System.ComponentModel.DataAnnotations;
using Order.Host.Data.Entities;

namespace Order.Host.Models.Responses
{
	public class OrderResponse
	{
		public int Id { get; set; }
		public string SomeNumberOfOrder { get; set; } = null!;
		public double TotalPrice { get; set; }
	}
}
