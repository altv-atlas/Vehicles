using AltV.Atlas.Vehicles.Server.AltV.Interfaces;
using AltV.Net.Elements.Entities;

namespace AltV.Atlas.Vehicles.Server.Events;

/// <summary>
/// Class that receives and emits events that occur within vehicles module
/// </summary>
public class AtlasVehicleEvents
{
    #region PlayerWarpedOutOfVehicle

    /// <summary>
    /// Delegate
    /// </summary>
    public delegate void PlayerWarpedOutOfLockedVehicleDelegate( IPlayer player, IAtlasVehicle vehicle, byte seat );

    /// <summary>
    /// Triggered when a player got warped out of a locked vehicle
    /// </summary>
    public event PlayerWarpedOutOfLockedVehicleDelegate? OnPlayerWarpedOutOfLockedVehicle;

    /// <summary>
    /// Event that triggers when a player got warped out of a locked vehicle
    /// </summary>
    /// <param name="player">Player that was warped out</param>
    /// <param name="vehicle">The vehicle the player got warped out of</param>
    /// <param name="seat">The seat he was warped out of</param>
    public void PlayerWarpedOutOfLockedVehicle( IPlayer player, IAtlasVehicle vehicle, byte seat )
    {
        OnPlayerWarpedOutOfLockedVehicle?.Invoke( player, vehicle, seat );
    }

    #endregion
}