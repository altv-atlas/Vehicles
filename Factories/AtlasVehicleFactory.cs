using AltV.Atlas.Vehicles.Server.AltV.Interfaces;
using AltV.Atlas.Vehicles.Server.Interfaces;
using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Data;
using AltV.Net.Enums;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AltV.Atlas.Vehicles.Server.Factories;

/// <summary>
/// Factory to create new atlas vehicle
/// </summary>
public class AtlasVehicleFactory : IAtlasVehicleFactory
{
    private readonly ILogger<AtlasVehicleFactory> _logger;
    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    /// Creates a new instance of this factory
    /// </summary>
    /// <param name="logger">A logger instance</param>
    /// <param name="serviceProvider"></param>
    public AtlasVehicleFactory( ILogger<AtlasVehicleFactory> logger, IServiceProvider serviceProvider )
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
    }

    /// <summary>
    /// Create a new vehicle of type T
    /// </summary>
    /// <param name="model">The model of the vehicle</param>
    /// <param name="position">The position to spawn the vehicle at</param>
    /// <param name="rotation">The rotation to spawn the vehicle at</param>
    /// <typeparam name="T">Type of the ped, by default can be IAtlasVehicle</typeparam>
    /// <returns>A new vehicle of type T</returns>
    public async Task<T> CreateVehicleAsync<T>( uint model, Position position, Rotation rotation ) where T : class, IAtlasVehicle
    {
        var altVeh = await AltAsync.CreateVehicle( model, position, rotation );
        var actualVeh = ActivatorUtilities.CreateInstance<T>( _serviceProvider, altVeh.Core, altVeh.NativePointer, altVeh.Id );
        Alt.Core.PoolManager.Vehicle.Add( actualVeh ); // Thanks zziger <3
        return actualVeh;
    }

    /// <summary>
    /// Create a new vehicle of type T
    /// </summary>
    /// <param name="model">The model of the vehicle</param>
    /// <param name="position">The position to spawn the vehicle at</param>
    /// <param name="rotation">The rotation to spawn the vehicle at</param>
    /// <typeparam name="T">Type of the ped, by default can be IAtlasVehicle</typeparam>
    /// <returns>A new vehicle of type T</returns>
    public Task<T> CreateVehicleAsync<T>( string model, Position position, Rotation rotation ) where T : class, IAtlasVehicle
    {
        return CreateVehicleAsync<T>( Alt.Hash( model ), position, rotation );
    }

    /// <summary>
    /// Create a new vehicle of type T
    /// </summary>
    /// <param name="model">The model of the vehicle</param>
    /// <param name="position">The position to spawn the vehicle at</param>
    /// <param name="rotation">The rotation to spawn the vehicle at</param>
    /// <typeparam name="T">Type of the ped, by default can be IAtlasVehicle</typeparam>
    /// <returns>A new vehicle of type T</returns>
    public Task<T> CreateVehicleAsync<T>( VehicleModel model, Position position, Rotation rotation ) where T : class, IAtlasVehicle
    {
        return CreateVehicleAsync<T>( ( uint ) model, position, rotation );
    }
}