using Microsoft.AspNetCore.Diagnostics;

namespace Eaconomy.API.Middlewares
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
                _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, 
            Exception exception, 
            CancellationToken cancellationToken)
        {
            _logger.LogInformation("Seri Log is Working");
            _logger.LogError(exception, exception.Message);

            var problemDetails = new Microsoft.AspNetCore.Mvc.ProblemDetails()
            {
                Detail= $"Eaconomy API error {exception.Message}",
                Instance = "API",
                Status= 500,
                Title="API Error",
                Type="Server Error"
            };
            var response = System.Text.Json.JsonSerializer.Serialize(problemDetails);
            httpContext.Response.ContentType = "application/json";

            await httpContext.Response.WriteAsync(response, cancellationToken);

            return true;
        }
    }
}
