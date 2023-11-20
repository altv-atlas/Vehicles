using AltV.Atlas.Vehicles.Factories.Entities;
using AltV.Atlas.Vehicles.Factories.EntityFactories;
using AltV.Atlas.Vehicles.Interfaces;
using AltV.Net;
using AltV.Net.Async.Elements.Entities;
using AltV.Net.Elements.Entities;
using Microsoft.Extensions.DependencyInjection;
namespace AltV.Atlas.Vehicles;

/// <summary>
///     Entrypoint for atlas vehicle module
/// </summary>
public static class VehicleModule
{
    /// <summary>
    ///     Registers the vehicle module and it's classes/interfaces
    /// </summary>
    /// <param name="serviceCollection">A service collection</param>
    /// <returns>The service collection</returns>
    public static IServiceCollection RegisterVehicleModule( this IServiceCollection serviceCollection )
    {
        serviceCollection.AddTransient<IAtlasVehicle, AtlasVehicle>( );
        serviceCollection.AddTransient<AtlasVehicleFactory>( );
        serviceCollection.AddTransient<IVehicle, AsyncVehicle>( );

        serviceCollection.AddTransient<IEntityFactory<IVehicle>, AltVehicleFactory>( );

        return serviceCollection;
    }
    
    /// <summary>
    ///     Registers the vehicle module and it's classes/interfaces with a specific AtlasVehicleFactory Type T
    /// </summary>
    /// <param name="serviceCollection">A service collection</param>
    /// <returns>The service collection</returns>
    public static IServiceCollection RegisterVehicleModule<T>( this IServiceCollection serviceCollection ) where T : AtlasVehicleFactory
    {
        serviceCollection.AddTransient<IAtlasVehicle, AtlasVehicle>( );
        serviceCollection.AddTransient<T>( );
        serviceCollection.AddTransient<IVehicle, AsyncVehicle>( );

        serviceCollection.AddTransient<IEntityFactory<IVehicle>, AltVehicleFactory>( );

        return serviceCollection;
    }
}