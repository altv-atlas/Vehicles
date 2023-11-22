using AltV.Atlas.Vehicles.AltV.Entities;
using AltV.Atlas.Vehicles.AltV.Interfaces;
using AltV.Net;
using Microsoft.Extensions.DependencyInjection;

namespace AltV.Atlas.Vehicles.AltV.Factories;

/// <summary>
/// Entity factory for atlas vehicles
/// </summary>
public class AltVehicleFactory : IEntityFactory<IAtlasVehicle>
{
    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    /// Creates a new instance of vehicle factory
    /// </summary>
    /// <param name="serviceProvider">service provider that contains the AtlasVehicleBase class</param>
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
    public IAtlasVehicle Create( ICore core, IntPtr entityPointer, uint id )
    {
        return ActivatorUtilities.CreateInstance<AtlasVehicleBase>( _serviceProvider, core, entityPointer, id );
    }
}