using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;

namespace ASP_MVC_PROJ.Filters
{
    public class LogActionFilter : IActionFilter
    {
        private readonly ILogger<LogActionFilter> _logger;

        public LogActionFilter(ILogger<LogActionFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var actionName = context.ActionDescriptor.DisplayName;
            var currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            _logger.LogInformation($"Action '{actionName}' called at {currentTime}");
            Log.Information($"Action '{actionName}' called at {currentTime}");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }
    }
}
