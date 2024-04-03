﻿using Catalog.Host.Data;
using Catalog.Host.Repositories;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services
{
    public class CatalogBrandService : BaseDataService<ApplicationDbContext>, ICatalogBrandService
    {
        private readonly ICatalogBrandRepository _catalogBrandRepository;

        public CatalogBrandService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            ICatalogBrandRepository catalogBrandRepository)
            : base(dbContextWrapper, logger)
        {
            _catalogBrandRepository = catalogBrandRepository;
        }

        public Task<int?> Add(int id, string brand)
        {
            return ExecuteSafeAsync(() => _catalogBrandRepository.Add(id, brand));
        }

        public Task<int?> Update(int id, string brand)
        {
            return ExecuteSafeAsync(() => _catalogBrandRepository.Update(id, brand));
        }

        public Task<bool?> Delete(int id)
        {
            return ExecuteSafeAsync(() => _catalogBrandRepository.Delete(id));
        }
    }
}
