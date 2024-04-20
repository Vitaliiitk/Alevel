using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Models.Requests;

public class PaginatedItemsSameBrandsOrTypesRequest
{
	[Range(0, int.MaxValue, ErrorMessage = "Value must be non-negative.")]
	public int PageIndex { get; set; }

	[Range(0, int.MaxValue, ErrorMessage = "Value must be non-negative.")]
	public int PageSize { get; set; }
}