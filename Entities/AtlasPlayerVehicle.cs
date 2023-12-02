using AltV.Net;

namespace AltV.Atlas.Vehicles.Server.Entities;

/// <summary>
/// Atlas player vehicle class
/// </summary>
/// <param name="core">AltV core</param>
/// <param name="nativePointer">AltV nativePointer</param>
/// <param name="id">Id of the ped</param>
public class AtlasPlayerVehicle( ICore core, IntPtr nativePointer, uint id ) : AtlasTuningVehicle( core, nativePointer, id )
{
    /// <summary>
    /// The id of the vehicle owner
    /// </summary>
    public uint OwnerId { get; set; }
}