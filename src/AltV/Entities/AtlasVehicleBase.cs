using AltV.Atlas.Vehicles.AltV.Interfaces;
using AltV.Net;
using AltV.Net.Async.Elements.Entities;
using AltV.Net.Elements.Entities;

namespace AltV.Atlas.Vehicles.AltV.Entities;

public class AtlasVehicleBase( ICore core, IntPtr nativePointer, uint id ) : AsyncVehicle( core, nativePointer, id ), IAtlasVehicle
{
    public uint VehicleId { get; set; }
    public bool Locked { get; set; }

    /// <summary>
    /// Forces the player out of the vehicle
    /// </summary>
    /// <param name="player">The player to force out</param>
    public void WarpOutOfVehicle( IPlayer player )
    {
        var isInVehicle = Passengers.Any( s => s.Player == player );

        if( !isInVehicle )
            return;

        player.Position = Position;
    }
}