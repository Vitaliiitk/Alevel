using System.ComponentModel.DataAnnotations;

namespace Order.Host.Models.Requests
{
	public class GetByOrderNumberRequest
	{
		[StringLength(100, MinimumLength = 0, ErrorMessage = "Unique number of an order is limited to 100 characters.")]
		[Required]
		public string? UniqueNumberOfOrder { get; set; }
	}
}
