using System.Text.Json;
using AltV.Atlas.Shared.Extensions;
using AltV.Atlas.Vehicles.Server.AltV.Entities;
using AltV.Atlas.Vehicles.Server.Data;
using AltV.Atlas.Vehicles.Server.Enums;
using AltV.Atlas.Vehicles.Server.Models;
using AltV.Atlas.Vehicles.Shared;
using AltV.Atlas.Vehicles.Shared.Models;
using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Enums;
using VehicleConstants = AltV.Atlas.Vehicles.Shared.VehicleConstants;

namespace AltV.Atlas.Vehicles.Server.Entities;

/// <summary>
/// Server-side atlasTuningVehicle
/// </summary>
public class AtlasTuningVehicle : AtlasVehicleBase
{
    private List<WheelMod> _wheelMods = new List<WheelMod>( );

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
        if( !GtaColor.ColorHexMap.TryGetValue( color, out var rgb ) )
            return;

        SetPrimaryRgb( rgb );
    }

    /// <summary>
    /// Sets the gtaColor as rgb color
    /// </summary>
    /// <param name="color">The gtaColor to apply</param>
    public void SetSecondaryColor( EGtaColor color )
    {
        if( !GtaColor.ColorHexMap.TryGetValue( color, out var rgb ) )
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

    /// <summary>
    /// Changes the wheelMod values of the specific wheelMod
    /// </summary>
    /// <param name="wheelMod"></param>
    public void ChangeWheel( WheelMod wheelMod )
    {
        var index = _wheelMods.FindIndex( mod => mod.Index == wheelMod.Index );

        if( index is -1 )
        {
            _wheelMods.Add( wheelMod );
        }
        else
        {
            _wheelMods[ index ] = wheelMod;
        }

        ChangeWheels( _wheelMods );
    }

    /// <summary>
    /// Changes the vehicles wheel mods for each wheel
    /// </summary>
    /// <param name="wheelMod">The data to apply</param>
    public void ChangeWheels( WheelMod wheelMod )
    {
        var wheels = new List<WheelMod>( );

        for( byte i = 0; i < WheelsCount; i++ )
        {
            wheels.Add( wheelMod with
            {
                Index = i
            } );
        }
        ChangeWheels( wheels );
    }

    /// <summary>
    /// Changes the vehicle wheel mods
    /// </summary>
    /// <param name="wheelMods">The mod values to apply</param>
    public void ChangeWheels( List<WheelMod> wheelMods )
    {
        _wheelMods = wheelMods;
        var values = JsonSerializer.Serialize( _wheelMods );
        SetStreamSyncedMetaData( VehicleConstants.ChangeWheelsMetaKey, values );
    }


    /// <summary>
    /// Sets the camber value of the specific wheel
    /// </summary>
    /// <param name="index">Index of the wheel</param>
    /// <param name="camber">Value of the camber to apply</param>
    public void SetWheelCamber( byte index, float camber )
    {
        SetWheelProperty( index, mod => mod.Camber = camber );
    }
    /// <summary>
    /// Sets the height value of the specific wheel
    /// </summary>
    /// <param name="index">Index of the wheel</param>
    /// <param name="height">Value of the height to apply</param>
    public void SetWheelHeight( byte index, float height )
    {
        SetWheelProperty( index, mod => mod.Height = height );
    }

    /// <summary>
    /// Sets the rimRadius value of the specific wheel
    /// </summary>
    /// <param name="index">Index of the wheel</param>
    /// <param name="rimRadius">Value of the rimRadius to apply</param>
    public void SetWheelRimRadius( byte index, float rimRadius )
    {
        SetWheelProperty( index, mod => mod.RimRadius = rimRadius );
    }

    /// <summary>
    /// Sets the trackWidth value of the specific wheel
    /// </summary>
    /// <param name="index">Index of the wheel</param>
    /// <param name="trackWidth">Value of the trackWidth to apply</param>
    public void SetWheelTrackWidth( byte index, float trackWidth )
    {
        SetWheelProperty( index, mod => mod.TrackWidth = trackWidth );
    }

    /// <summary>
    /// Sets the tyreWidth value of the specific wheel
    /// </summary>
    /// <param name="index">Index of the wheel</param>
    /// <param name="tyreRadius">Value of the tyreWidth to apply</param>
    public void SetWheelTyreRadius( byte index, float tyreRadius )
    {
        SetWheelProperty( index, mod => mod.TyreRadius = tyreRadius );
    }
    
    /// <summary>
    /// Sets the tyreWidth value of the specific wheel
    /// </summary>
    /// <param name="index">Index of the wheel</param>
    /// <param name="tyreWidth">Value of the tyreWidth to apply</param>
    public void SetWheelTyreWidth( byte index, float tyreWidth )
    {
        SetWheelProperty( index, mod => mod.TyreWidth = tyreWidth );
    }

    private void SetWheelProperty( byte index, Action<WheelMod> setProperty )
    {
        var wheelMod = _wheelMods.FirstOrDefault( mod => mod.Index == index );

        if( wheelMod is null )
        {
            _wheelMods.Add( new WheelMod
            {
                Index = index
            } );

            wheelMod = _wheelMods.Last( );
        }

        setProperty( wheelMod );

        ChangeWheels( _wheelMods );
    }
}