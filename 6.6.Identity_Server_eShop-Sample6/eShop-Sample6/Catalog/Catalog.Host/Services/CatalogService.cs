using Catalog.Host.Data;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Enums;
using Catalog.Host.Models.Response;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Newtonsoft.Json;

namespace Catalog.Host.Services;

public class CatalogService : BaseDataService<ApplicationDbContext>, ICatalogService
{
    private readonly ICatalogItemRepository _catalogItemRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<BaseDataService<ApplicationDbContext>> _logger;

    public CatalogService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICatalogItemRepository catalogItemRepository,
        IMapper mapper)
        : base(dbContextWrapper, logger)
    {
        _catalogItemRepository = catalogItemRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<PaginatedItemsResponse<CatalogItemDto>?> GetCatalogItemsAsync(int pageSize, int pageIndex, Dictionary<CatalogTypeFilter, int>? filters)
    {
        return await ExecuteSafeAsync(async () =>
        {
            int? brandFilter = null;
            int? typeFilter = null;

            if (filters != null)
            {
                if (filters.TryGetValue(CatalogTypeFilter.Brand, out var brand))
                {
                    brandFilter = brand;
                }

                if (filters.TryGetValue(CatalogTypeFilter.Type, out var type))
                {
                    typeFilter = type;
                }
            }

            var result = await _catalogItemRepository.GetByPageAsync(pageIndex, pageSize, brandFilter, typeFilter);
            if (result == null)
            {
                return null;
            }

            return new PaginatedItemsResponse<CatalogItemDto>()
            {
                Count = result.TotalCount,
                Data = result.Data.Select(s => _mapper.Map<CatalogItemDto>(s)).ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize
            };
        });
    }

    public async Task<List<CatalogBrandDto>> GetAllCatalogBrandsAsync()
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogItemRepository.GetAllBrandsAsync();

            return result.Select(s => _mapper.Map<CatalogBrandDto>(s)).ToList();
        });
    }

    public async Task<List<CatalogTypeDto>> GetAllCatalogTypesAsync()
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogItemRepository.GetAllTypesAsync();

            return result.Select(s => _mapper.Map<CatalogTypeDto>(s)).ToList();
        });
    }

    public async Task<CatalogItemDto?> GetByIdAsync(int id)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogItemRepository.GetById(id);

            if (result == null)
            {
                return null;
            }

            var returnItem = new CatalogItemDto()
            {
                Id = result.Id,
                Name = result.Name,
                Description = result.Description,
                Price = result.Price,
                PictureUrl = result.PictureFileName,
                AvailableStock = result.AvailableStock,

                // Map CatalogBrand entity to CatalogBrandDto
                CatalogBrand = new CatalogBrandDto
                {
                    Id = result.CatalogBrand.Id,
                    Brand = result.CatalogBrand.Brand
                },

                // Map CatalogType entity to CatalogTypeDto
                CatalogType = new CatalogTypeDto
                {
                    Id = result.CatalogType.Id,
                    Type = result.CatalogType.Type
                }
            };

            return returnItem;
        });

        // _mapper.Map<CatalogItemDto>(result); / Data = result.Data.Select(s => _mapper.Map<CatalogItemDto>(s)).ToList(),
    }

    public async Task<PaginatedItemsResponse<CatalogItemDto>> GetItemsByBrandAsync(int pageIndex, int pageSize, int brandId)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogItemRepository.GetByBrandAsync(pageIndex, pageSize, brandId);

            _logger.LogDebug($"result: {JsonConvert.SerializeObject(result)}");

            return new PaginatedItemsResponse<CatalogItemDto>()
            {
                Count = result.TotalCount,
                Data = result.Data.Select(s => _mapper.Map<CatalogItemDto>(s)).ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize
            };
        });
    }

    public async Task<PaginatedItemsResponse<CatalogItemDto>> GetItemsByTypeAsync(int pageIndex, int pageSize, int typeId)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogItemRepository.GetByTypeAsync(pageIndex, pageSize, typeId);
            return new PaginatedItemsResponse<CatalogItemDto>()
            {
                Count = result.TotalCount,
                Data = result.Data.Select(s => _mapper.Map<CatalogItemDto>(s)).ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize
            };
        });
    }
}