using LiftMaster_3000.Interfaces;
using LiftMaster_3000.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LiftMaster_3000.Common;
/// <summary>
/// This is used if we wanted to switch over to a DI container
/// </summary>
public static class Dependency
{
    /// <summary>
    /// Create Container and inject services, currently unused for this iteration
    /// </summary>
    /// <returns></returns>
    public static ServiceProvider AddDependencyInjectedServices()
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IElevatorService, ElevatorService>()
            .BuildServiceProvider();

        return serviceProvider;
    }
}