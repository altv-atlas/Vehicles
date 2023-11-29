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

    public void PlayerWarpedOutOfLockedVehicle( IPlayer player, IAtlasVehicle vehicle, byte seat )
    {
        OnPlayerWarpedOutOfLockedVehicle?.Invoke( player, vehicle, seat );
    }

    #endregion
}