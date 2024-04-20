namespace Catalog.Host.Services.Interfaces
{
    public interface ICatalogBrandService
    {
        Task<int?> AddAsync(int id, string brand);
        Task<bool?> DeleteAsync(int id);
        Task<int?> UpdateAsync(int id, string brand);
    }
}
