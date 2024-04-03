namespace Catalog.Host.Services.Interfaces
{
    public interface ICatalogBrandService
    {
        Task<int?> Add(int id, string brand);
        Task<bool?> Delete(int id);
        Task<int?> Update(int id, string brand);
    }
}
