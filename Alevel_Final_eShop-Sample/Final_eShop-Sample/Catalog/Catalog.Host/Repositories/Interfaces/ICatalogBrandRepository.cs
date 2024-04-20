namespace Catalog.Host.Repositories.Interfaces
{
    public interface ICatalogBrandRepository
    {
        Task<int?> Add(int catalogItemId, string brand);
        Task<bool?> Delete(int id);
        Task<int?> Update(int id, string brand);
    }
}
