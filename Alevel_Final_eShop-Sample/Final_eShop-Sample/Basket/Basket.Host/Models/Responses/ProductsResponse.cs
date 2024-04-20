using System.ComponentModel.DataAnnotations;

namespace Basket.Host.Models.Responses
{
    public class ProductsResponse
    {
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public int Amount { get; set; }
		public double Price { get; set; }
		public string PictureFileName { get; set; } = null!;
    }
}
