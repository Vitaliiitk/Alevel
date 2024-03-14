﻿namespace Catalog.Host.Services.Interfaces
{
    public interface ICatalogTypeService
    {
        Task<int?> Add(int id, string type);
        Task<bool?> Delete(int id);
        Task<int?> Update(int id, string type);
    }
}
