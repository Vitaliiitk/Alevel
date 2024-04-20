using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Models.Requests;

public class CreateProductRequest
{
	[Required]
	public string Name { get; set; } = null!;

	[StringLength(2000, MinimumLength = 0, ErrorMessage = "Description must be between 0 and 2000 characters.")]
	public string Description { get; set; } = null!;

	[Range(0, double.MaxValue, ErrorMessage = "Value must be non-negative.")]
	public decimal Price { get; set; }

	[Required]
	public string PictureFileName { get; set; } = null!;

	[Range(1, int.MaxValue, ErrorMessage = "Value must be non-negative > 0.")]
	public int CatalogTypeId { get; set; }

	[Range(1, int.MaxValue, ErrorMessage = "Value must be non-negative > 0.")]
	public int CatalogBrandId { get; set; }

	[Range(0, int.MaxValue, ErrorMessage = "Value must be non-negative.")]
	public int AvailableStock { get; set; }
}