using AltV.Net.Elements.Entities;

namespace AltV.Atlas.Vehicles.Server.AltV.Interfaces;

/// <summary>
/// The IAtlasVehicle vehicle interface
/// </summary>
public interface IAtlasVehicle : IVehicle
{
    /// <summary>
    /// The vehicle id
    /// </summary>
    uint VehicleId { get; set; }
    /// <summary>
    /// The state if the vehicle is locked
    /// </summary>
    bool Locked { get; set; }
    /// <summary>
    /// Warps out the given player out of the vehicle
    /// </summary>
    /// <param name="player">The player to warp out</param>
    void WarpOutOfVehicle( IPlayer player );
}