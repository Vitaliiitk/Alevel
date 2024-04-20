using System.ComponentModel.DataAnnotations;

namespace Order.Host.Models
{
	public class Products
	{
		[Range(1, int.MaxValue, ErrorMessage = "Value must be non-negative > 0.")]
		[Required]
		public int Id { get; set; }

		[StringLength(200, MinimumLength = 0, ErrorMessage = "Name can be between 0 and 200 characters.")]
		[Required]
		public string Name { get; set; } = null!;

		[Range(0, int.MaxValue, ErrorMessage = "Amount's value must be non-negative.")]
		[Required]
		public int Amount { get; set; }

		[Range(0, double.MaxValue, ErrorMessage = "Price value must be non-negative.")]
		[Required]
		public double Price { get; set; }
	}
}
