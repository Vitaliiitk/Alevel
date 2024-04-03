using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Models.Requests;

public class CreateProductRequest
{
    [Required]
    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public string PictureFileName { get; set; } = null!;

    public int CatalogTypeId { get; set; }

    public int CatalogBrandId { get; set; }

    public int AvailableStock { get; set; }
}