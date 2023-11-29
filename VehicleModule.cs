using AltV.Atlas.Vehicles.Server.AltV.Entities;
using AltV.Atlas.Vehicles.Server.AltV.Factories;
using AltV.Atlas.Vehicles.Server.AltV.Interfaces;
using AltV.Atlas.Vehicles.Server.Events;
using AltV.Atlas.Vehicles.Server.Factories;
using AltV.Atlas.Vehicles.Server.Interfaces;
using AltV.Net;
using Microsoft.Extensions.DependencyInjection;

namespace AltV.Atlas.Vehicles.Server;

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
    public static IServiceCollection RegisterVehicleModule<TFactory>( this IServiceCollection serviceCollection ) where TFactory : class, IAtlasVehicleFactory
    {
        serviceCollection.AddTransient<IAtlasVehicle, AtlasVehicleBase>( );
        serviceCollection.AddTransient<IAtlasVehicleFactory, TFactory>( );
        
        // Events
        serviceCollection.AddSingleton<AtlasVehicleEvents>( );
        serviceCollection.AddSingleton<PlayerEnterVehicleEvent>( );

        serviceCollection.AddTransient<IEntityFactory<IAtlasVehicle>, AltVehicleFactory>( );

        return serviceCollection;
    }
    
    /// <summary>
    ///     Registers the vehicle module and it's classes/interfaces
    /// </summary>
    /// <param name="serviceCollection">A service collection</param>
    /// <returns>The service collection</returns>
    public static IServiceCollection RegisterVehicleModule( this IServiceCollection serviceCollection )
    {
        return RegisterVehicleModule<AtlasVehicleFactory>( serviceCollection );
    }

    /// <summary>
    /// Initializes the vehicle module
    /// </summary>
    /// <param name="serviceProvider">a service provider</param>
    /// <returns></returns>
    public static IServiceProvider InitializeVehicleModule( this IServiceProvider serviceProvider )
    {
        _ = serviceProvider.GetService<PlayerEnterVehicleEvent>( );
        return serviceProvider;
    }
}