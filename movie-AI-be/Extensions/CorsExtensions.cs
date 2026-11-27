namespace movie_AI_BE.Extensions;

public static class CorsExtensions
{
    public static IServiceCollection AddCorsConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var allowedOrigins = configuration.GetSection("Cors:Origins").Get<string[]>() ?? [];

        if (allowedOrigins.Length == 0)
        {
            throw new InvalidOperationException("No CORS origins have been configured.");
        }

        services.AddCors(options =>
        {
            options.AddPolicy("AngularClient", policy =>
            {
                policy
                    .WithOrigins(allowedOrigins)
                    .AllowAnyHeader()
                    .AllowAnyMethod();

                // Add .AllowCredentials() if using
                // cross-origin authentication cookies.
            });
        });

        return services;
    }
}