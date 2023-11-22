using AltV.Atlas.Vehicles.AltV.Entities;
using AltV.Net;

namespace AltV.Atlas.Vehicles.Entities;

public class AtlasTuningVehicle : AtlasVehicleBase
{
    public AtlasTuningVehicle( ICore core, IntPtr nativePointer, uint id ) : base( core, nativePointer, id )
    {
    }

    // public List<VehicleMod> InstalledMods { get; } = new( );
    // public EColorMaterial PrimaryColorMaterial { get; private set; } = EColorMaterial.DefaultAlloy;
    // public EColorMaterial SecondaryColorMaterial { get; private set; } = EColorMaterial.DefaultAlloy;

    // public void SetPrimaryMaterial( EColorMaterial material )
    // {
    //     var oldColor = PrimaryColorRgb;
    //     PrimaryColor = ( byte ) material;
    //     PrimaryColorRgb = oldColor;
    // }
    //
    // public void SetSecondaryMaterial( EColorMaterial material )
    // {
    //     var oldColor = PrimaryColorRgb;
    //     PrimaryColor = ( byte ) material;
    //     PrimaryColorRgb = oldColor;
    // }
    //
    // public void SetPrimaryRgb( string rgb )
    // {
    //     if( !rgb.TryParseRgb( out var color ) )
    //         return;
    //
    //     PrimaryColorRgb = new Rgba( color.R, color.G, color.B, color.A );
    // }
    //
    // public void SetSecondaryRgb( string rgb )
    // {
    //     if( !rgb.TryParseRgb( out var color ) )
    //         return;
    //
    //     SecondaryColorRgb = new Rgba( color.R, color.G, color.B, color.A );
    // }
    //
    // public bool InstallMod( VehicleMod vehicleMod, bool force = false )
    // {
    //     var maxIndex = GetModsCount( ( byte ) vehicleMod.ModType );
    //
    //     if( vehicleMod.Index > maxIndex && !force )
    //     {
    //         return false;
    //     }
    //
    //     var result = SetMod( ( byte ) vehicleMod.ModType, ( byte ) vehicleMod.Index );
    //     InstalledMods.Add( vehicleMod );
    //     return result;
    // }
    //
    // public IEnumerable<( VehicleMod mod, bool result )> InstallMods( IEnumerable<VehicleMod> vehicleMods )
    // {
    //     return ( from vehicleMod in vehicleMods let result = InstallMod( vehicleMod ) select ( vehicleMod, result ) ).ToList( );
    // }
    //
    // public bool RemoveMod( VehicleModType vehicleModType )
    // {
    //     var result = SetMod( ( byte ) vehicleModType, 0 );
    //     InstalledMods.RemoveAll( x => x.ModType == vehicleModType );
    //     return result;
    // }
}