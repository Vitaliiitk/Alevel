using Catalog.Host.Data;
using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces;

public interface ICatalogItemRepository
{
    Task<PaginatedItems<CatalogItem>> GetByPageAsync(int pageIndex, int pageSize, int? brandFilter, int? typeFilter);
    Task<int?> Add(string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName);
    Task<List<CatalogBrand>> GetAllBrandsAsync();
    Task<List<CatalogType>> GetAllTypesAsync();
    Task<PaginatedItems<CatalogItem>> GetByBrandAsync(int pageIndex, int pageSize, int brandId);
    Task<PaginatedItems<CatalogItem>> GetByTypeAsync(int pageIndex, int pageSize, int typeId);
    Task<CatalogItem?> GetById(int id);
    Task<int?> Update(int id, string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName);
    Task<bool?> Delete(int id);
}