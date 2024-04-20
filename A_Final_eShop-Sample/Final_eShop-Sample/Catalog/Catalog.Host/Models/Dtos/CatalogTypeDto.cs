using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Models.Dtos;

public class CatalogTypeDto
{
	[Range(1, int.MaxValue, ErrorMessage = "Value must be non-negative > 0.")]
	public int Id { get; set; }

	[Required]
	public string Type { get; set; } = null!;
}