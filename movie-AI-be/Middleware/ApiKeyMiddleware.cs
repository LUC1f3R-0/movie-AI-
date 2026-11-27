using System.Security.Cryptography;
using System.Text;

namespace movie_AI_BE.Middleware;

public sealed class ApiKeyMiddleware
{
    private const string HeaderName = "X-API-Key";

    private readonly RequestDelegate _next;
    // private readonly IConfiguration _configuration;
    private readonly ILogger<ApiKeyMiddleware> _logger;

    public ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration, ILogger<ApiKeyMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var configuredApiKey = configuration["Keys:xApiKey"];

        // Check server configuration.
        if (string.IsNullOrWhiteSpace(configuredApiKey))
        {
            _logger.LogError("API key is not configured.");

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            await context.Response.WriteAsJsonAsync(new
            {
                success = false,
                message = "Server configuration error."
            });

            return;
        }

        // Get API key from request header.
        var providedApiKey = context.Request.Headers[HeaderName].ToString();

        if (string.IsNullOrWhiteSpace(providedApiKey))
        {
            await UnauthorizedResponse(context);
            return;
        }

        // Compare API keys using a constant-time comparison.
        var expectedBytes = Encoding.UTF8.GetBytes(configuredApiKey);
        var providedBytes = Encoding.UTF8.GetBytes(providedApiKey);

        var isValid = CryptographicOperations.FixedTimeEquals(expectedBytes, providedBytes);

        if (!isValid)
        {
            await UnauthorizedResponse(context);
            return;
        }

        // API key is valid. Continue to the next middleware.
        await _next(context);
    }

    private static async Task UnauthorizedResponse(HttpContext context)
    {
        context.Response.StatusCode = StatusCodes.Status401Unauthorized;

        await context.Response.WriteAsJsonAsync(new
        {
            success = false,
            message = "Invalid or missing API key."
        });
    }
}