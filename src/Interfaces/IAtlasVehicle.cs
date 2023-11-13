using AltV.Net.Data;
using AltV.Net.Elements.Entities;
namespace AltV.Atlas.Vehicles.Interfaces;

public interface IAtlasVehicle : IVehicle
{
    uint Fuel { get; }
    uint VehicleId { get; }

    void SpawnVehicle( uint model, Position pos, Rotation rot );
    void WarpOutOfVehicle( IPlayer player );
    bool LockVehicle( object item );
    bool LockVehicle( IPlayer player );
}