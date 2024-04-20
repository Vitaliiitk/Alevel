using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Models.Requests
{
    public class CreateBrandRequest
    {
		[Range(1, int.MaxValue, ErrorMessage = "Value must be non-negative > 0.")]
		public int Id { get; set; }

		[Required]
		public string Brand { get; set; } = null!;
    }
}
