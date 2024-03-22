using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Enums;
using Catalog.Host.Models.Response;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogService
{
    Task<PaginatedItemsResponse<CatalogItemDto>?> GetCatalogItemsAsync(int pageSize, int pageIndex, Dictionary<CatalogTypeFilter, int>? filters);
    Task<List<CatalogBrandDto>> GetAllCatalogBrandsAsync();

    Task<List<CatalogTypeDto>> GetAllCatalogTypesAsync();

    Task<PaginatedItemsResponse<CatalogItemDto>> GetItemsByTypeAsync(int pageIndex, int pageSize, int typeId);

    Task<PaginatedItemsResponse<CatalogItemDto>> GetItemsByBrandAsync(int pageIndex, int pageSize, int brandId);

    Task<CatalogItemDto?> GetByIdAsync(int id);
}