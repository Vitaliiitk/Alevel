using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Models.Response;

public class PaginatedItemsResponse<T>
{
	[Range(0, int.MaxValue, ErrorMessage = "Value must be non-negative.")]
	public int PageIndex { get; init; }

	[Range(0, int.MaxValue, ErrorMessage = "Value must be non-negative.")]
	public int PageSize { get; init; }

	[Range(0, long.MaxValue, ErrorMessage = "Value must be non-negative.")]
	public long Count { get; init; }

	[Required(ErrorMessage = "Data cannot be null.")]
	public IEnumerable<T> Data { get; init; } = null!;
}
