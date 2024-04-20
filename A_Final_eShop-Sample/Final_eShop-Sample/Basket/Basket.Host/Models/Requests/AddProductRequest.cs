using System.ComponentModel.DataAnnotations;

namespace Basket.Host.Models.Requests
{
	public class AddProductRequest
	{
		[Range(1, int.MaxValue, ErrorMessage = "Value must be non-negative > 0.")]
		[Required]
		public int Id { get; set; }

		[StringLength(200, MinimumLength = 0, ErrorMessage = "Name must be between 0 and 200 characters.")]
		[Required]
		public string Name { get; set; } = null!;

		[Range(0, double.MaxValue, ErrorMessage = "Value must be non-negative.")]
		[Required]
		public double Price { get; set; }

		[StringLength(2000, MinimumLength = 0, ErrorMessage = "Url must be between 0 and 2000 characters.")]
		[Required]
		public string PictureFileName { get; set; } = null!;
	}
}
