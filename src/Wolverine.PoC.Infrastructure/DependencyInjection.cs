namespace Wolverine.PoC.Infrastructure;

using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Wolverine.Configuration;
using Wolverine.PoC.Infrastructure.MemoryDb;
using Wolverine.PoC.Infrastructure.Swagger;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMemoryDb();
        services.AddPoCSwagger(configuration);

        return services;
    }

    public static void AddInfrastructure(this HandlerDiscovery discovery)
    {
        discovery.IncludeAssembly(Assembly.GetExecutingAssembly());
    }

    public static void UseInfrastructure(this IApplicationBuilder app)
    {
        app.UsePoCSwagger();
    }
}
