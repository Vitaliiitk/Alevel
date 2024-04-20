using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Models.Response;

public class ItemResponse<T>
{
	[Required(ErrorMessage = "Data cannot be null.")]
	public IEnumerable<T> Data { get; init; } = null!;
}
