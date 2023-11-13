using AltV.Atlas.Vehicles.Factories.Entities;
using AltV.Net;
using AltV.Net.Elements.Entities;
using Microsoft.Extensions.DependencyInjection;
namespace AltV.Atlas.Vehicles.Factories.EntityFactories;

/// <summary>
/// Entity factory for atlas vehicles
/// </summary>
public class AltVehicleFactory : IEntityFactory<IVehicle>
{
    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    /// Creates a new instance of vehicle factory
    /// </summary>
    /// <param name="serviceProvider">service provider that contains the AtlasVehicle class</param>
    public AltVehicleFactory( IServiceProvider serviceProvider )
    {
        _serviceProvider = serviceProvider;
    }

    /// <summary>
    /// Create a new atlas vehicle
    /// </summary>
    /// <param name="core">AltV Core</param>
    /// <param name="entityPointer">Entity ptr</param>
    /// <param name="id">ID of the vehicle</param>
    /// <returns>A new atlas vehicle</returns>
    public IVehicle Create( ICore core, IntPtr entityPointer, uint id )
    {
        return ActivatorUtilities.CreateInstance<AtlasVehicle>( _serviceProvider, core, entityPointer, id );
    }
}