using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogService
{
    Task<PaginatedItemsResponse<CatalogItemDto>> GetCatalogItemsAsync(int pageSize, int pageIndex);
    Task<List<string>> GetAllCatalogBrandsAsync();
    Task<List<string>> GetAllCatalogTypesAsync();

    Task<PaginatedItemsResponse<CatalogItemDto>> GetItemsByTypeAsync(int pageSize, int pageIndex, int typeId);

    Task<PaginatedItemsResponse<CatalogItemDto>> GetItemsByBrandAsync(int pageSize, int pageIndex, int brandId);

    Task<CatalogItemDto?> GetByIdAsync(int id);
}