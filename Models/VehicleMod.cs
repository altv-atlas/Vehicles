using AltV.Net.Enums;

namespace AltV.Atlas.Vehicles.Server.Models;

public class VehicleMod
{
    /// <summary>
    /// Type of the vehicle mod
    /// </summary>
    public VehicleModType ModType { get; init; }

    /// <summary>
    /// Index of the vehicle mod
    /// </summary>
    public uint Index { get; init; }

}