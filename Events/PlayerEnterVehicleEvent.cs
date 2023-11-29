using AltV.Atlas.Vehicles.Server.AltV.Interfaces;
using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Atlas.Vehicles.Server.Events;

/// <summary>
/// Listens to altV PlayerEnterVehicle event
/// </summary>
public sealed class PlayerEnterVehicleEvent
{
    private readonly AtlasVehicleEvents _atlasVehicleEvents;

    /// <summary>
    /// Creates new instance of this class
    /// </summary>
    public PlayerEnterVehicleEvent( AtlasVehicleEvents atlasVehicleEvents )
    {
        _atlasVehicleEvents = atlasVehicleEvents;
        Alt.OnPlayerEnterVehicle += OnOnPlayerEnterVehicle;
    }

    private void OnOnPlayerEnterVehicle( IVehicle vehicle, IPlayer player, byte seat )
    {
        if( vehicle is not IAtlasVehicle atlasVehicle )
            return;

        if( !atlasVehicle.Locked ) 
            return;
        
        player.Position += new Position( 0, 0, .01f );
        _atlasVehicleEvents.PlayerWarpedOutOfLockedVehicle( player, atlasVehicle, seat );
    }
}