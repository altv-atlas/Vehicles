using AltV.Net;

namespace AltV.Atlas.Vehicles.Server.Entities;

public class AtlasPlayerVehicle( ICore core, IntPtr nativePointer, uint id ) : AtlasTuningVehicle( core, nativePointer, id )
{
    /// <summary>
    /// The id of the vehicle owner
    /// </summary>
    public uint OwnerId { get; set; }
}