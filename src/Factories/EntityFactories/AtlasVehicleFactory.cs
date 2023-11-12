using AltV.Atlas.Vehicles.Factories.Entities;
using AltV.Net;
using AltV.Net.Elements.Entities;
namespace AltV.Atlas.Vehicles.Factories.EntityFactories;

public class AtlasVehicleFactory : IEntityFactory<IVehicle>
{
    public IVehicle Create( ICore core, IntPtr entityPointer, uint id )
    {
        return new AtlasVehicle( core, entityPointer, id );
    }
}