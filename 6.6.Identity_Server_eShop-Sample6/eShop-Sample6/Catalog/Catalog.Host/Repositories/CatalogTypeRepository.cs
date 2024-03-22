using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;

namespace Catalog.Host.Repositories
{
    public class CatalogTypeRepository : ICatalogTypeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CatalogTypeRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
        {
            _dbContext = dbContextWrapper.DbContext;
        }

        public async Task<int?> Add(int id, string type)
        {
            var item = await _dbContext.AddAsync(new CatalogType
            {
                Id = id,
                Type = type,
            });

            await _dbContext.SaveChangesAsync();

            return item.Entity.Id;
        }

        public async Task<int?> Update(int id, string type)
        {
            var itemToUpdate = await _dbContext.CatalogTypes.FindAsync(id);

            if (itemToUpdate != null)
            {
                itemToUpdate.Id = id;
                itemToUpdate.Type = type;

                await _dbContext.SaveChangesAsync();

                return itemToUpdate.Id;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool?> Delete(int id)
        {
            var itemToDelete = await _dbContext.CatalogTypes.FindAsync(id);

            if (itemToDelete != null)
            {
                _dbContext.Remove(itemToDelete);

                await _dbContext.SaveChangesAsync();

                return true;
            }

            return null;
        }
    }
}
