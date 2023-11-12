using AltV.Net;
namespace AltV.Atlas.Vehicles.Factories.Entities;

public class AtlasTuningVehicle : AtlasVehicle
{

    public AtlasTuningVehicle( ICore core, IntPtr nativePointer, uint id ) : base( core, nativePointer, id )
    {
    }
    public AtlasTuningVehicle( uint vehicleId, ICore core, IntPtr nativePointer, uint id ) : base( vehicleId, core, nativePointer, id )
    {
    }
}