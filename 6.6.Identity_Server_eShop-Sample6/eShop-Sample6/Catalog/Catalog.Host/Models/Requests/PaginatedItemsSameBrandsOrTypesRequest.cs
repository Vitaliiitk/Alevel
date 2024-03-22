namespace Catalog.Host.Models.Requests;

public class PaginatedItemsSameBrandsOrTypesRequest
{
    public int PageIndex { get; set; }

    public int PageSize { get; set; }
}