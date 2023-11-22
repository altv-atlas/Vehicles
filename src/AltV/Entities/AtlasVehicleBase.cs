using AltV.Atlas.Vehicles.AltV.Interfaces;
using AltV.Net;
using AltV.Net.Async.Elements.Entities;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Atlas.Vehicles.AltV.Entities;

public class AtlasVehicleBase : AsyncVehicle, IAtlasVehicle
{
    public uint Fuel => CalculateFuel( );
    public uint VehicleId { get; set; }

    public AtlasVehicleBase( ICore core, IntPtr nativePointer, uint id ) : base( core, nativePointer, id )
    {
    }

    public void WarpOutOfVehicle( IPlayer player )
    {
        var isInVehicle = Passengers.Any( s => s.Player == player );

        if( !isInVehicle )
            return;

        player.Position = Position;
    }

    public bool LockVehicle( object item )
    {
        return false;
    }
    public bool LockVehicle( IPlayer player )
    {
        return false;
    }

    private uint CalculateFuel( )
    {
        return 1;
    }
}