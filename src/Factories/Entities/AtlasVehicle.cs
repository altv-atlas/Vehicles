using AltV.Net;
using AltV.Net.Async.Elements.Entities;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
namespace AltV.Atlas.Vehicles.Factories.Entities;

public class AtlasVehicle : AsyncVehicle
{
    public uint Fuel => CalculateFuel( );
    public uint VehicleId { get; private set; }

    public AtlasVehicle( ICore core, IntPtr nativePointer, uint id ) : base( core, nativePointer, id )
    {
    }

    public AtlasVehicle( uint vehicleId, ICore core, IntPtr nativePointer, uint id ) : base( core, nativePointer, id )
    {
        VehicleId = vehicleId;
    }

    public void SpawnVehicle( Position pos, Rotation rot, uint model )
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