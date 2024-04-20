using Microsoft.AspNetCore.Mvc.Filters;

namespace Catalog.Host
{
    public class LogUnauthorizedAccessFilter : IAuthorizationFilter
    {
        private readonly ILogger<LogUnauthorizedAccessFilter> _logger;

        public LogUnauthorizedAccessFilter(ILogger<LogUnauthorizedAccessFilter> logger)
        {
            _logger = logger;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User?.Identity?.IsAuthenticated != true)
            {
                _logger.LogInformation("Unauthorized access attempt to {Action} method", context.ActionDescriptor.DisplayName);
            }
        }
    }
}
