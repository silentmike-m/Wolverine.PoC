namespace Wolverine.PoC.Infrastructure.MemoryDb;

using Microsoft.Extensions.DependencyInjection;
using Wolverine.PoC.Domain.Repositories;
using Wolverine.PoC.Infrastructure.MemoryDb.Interfaces;
using Wolverine.PoC.Infrastructure.MemoryDb.Services;

internal static class DependencyInjection
{
    public static IServiceCollection AddMemoryDb(this IServiceCollection services)
    {
        services.AddSingleton(typeof(IContext), new Context());

        services.AddScoped<ICustomerRepository, CustomerRepository>();

        return services;
    }
}
