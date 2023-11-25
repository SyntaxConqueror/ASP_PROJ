using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;

namespace ASP_MVC_PROJ.Filters
{
    public class UniqueUsersFilter : IActionFilter
    {
        private readonly ILogger<UniqueUsersFilter> _logger;
        private readonly HashSet<string> _uniqueUsers = new HashSet<string>();
        

        public UniqueUsersFilter(ILogger<UniqueUsersFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var user = context.HttpContext.User.Identity?.Name;

            if (_uniqueUsers.Add(user))
            {
                Log.Information($"New unique user: {user}");
                _logger.LogInformation($"New unique user: {user}");
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }
    }
}
