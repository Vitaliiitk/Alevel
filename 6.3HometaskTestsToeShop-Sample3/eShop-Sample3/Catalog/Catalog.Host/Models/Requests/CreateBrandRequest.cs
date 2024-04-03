namespace Catalog.Host.Models.Requests
{
    public class CreateBrandRequest
    {
        public int Id { get; set; }

        public string Brand { get; set; } = null!;
    }
}
