namespace Catalog.Host.Models.Response;

public class ItemResponse<T>
{
    public IEnumerable<T> Data { get; init; } = null!;
}
