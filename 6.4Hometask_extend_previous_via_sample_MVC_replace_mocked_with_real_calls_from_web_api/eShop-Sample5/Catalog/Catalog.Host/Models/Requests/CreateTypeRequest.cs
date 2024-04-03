namespace Catalog.Host.Models.Requests
{
    public class CreateTypeRequest
    {
        public int Id { get; set; }

        public string Type { get; set; } = null!;
    }
}
