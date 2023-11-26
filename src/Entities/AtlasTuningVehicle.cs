using AltV.Atlas.Vehicles.AltV.Entities;
using AltV.Atlas.Vehicles.Enums;
using AltV.Atlas.Vehicles.Models;
using AltV.Atlas.Vehicles.Utils;
using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Enums;

namespace AltV.Atlas.Vehicles.Entities;

public class AtlasTuningVehicle : AtlasVehicleBase
{
    /// <summary>
    /// Creates an AtlasTuningVehicle
    /// </summary>
    /// <param name="core">AltV core</param>
    /// <param name="nativePointer">AltV nativePointer</param>
    /// <param name="id">Id of the ped</param>
    public AtlasTuningVehicle( ICore core, IntPtr nativePointer, uint id ) : base( core, nativePointer, id )
    {
        ModKit = 1;
        NumberplateText = "ATLAS";
        SetPrimaryRgb( "#1a222e" );
        SetSecondaryRgb( "#15dbfc" );
        SetPearlColor( EGtaColor.MatteBlack );
    }
    /// <summary>
    /// All installed vehicle mods
    /// </summary>
    public List<VehicleMod> InstalledMods { get; } = new( );
    /// <summary>
    /// The primary color material
    /// </summary>
    public EColorMaterial PrimaryColorMaterial { get; private set; } = EColorMaterial.DefaultAlloy;
    /// <summary>
    /// The secondary color material
    /// </summary>
    public EColorMaterial SecondaryColorMaterial { get; private set; } = EColorMaterial.DefaultAlloy;

    /// <summary>
    /// Sets the PrimaryMaterial of the vehicle
    /// A list of all available Materials can be found in the EColorMaterial Enum
    /// </summary>
    /// <param name="material">The material to apply</param>
    public void SetPrimaryMaterial( EColorMaterial material )
    {
        var oldColor = PrimaryColorRgb;
        PrimaryColor = ( byte ) material;
        PrimaryColorRgb = oldColor;
    }

    /// <summary>
    /// Sets the SecondaryMaterial of the vehicle
    /// A list of all available Materials can be found in the EColorMaterial Enum
    /// </summary>
    /// <param name="material">The material to apply</param>
    public void SetSecondaryMaterial( EColorMaterial material )
    {
        var oldColor = PrimaryColorRgb;
        PrimaryColor = ( byte ) material;
        PrimaryColorRgb = oldColor;
    }

    /// <summary>
    /// Sets the vehicle PrimaryColorRgb from a string
    /// </summary>
    /// <param name="rgb">The rgb color as a string</param>
    public void SetPrimaryRgb( string rgb )
    {
        if( !rgb.TryParseRgb( out var color ) )
            return;

        PrimaryColorRgb = new Rgba( color.R, color.G, color.B, color.A );
    }

    /// <summary>
    /// Sets the vehicle SecondaryColorRgb from a string
    /// </summary>
    /// <param name="rgb">The rgb color as a string</param>
    public void SetSecondaryRgb( string rgb )
    {
        if( !rgb.TryParseRgb( out var color ) )
            return;

        SecondaryColorRgb = new Rgba( color.R, color.G, color.B, color.A );
    }

    /// <summary>
    /// Sets the vehicle PearlColor from a EGtaColor
    /// </summary>
    /// <param name="color">The EGtaColor to apply</param>
    public void SetPearlColor( EGtaColor color ) => PearlColor = ( byte ) color;

    /// <summary>
    ///  Sets the gtaColor as rgb color
    /// </summary>
    /// <param name="color">The gtaColor to apply</param>
    public void SetPrimaryColor( EGtaColor color )
    {
        if( !Utility.ColorHexMap.TryGetValue( color, out var rgb ) )
            return;

        SetPrimaryRgb( rgb );
    }

    /// <summary>
    /// Sets the gtaColor as rgb color
    /// </summary>
    /// <param name="color">The gtaColor to apply</param>
    public void SetSecondaryColor( EGtaColor color )
    {
        if( !Utility.ColorHexMap.TryGetValue( color, out var rgb ) )
            return;

        SetSecondaryRgb( rgb );
    }

