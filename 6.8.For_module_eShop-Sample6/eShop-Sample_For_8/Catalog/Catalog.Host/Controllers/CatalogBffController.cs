using Catalog.Host.Configurations;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Enums;
using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Response;
using Catalog.Host.Services.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace Catalog.Host.Controllers;

[ApiController]
[Authorize(Policy = AuthPolicy.AllowEndUserPolicy)]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogBffController : ControllerBase
{
    private readonly ILogger<CatalogBffController> _logger;
    private readonly ICatalogService _catalogService;
    private readonly IOptions<CatalogConfig> _config;

    public CatalogBffController(
        ILogger<CatalogBffController> logger,
        ICatalogService catalogService,
        IOptions<CatalogConfig> config)
    {
        _logger = logger;
        _catalogService = catalogService;
        _config = config;
    }

    [HttpPost]
    [ServiceFilter(typeof(LogUnauthorizedAccessFilter))]
    [AllowAnonymous]
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogItemDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Items(PaginatedItemsRequest<CatalogTypeFilter> request)
    {
        var result = await _catalogService.GetCatalogItemsAsync(request.PageSize, request.PageIndex, request.Filters);
        if (result != null && result.Count != 0)
        {
            _logger.LogInformation($"Method \"Items\" from catalofBffController sends httpPost to database, returns data: {JsonConvert.SerializeObject(result)}.");
            return Ok(result);
        }

        _logger.LogInformation($"Method \"Items\" from catalofBffController sends httpPost to database, returns: {result}");
        return NotFound(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogItemDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetItemsBySameBandsAsync(int brandId, PaginatedItemsSameBrandsOrTypesRequest request)
    {
        var result = await _catalogService.GetItemsByBrandAsync(request.PageIndex, request.PageSize, brandId);
        if (result != null && result.Count != 0)
        {
            _logger.LogInformation($"Method \"GetItemsBySameBrandsAsync\" from catalofBffController sends httpPost to database, returns data: {JsonConvert.SerializeObject(result)}.");
            return Ok(result);
        }

        _logger.LogInformation($"Method \"GetItemsBySameBrandsAsync\" from catalofBffController sends httpPost to database, returns: {JsonConvert.SerializeObject(result)}");
        return NotFound(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogItemDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetItemsBySameTypesAsync(int typeId, PaginatedItemsSameBrandsOrTypesRequest request)
    {
        var result = await _catalogService.GetItemsByTypeAsync(request.PageIndex, request.PageSize, typeId);
        if (result != null && result.Count != 0)
        {
            _logger.LogInformation($"Method \"GetItemsBySameTypessAsync\" from catalofBffController sends httpPost to database, returns data: {JsonConvert.SerializeObject(result)}.");
            return Ok(result);
        }

        _logger.LogInformation($"Method \"GetItemsBySameBrandsAsync\" from catalofBffController sends httpPost to database, returns: {JsonConvert.SerializeObject(result)}");
        return NotFound(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(CatalogItemDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetItemByIdAsync(int id)
    {
        if (User?.Identity?.IsAuthenticated != true)
        {
            _logger.LogInformation("Need authorization to access this method");
            return Unauthorized();
        }

        var result = await _catalogService.GetByIdAsync(id);
        if (result != null)
        {
            _logger.LogInformation($"Method \"GetItemByIdsAsync\" from catalofBffController sends httpPost to database, returns data: {JsonConvert.SerializeObject(result)}");

            return Ok(result);
        }

        _logger.LogInformation($"Method \"GetItemByIdsAsync\" from catalofBffController sends httpPost to database, returns: {JsonConvert.SerializeObject(result)}");
        return NotFound(result);
    }

    [HttpPost]
    [ServiceFilter(typeof(LogUnauthorizedAccessFilter))]
    [AllowAnonymous]
    [ProducesResponseType(typeof(List<CatalogBrandDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetBrandsAsync()
    {
        var result = await _catalogService.GetAllCatalogBrandsAsync();
        if (result != null)
        {
            _logger.LogInformation($"Method \"GetBrandsAsync\" from catalofBffController sends httpPost to database, returns data: {JsonConvert.SerializeObject(result)}.");

            return Ok(result);
        }

        _logger.LogInformation($"Method \"GetBrandsAsync\" from catalofBffController sends httpPost to database, returns: {JsonConvert.SerializeObject(result)}");
        return NotFound(result);
    }

    [HttpPost]
    [ServiceFilter(typeof(LogUnauthorizedAccessFilter))]
    [AllowAnonymous]
    [ProducesResponseType(typeof(List<CatalogTypeDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetTypesAsync()
    {
        var result = await _catalogService.GetAllCatalogTypesAsync();
        if (result != null)
        {
            _logger.LogInformation($"Method \"GetTypesAsync\" from catalofBffController sends httpPost to database, returns data: {JsonConvert.SerializeObject(result)}");

            return Ok(result);
        }

        _logger.LogInformation($"Method \"GetBrandsAsync\" from catalofBffController sends httpPost to database, returns: empty string");
        return NotFound(result);
    }
}