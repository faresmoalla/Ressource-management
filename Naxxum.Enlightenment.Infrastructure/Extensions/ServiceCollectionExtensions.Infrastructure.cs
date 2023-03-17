using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Naxxum.Enlightenment.Infrastructure.Repositories;
using Naxxum.Enlightenment.Application.Abstractions;

namespace Naxxum.Enlightenment.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddTransient<IUsersRepository, UsersRepository>();
        return services;
    }
}