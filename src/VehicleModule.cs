using AltV.Atlas.Vehicles.Factories.Entities;
using AltV.Atlas.Vehicles.Factories.EntityFactories;
using AltV.Net.Async.Elements.Entities;
using AltV.Net.Elements.Entities;
using Microsoft.Extensions.DependencyInjection;
namespace AltV.Atlas.Vehicles;

public static class VehicleModule
{
    public static IServiceCollection RegisterPedModule( this IServiceCollection serviceCollection )
    {
        serviceCollection.AddTransient<AtlasVehicle>( );
        serviceCollection.AddTransient<AtlasVehicleFactory>( );
        serviceCollection.AddTransient<IVehicle, AsyncVehicle>( );

        //serviceCollection.AddTransient<IEntityFactory<IPed>, AtlasVehicleFactory>( );
        
        return serviceCollection;
    }
}