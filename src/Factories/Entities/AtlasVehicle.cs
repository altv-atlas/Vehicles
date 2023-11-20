using AltV.Atlas.Vehicles.Interfaces;
using AltV.Net;
using AltV.Net.Async.Elements.Entities;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
namespace AltV.Atlas.Vehicles.Factories.Entities;

public class AtlasVehicle : AsyncVehicle, IAtlasVehicle
{
    public uint Fuel => CalculateFuel( );
    public uint VehicleId { get; set; }

    public AtlasVehicle( ICore core, IntPtr nativePointer, uint id ) : base( core, nativePointer, id )
    {
    }

    public void SpawnVehicle( uint model, Position pos, Rotation rot )
    {
        throw new NotImplementedException( );
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