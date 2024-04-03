using Catalog.Host.Data.Entities;
using Catalog.Host.Data;

namespace Catalog.Host.Repositories.Interfaces
{
    public interface ICatalogTypeRepository
    {
        Task<int?> Add(int id, string type);
        Task<bool?> Delete(int id);
        Task<int?> Update(int id, string type);
    }
}
