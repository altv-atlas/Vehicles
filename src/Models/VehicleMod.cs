using AltV.Net.Enums;
namespace AltV.Atlas.Vehicles.Models;

public class VehicleMod
{
    /// <summary>
    /// Constructor to create a VehicleMod
    /// </summary>
    /// <param name="vehicleModType">The type of the mod</param>
    /// <param name="index">The index of the mod</param>
    public VehicleMod( VehicleModType vehicleModType, uint index )
    {
        ModType = vehicleModType;
        Index = index;
    }
    /// <summary>
    /// Type of the vehicle mod
    /// </summary>
    public VehicleModType ModType { get; set; }

    /// <summary>
    /// Index of the vehicle mod
    /// </summary>
    public uint Index { get; set; }
}