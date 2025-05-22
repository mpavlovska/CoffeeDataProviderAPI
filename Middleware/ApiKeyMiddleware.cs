namespace CoffeeDataProviderAPI.Middleware;

public class ApiKeyMiddleware
{
    private readonly RequestDelegate _next;
    private const string HEADER_NAME = "X-API-KEY";

    public ApiKeyMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, IConfiguration configuration)
    {
        if (!context.Request.Headers.TryGetValue(HEADER_NAME, out var extractedApiKey))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("API Key was missing.");
            return;
        }

        var configuredKey = configuration.GetValue<string>("ApiKey");

        if (!string.Equals(extractedApiKey, configuredKey, StringComparison.Ordinal))
        {
            context.Response.StatusCode = 403;
            await context.Response.WriteAsync("Invalid API Key.");
            return;
        }

        await _next(context);
    }
}
