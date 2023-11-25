using AltV.Atlas.Vehicles.AltV.Entities;
using AltV.Atlas.Vehicles.AltV.Interfaces;
using AltV.Atlas.Vehicles.Entities;
using AltV.Atlas.Vehicles.Interfaces;
using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Data;
using AltV.Net.Enums;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AltV.Atlas.Vehicles.Factories;

/// <summary>
/// Factory to create new atlas vehicle
/// </summary>
public class AtlasVehicleFactory : IAtlasVehicleFactory
{
    private readonly ILogger<AtlasVehicleFactory> _logger;
    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    /// Creates a new instance of this factory
    /// </summary>
    /// <param name="logger">A logger instance</param>
    /// <param name="serviceProvider"></param>
    public AtlasVehicleFactory( ILogger<AtlasVehicleFactory> logger, IServiceProvider serviceProvider )
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
    }

    /// <summary>
    /// Create a new vehicle of type T
    /// </summary>
    /// <param name="model">The model of the vehicle</param>
    /// <param name="position">The position to spawn the vehicle at</param>
    /// <param name="rotation">The rotation to spawn the vehicle at</param>
    /// <typeparam name="T">Type of the ped, by default can be IAtlasVehicle</typeparam>
    /// <returns>A new vehicle of type T</returns>
    public async Task<T> CreateVehicleAsync<T>( uint model, Position position, Rotation rotation ) where T : class, IAtlasVehicle
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<AtlasVehicleBase, T>());
        var mapper = config.CreateMapper();
        
        var altVeh = await AltAsync.CreateVehicle( model, position, rotation );
        _logger.LogInformation( "ALtVeh: {Type}", altVeh.GetType(  ) );
        return mapper.Map<T>( altVeh );
    }

    public Task<T> CreateVehicleAsync<T>( string model, Position position, Rotation rotation ) where T : class, IAtlasVehicle
    {
        return CreateVehicleAsync<T>( Alt.Hash( model ), position, rotation );
    }

    public Task<T> CreateVehicleAsync<T>( VehicleModel model, Position position, Rotation rotation ) where T : class, IAtlasVehicle
    {
        return CreateVehicleAsync<T>( (uint) model, position, rotation );
    }
}