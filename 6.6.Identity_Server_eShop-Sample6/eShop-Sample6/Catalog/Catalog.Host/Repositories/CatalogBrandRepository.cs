using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;

namespace Catalog.Host.Repositories
{
    public class CatalogBrandRepository : ICatalogBrandRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CatalogBrandRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
        {
            _dbContext = dbContextWrapper.DbContext;
        }

        public async Task<int?> Add(int brandId, string brand)
        {
            var item = await _dbContext.AddAsync(new CatalogBrand
            {
                Id = brandId,
                Brand = brand,
            });

            await _dbContext.SaveChangesAsync();

            return item.Entity.Id;
        }

        public async Task<int?> Update(int id, string brand)
        {
            var itemToUpdate = await _dbContext.CatalogBrands.FindAsync(id);

            if (itemToUpdate != null)
            {
                itemToUpdate.Id = id;
                itemToUpdate.Brand = brand;

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
            var itemToDelete = await _dbContext.CatalogBrands.FindAsync(id);

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
