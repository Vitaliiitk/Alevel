using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Models.Requests
{
	public class CreateTypeRequest
	{
		[Range(1, int.MaxValue, ErrorMessage = "Value must be non-negative > 0.")]
		public int Id { get; set; }

		[Required]
		public string Type { get; set; } = null!;
	}
}
