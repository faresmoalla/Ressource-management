using Nasxxum.Enlightenment.API.Middlewares;
using Naxxum.Enlightenment.Application.Options;

namespace Nasxxum.Enlightenment.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApiServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.JwtConfigKey));
        services.AddTransient<GlobalExceptionHandlerMiddleware>();
        return services;
    }
}