using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Models.Dtos;

public class CatalogItemDto
{
	[Range(1, int.MaxValue, ErrorMessage = "Value must be non-negative > 0.")]
	public int Id { get; set; }

	[Required]
	public string Name { get; set; } = null!;

	[StringLength(2000, MinimumLength = 0, ErrorMessage = "Description must be between 0 and 2000 characters.")]
	public string Description { get; set; } = null!;

	[Range(0, double.MaxValue, ErrorMessage = "Value must be non-negative.")]
	public decimal Price { get; set; }

	[Required]
	public string PictureUrl { get; set; } = null!;

	[Required]
	public CatalogTypeDto CatalogType { get; set; } = null!;

	[Required]
	public CatalogBrandDto CatalogBrand { get; set; } = null!;

	[Range(0, int.MaxValue, ErrorMessage = "Value must be non-negative.")]
	public int AvailableStock { get; set; }
}
