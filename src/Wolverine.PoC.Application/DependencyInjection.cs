namespace Wolverine.PoC.Application;

using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Wolverine.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
        => services;

    public static void AddApplication(this HandlerDiscovery discovery)
    {
        discovery.IncludeAssembly(Assembly.GetExecutingAssembly());
    }
}
