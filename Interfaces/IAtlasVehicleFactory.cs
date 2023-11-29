using AltV.Atlas.Vehicles.Server.AltV.Interfaces;
using AltV.Net.Data;
using AltV.Net.Enums;

namespace AltV.Atlas.Vehicles.Server.Interfaces;

public interface IAtlasVehicleFactory
{
    Task<T> CreateVehicleAsync<T>( uint model, Position position, Rotation rotation ) where T : class, IAtlasVehicle;

    Task<T> CreateVehicleAsync<T>( string model, Position position, Rotation rotation ) where T : class, IAtlasVehicle;
    Task<T> CreateVehicleAsync<T>( VehicleModel model, Position position, Rotation rotation ) where T : class, IAtlasVehicle;
}