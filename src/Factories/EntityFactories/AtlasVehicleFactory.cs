using AltV.Atlas.Vehicles.Interfaces;
using AltV.Net.Async;
using AltV.Net.Data;
using AltV.Net.Enums;
using Microsoft.Extensions.Logging;
namespace AltV.Atlas.Vehicles.Factories.EntityFactories;

/// <summary>
/// Factory to create new atlas vehicle
/// </summary>
public class AtlasVehicleFactory
{
    private readonly ILogger<AtlasVehicleFactory> _logger;

    /// <summary>
    /// Creates a new instance of this factory
    /// </summary>
    /// <param name="logger">A logger instance</param>
    public AtlasVehicleFactory( ILogger<AtlasVehicleFactory> logger )
    {
        _logger = logger;
    }

    /// <summary>
    /// Create a new vehicle of type T
    /// </summary>
    /// <param name="vehicleId"></param>
    /// <param name="model">The model of the vehicle</param>
    /// <param name="position">The position to spawn the vehicle at</param>
    /// <param name="rotation">The rotation to spawn the vehicle at</param>
    /// <typeparam name="T">Type of the ped, by default can be IAtlasVehicle</typeparam>
    /// <returns>A new vehicle of type T</returns>
    public async Task<T> CreateVehicleAsync<T>( uint vehicleId, uint model, Position position, Rotation rotation ) where T : IAtlasVehicle
    {
        var veh = await AltAsync.CreateVehicle( model, position, rotation );

        var vehicle = ( T ) veh;
        vehicle.VehicleId = vehicleId;

        return vehicle;
    }

    public async Task<T> CreateVehicleAsync<T>( uint vehicleId, string model, Position position, Rotation rotation ) where T : IAtlasVehicle
    {
        var vehicle = ( T ) await AltAsync.CreateVehicle( model, position, rotation );
        vehicle.VehicleId = vehicleId;

        return vehicle;
    }

    public async Task<T> CreateVehicleAsync<T>( uint vehicleId, VehicleModel model, Position position, Rotation rotation ) where T : IAtlasVehicle
    {
        var vehicle = ( T ) await AltAsync.CreateVehicle( model, position, rotation );
        vehicle.VehicleId = vehicleId;

        return vehicle;
    }

    /// <summary>
    /// Create a new vehicle of type IAtlasVehicle
    /// </summary>
    /// <param name="model">The model of the ped</param>
    /// <param name="position">The position to spawn the ped at</param>
    /// <param name="rotation">The rotation to spawn the ped at</param>
    /// <returns>A new instance of IAtlasPed</returns>
    public async Task<IAtlasVehicle> CreateVehicleAsync( uint model, Position position, Rotation rotation )
    {
        return ( IAtlasVehicle ) await AltAsync.CreateVehicle( model, position, rotation );
    }

    public async Task<IAtlasVehicle> CreateVehicleAsync( string model, Position position, Rotation rotation )
    {
        return ( IAtlasVehicle ) await AltAsync.CreateVehicle( model, position, rotation );
    }

    public async Task<IAtlasVehicle> CreateVehicleAsync( VehicleModel model, Position position, Rotation rotation )
    {
        return ( IAtlasVehicle ) await AltAsync.CreateVehicle( model, position, rotation );
    }
}