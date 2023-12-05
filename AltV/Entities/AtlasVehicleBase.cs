using AltV.Atlas.Vehicles.Server.AltV.Interfaces;
using AltV.Net;
using AltV.Net.Async.Elements.Entities;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Atlas.Vehicles.Server.AltV.Entities;

/// <summary>
/// Base Atlas vehicle class, can be inherited from to extend functionality
/// </summary>
/// <param name="core">AltV core</param>
/// <param name="nativePointer">AltV nativePointer</param>
/// <param name="id">Id of the ped</param>
public class AtlasVehicleBase( ICore core, IntPtr nativePointer, uint id ) : AsyncVehicle( core, nativePointer, id ), IAtlasVehicle
{
    /// <summary>
    /// The vehicle id
    /// </summary>
    public uint VehicleId { get; set; }
    /// <summary>
    /// The state if the vehicle is locked
    /// </summary>
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

    /// <summary>
    /// Gets the seat index of the given player
    /// </summary>
    /// <param name="player">Player to get the seat for</param>
    /// <returns>Returns the seat index when found and 0 if not</returns>
    public byte GetSeatIndex( IPlayer player )
    {
        PlayerSeat? playerSeat = Passengers.FirstOrDefault( p => p.Player == player );

        return playerSeat is not null ? player.Seat : ( byte ) 0;
    }
}