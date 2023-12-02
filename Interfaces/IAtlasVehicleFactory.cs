using AltV.Atlas.Vehicles.Server.AltV.Interfaces;
using AltV.Net.Data;
using AltV.Net.Enums;

namespace AltV.Atlas.Vehicles.Server.Interfaces;

/// <summary>
/// Interface that exposes vehicle creation methods
/// </summary>
public interface IAtlasVehicleFactory
{
    /// <summary>
    /// Create a new vehicle of type T
    /// </summary>
    /// <param name="model">The model of the vehicle</param>
    /// <param name="position">The position to spawn the vehicle at</param>
    /// <param name="rotation">The rotation to spawn the vehicle at</param>
    /// <typeparam name="T">Type of the ped, by default can be IAtlasVehicle</typeparam>
    /// <returns>A new vehicle of type T</returns>
    Task<T> CreateVehicleAsync<T>( uint model, Position position, Rotation rotation ) where T : class, IAtlasVehicle;

    /// <summary>
    /// Create a new vehicle of type T
    /// </summary>
    /// <param name="model">The model of the vehicle</param>
    /// <param name="position">The position to spawn the vehicle at</param>
    /// <param name="rotation">The rotation to spawn the vehicle at</param>
    /// <typeparam name="T">Type of the ped, by default can be IAtlasVehicle</typeparam>
    /// <returns>A new vehicle of type T</returns>
    Task<T> CreateVehicleAsync<T>( string model, Position position, Rotation rotation ) where T : class, IAtlasVehicle;
    
    /// <summary>
    /// Create a new vehicle of type T
    /// </summary>
    /// <param name="model">The model of the vehicle</param>
    /// <param name="position">The position to spawn the vehicle at</param>
    /// <param name="rotation">The rotation to spawn the vehicle at</param>
    /// <typeparam name="T">Type of the ped, by default can be IAtlasVehicle</typeparam>
    /// <returns>A new vehicle of type T</returns>
    Task<T> CreateVehicleAsync<T>( VehicleModel model, Position position, Rotation rotation ) where T : class, IAtlasVehicle;
}