using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;

namespace Catalog.Host.Repositories;

public class CatalogItemRepository : ICatalogItemRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<CatalogItemRepository> _logger;

    public CatalogItemRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<CatalogItemRepository> logger)
    {
        _dbContext = dbContextWrapper.DbContext;
        _logger = logger;
    }

    public async Task<PaginatedItems<CatalogItem>> GetByPageAsync(int pageIndex, int pageSize, int? brandFilter, int? typeFilter)
    {
        IQueryable<CatalogItem> query = _dbContext.CatalogItems;

        if (brandFilter.HasValue)
        {
            query = query.Where(w => w.CatalogBrandId == brandFilter.Value);
        }

        if (typeFilter.HasValue)
        {
            query = query.Where(w => w.CatalogTypeId == typeFilter.Value);
        }

        var totalItems = await query.LongCountAsync();

        var itemsOnPage = await query.OrderBy(c => c.Name)
           .Include(i => i.CatalogBrand)
           .Include(i => i.CatalogType)
           .Skip(pageSize * pageIndex)
           .Take(pageSize)
           .ToListAsync();

        return new PaginatedItems<CatalogItem>() { TotalCount = totalItems, Data = itemsOnPage };
    }

    public async Task<List<CatalogBrand>> GetAllBrandsAsync()
    {
        // Receive distinct catalog brands as a list of strings
        var brands = await _dbContext.CatalogItems
            .Select(c => c.CatalogBrand)
            .Distinct()
            .ToListAsync();

        return brands;
    }

    public async Task<List<CatalogType>> GetAllTypesAsync()
    {
        // Receive distinct catalog types as a list
        var types = await _dbContext.CatalogItems
            .Select(c => c.CatalogType)
            .Distinct()
            .ToListAsync();

        return types;
    }

    public async Task<PaginatedItems<CatalogItem>> GetByBrandAsync(int pageIndex, int pageSize, int brandId)
    {
        var query = _dbContext.CatalogItems.Where(item => item.CatalogBrandId == brandId);
        var totalItems = await query.CountAsync();

        var itemsOfTheSameBrandOnPage = await query
            .Include(i => i.CatalogBrand)
            .Include(i => i.CatalogType)
            .OrderBy(c => c.Name)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedItems<CatalogItem>() { TotalCount = totalItems, Data = itemsOfTheSameBrandOnPage };
    }

    public async Task<PaginatedItems<CatalogItem>> GetByTypeAsync(int pageIndex, int pageSize, int typeId)
    {
        var query = _dbContext.CatalogItems.Where(item => item.CatalogTypeId == typeId);
        var totalItems = await query.CountAsync();

        var itemsOfTheSameTypeOnPage = await query
            .Include(i => i.CatalogBrand)
            .Include(i => i.CatalogType)
            .OrderBy(c => c.Name)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedItems<CatalogItem>() { TotalCount = totalItems, Data = itemsOfTheSameTypeOnPage };
    }

    public async Task<CatalogItem?> GetById(int id)
    {
        var itemById = await _dbContext.CatalogItems
            .Include(i => i.CatalogBrand)
            .Include(i => i.CatalogType)
            .FirstOrDefaultAsync(i => i.Id == id);

        if (itemById != null)
        {
            return itemById;
        }
        else
        {
            return null;
        }
    }

    public async Task<int?> Add(string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName)
    {
        var item = await _dbContext.AddAsync(new CatalogItem
        {
            CatalogBrandId = catalogBrandId,
            CatalogTypeId = catalogTypeId,
            Description = description,
            Name = name,
            PictureFileName = pictureFileName,
            Price = price,
            AvailableStock = availableStock
        });

        await _dbContext.SaveChangesAsync();

        return item.Entity.Id;
    }

    public async Task<int?> Update(int id, string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName)
    {
        var itemToUpdate = await _dbContext.CatalogItems.FindAsync(id);

        if (itemToUpdate != null)
        {
            itemToUpdate.CatalogBrandId = catalogBrandId;
            itemToUpdate.CatalogTypeId = catalogTypeId;
            itemToUpdate.Description = description;
            itemToUpdate.Name = name;
            itemToUpdate.PictureFileName = pictureFileName;
            itemToUpdate.Price = price;
            itemToUpdate.AvailableStock = availableStock;

            await _dbContext.SaveChangesAsync();

            return id;
        }

        return null;
    }

    public async Task<bool?> Delete(int id)
    {
        var itemDelete = await _dbContext.CatalogItems.FindAsync(id);

        if (itemDelete != null)
        {
            _dbContext.Remove(itemDelete);

            await _dbContext.SaveChangesAsync();

            return true;
        }

        return false;
    }
}