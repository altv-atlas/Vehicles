using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Atlas.Vehicles.AltV.Interfaces;

public interface IAtlasVehicle : IVehicle
{
    uint VehicleId { get; set; }
    void WarpOutOfVehicle( IPlayer player );
    bool LockVehicle( object item );
    bool LockVehicle( IPlayer player );
}