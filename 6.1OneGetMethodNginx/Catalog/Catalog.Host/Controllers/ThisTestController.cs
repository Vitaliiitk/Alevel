using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers;

[ApiController]
[Route("[controller]")]
public class ThisTestController : ControllerBase
{
    private static readonly string[] ThisIsAListOfOurTestProducts = new[]
    {
        "For example, this is a Product#1", "For example, this is a Product#2", "For example, this is a Product#3", "For example, this is a Product#4", "For example, this is a Product#5", 
        "For example, this is a Product#6", "For example, this is a Product#7", "For example, this is a Product#8", "For example, this is a Product#9", "For example, this is a Product#10"
    };

    private readonly ILogger<ThisTestController> _logger;

    public ThisTestController(ILogger<ThisTestController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public string[] Get()
    {
        return ThisIsAListOfOurTestProducts;

    }
}