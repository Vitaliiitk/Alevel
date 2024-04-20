using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Models.Requests;

public class PaginatedItemsRequest<T>
    where T : notnull
{
	[Range(0, int.MaxValue, ErrorMessage = "Value must be non-negative.")]
	public int PageIndex { get; set; }

	[Range(0, int.MaxValue, ErrorMessage = "Value must be non-negative.")]
	public int PageSize { get; set; }

	public Dictionary<T, int>? Filters { get; set; }
}