    /// <summary>
    /// Installs a given VehicleMod
    /// </summary>
    /// <param name="vehicleMod">The mod to install</param>
    /// <param name="force">Force the mod index even if it should not exist</param>
    /// <returns>Returns if the SetMod was successful</returns>
    public bool InstallMod( VehicleMod vehicleMod, bool force = false )
    {
        var maxIndex = GetModsCount( ( byte ) vehicleMod.ModType );

        if( vehicleMod.Index > maxIndex && !force )
        {
            return false;
        }

        var result = SetMod( ( byte ) vehicleMod.ModType, ( byte ) vehicleMod.Index );

        if( result )
            InstalledMods.Add( vehicleMod );

        return result;
    }

    /// <summary>
    /// Installs a list of mods
    /// </summary>
    /// <param name="vehicleMods">The list of mods to install</param>
    /// <returns>Returns a list of tuples with the given mod and the SetMod result</returns>
    public IEnumerable<( VehicleMod mod, bool result )> InstallMods( IEnumerable<VehicleMod> vehicleMods )
    {
        return ( from vehicleMod in vehicleMods let result = InstallMod( vehicleMod ) select ( vehicleMod, result ) ).ToList( );
    }

    /// <summary>
    /// Removes the given VehicleModType
    /// </summary>
    /// <param name="vehicleModType">The type to remove</param>
    /// <returns>Returns the SetMod result or false if the mod wasn't installed</returns>
    public bool RemoveMod( VehicleModType vehicleModType )
    {
        if( InstalledMods.All( mod => mod.ModType != vehicleModType ) )
            return false;

        var result = SetMod( ( byte ) vehicleModType, 0 );
        InstalledMods.RemoveAll( x => x.ModType == vehicleModType );
        return result;
    }

    /// <summary>
    /// Removes all installed vehicleMods
    /// </summary>
    /// <returns>Returns a list of tuples with the given mod and the SetMod result</returns>
    public IEnumerable<( VehicleMod mod, bool result )> RemoveMods( )
    {
        return ( from vehicleMod in InstalledMods.ToList( ) let result = RemoveMod( vehicleMod.ModType ) select ( vehicleMod, result ) ).ToList( );
    }

    /// <summary>
    /// Removes all given vehicleMods
    /// </summary>
    /// <param name="vehicleMods">The list of mods to be removed</param>
    /// <returns>Returns a list of tuples with the given mod and the SetMod result</returns>
    public IEnumerable<( VehicleMod mod, bool result )> RemoveMods( IEnumerable<VehicleMod> vehicleMods )
    {
        return ( from vehicleMod in vehicleMods.ToList( ) let result = RemoveMod( vehicleMod.ModType ) select ( vehicleMod, result ) ).ToList( );
    }

    /// <summary>
    /// Set the vehicle NeonColor
    /// </summary>
    /// <param name="rgb">The rgb color as a string</param>
    public void SetNeonColorRgb( string rgb )
    {
        if( !rgb.TryParseRgb( out var color ) )
            return;

        NeonColor = color;
    }

    /// <summary>
    /// Sets a specific neon style
    /// </summary>
    /// <param name="neonStyle">The neonStyle to apply</param>
    public void SetNeonStyle( ENeonStyle neonStyle )
    {
        Vehicle.SetNeonActive(
            ( neonStyle & ENeonStyle.Left ) != 0,
            ( neonStyle & ENeonStyle.Right ) != 0,
            ( neonStyle & ENeonStyle.Top ) != 0,
            ( neonStyle & ENeonStyle.Back ) != 0
        );
    }

    /// <summary>
    /// Sets a rgb tireSmoke color
    /// </summary>
    /// <param name="rgb">The rgb color as a string</param>
    public void SetTireSmokeRgb( string rgb )
    {
        if( !rgb.TryParseRgb( out var color ) )
            return;

        TireSmokeColor = color;
    }

    /// <summary>
    /// Sets the vehicle headlightColor
    /// </summary>
    /// <param name="headlightColor">The headlightColor to apply</param>
    public void SetHeadlightColor( EHeadlightColor headlightColor )
    {
        HeadlightColor = ( byte ) headlightColor;
    }

    /// <summary>
    /// Sets the vehicle wheelColor
    /// </summary>
    /// <param name="color">The color to apply</param>
    public void SetWheelColor( EGtaColor color ) => WheelColor = ( byte ) color;

    /// <summary>
    /// Sets the vehicle wheel type and variation
    /// </summary>
    /// <param name="wheelType">The wheelType to apply</param>
    /// <param name="variation">The wheelVariation to apply</param>
    public void SetWheels( EWheelType wheelType, byte variation )
    {
        SetWheels( ( byte ) wheelType, variation );
    }

}