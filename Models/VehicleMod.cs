using AltV.Net.Enums;

namespace AltV.Atlas.Vehicles.Server.Models;

/// <summary>
/// Class that holds values for a specific vehicleMod
/// </summary>
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