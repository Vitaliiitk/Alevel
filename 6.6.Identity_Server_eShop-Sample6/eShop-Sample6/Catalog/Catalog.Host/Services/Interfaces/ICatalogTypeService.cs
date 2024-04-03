namespace Catalog.Host.Services.Interfaces
{
    public interface ICatalogTypeService
    {
        Task<int?> AddAsync(int id, string type);
        Task<bool?> DeleteAsync(int id);
        Task<int?> UpdateAsync(int id, string type);
    }
}
