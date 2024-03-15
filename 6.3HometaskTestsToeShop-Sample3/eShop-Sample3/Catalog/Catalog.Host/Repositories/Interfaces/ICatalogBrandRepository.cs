using Catalog.Host.Data.Entities;
using Catalog.Host.Data;

namespace Catalog.Host.Repositories.Interfaces
{
    public interface ICatalogBrandRepository
    {
        Task<int?> Add(int catalogItemId, string brand);
        Task<bool?> Delete(int id);
        Task<int?> Update(int id, string brand);
    }
}
