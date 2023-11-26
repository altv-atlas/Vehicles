using System.Collections.Frozen;
using System.Drawing;
using AltV.Atlas.Vehicles.Enums;
namespace AltV.Atlas.Vehicles.Utils;

public static class Utility
{
    /// <summary>
    /// Tries to parse a string to a rgb color
    /// </summary>
    /// <param name="rgb">The rgb value</param>
    /// <param name="color">The color value</param>
    /// <returns>Returns if the parsing was successful</returns>
    public static bool TryParseRgb( this string rgb, out Color color )
    {
        color = Color.Empty;

        try
        {
            color = ColorTranslator.FromHtml( rgb );
            return true;
        }
        catch( Exception ex )
        {
            Console.WriteLine( $"Error parsing color string: {ex.Message}" );
            return false;
        }
    }

    /// <summary>
    /// A map of all hex values for the representing GTA color
    /// </summary>
    public static readonly FrozenDictionary<EGtaColor, string> ColorHexMap = new Dictionary<EGtaColor, string>
    {
        //TODO: The hex colors doesnt match yet needs to be done at some point
        { EGtaColor.MetallicBlack, "#0d1116" },
        { EGtaColor.MetallicGraphiteBlack, "#1c1e21" },
        { EGtaColor.MetallicBlackSteal, "#111213" },
        { EGtaColor.MetallicDarkSilver, "#3c3e42" },
        { EGtaColor.MetallicSilver, "#c0c0c0" },
        { EGtaColor.MetallicBlueSilver, "#606984" },
        { EGtaColor.MetallicSteelGray, "#808080" },
        { EGtaColor.MetallicShadowSilver, "#5d6065" },
        { EGtaColor.MetallicStoneSilver, "#8a8d92" },
        { EGtaColor.MetallicMidnightSilver, "#4b4e53" },
        { EGtaColor.MetallicGunMetal, "#2b2e32" },
        { EGtaColor.MetallicAnthraciteGrey, "#1f2226" },
        { EGtaColor.MatteBlack, "#050505" },
        { EGtaColor.MatteGray, "#6b6b6b" },
        { EGtaColor.MatteLightGrey, "#9e9e9e" },
        { EGtaColor.UtilBlack, "#0c0c0c" },
        { EGtaColor.UtilBlackPoly, "#060606" },
        { EGtaColor.UtilDarkSilver, "#353738" },
        { EGtaColor.UtilSilver, "#c0c0c0" },
        { EGtaColor.UtilGunMetal, "#2b2e32" },
        { EGtaColor.UtilShadowSilver, "#5d6065" },
        { EGtaColor.WornBlack, "#050505" },
        { EGtaColor.WornGraphite, "#1c1e21" },
        { EGtaColor.WornSilverGrey, "#6b6b6b" },
        { EGtaColor.WornSilver, "#c0c0c0" },
        { EGtaColor.WornBlueSilver, "#606984" },
        { EGtaColor.WornShadowSilver, "#5d6065" },
        { EGtaColor.MetallicRed, "#850000" },
        { EGtaColor.MetallicTorinoRed, "#c54d4d" },
        { EGtaColor.MetallicFormulaRed, "#b20909" },
        { EGtaColor.MetallicBlazeRed, "#db1010" },
        { EGtaColor.MetallicGracefulRed, "#a41313" },
        { EGtaColor.MetallicGarnetRed, "#8c1010" },
        { EGtaColor.MetallicDesertRed, "#864747" },
        { EGtaColor.MetallicCabernetRed, "#650000" },
        { EGtaColor.MetallicCandyRed, "#d52c2c" },
        { EGtaColor.MetallicSunriseOrange, "#ff9022" },
        { EGtaColor.MetallicClassicGold, "#b78643" },
        { EGtaColor.MetallicOrange, "#a25b01" },
        { EGtaColor.MatteRed, "#850000" },
        { EGtaColor.MatteDarkRed, "#470000" },
        { EGtaColor.MatteOrange, "#ff5400" },
        { EGtaColor.MatteYellow, "#d7c13b" },
        { EGtaColor.UtilRed, "#850000" },
        { EGtaColor.UtilBrightRed, "#ff2b2b" },
        { EGtaColor.UtilGarnetRed, "#8c1010" },
        { EGtaColor.WornRed, "#5e0707" },
        { EGtaColor.WornGoldenRed, "#945d32" },
        { EGtaColor.WornDarkRed, "#470000" },
        { EGtaColor.MetallicDarkGreen, "#213b25" },
        { EGtaColor.MetallicRacingGreen, "#0f2720" },
        { EGtaColor.MetallicSeaGreen, "#0b3f34" },
        { EGtaColor.MetallicOliveGreen, "#6d825b" },
        { EGtaColor.MetallicGreen, "#008000" },
        { EGtaColor.MetallicGasolineBlueGreen, "#0e313d" },
        { EGtaColor.MatteLimeGreen, "#b4d86c" },
        { EGtaColor.UtilDarkGreen, "#213b25" },
        { EGtaColor.UtilGreen, "#008000" },
        { EGtaColor.WornDarkGreen, "#1f271d" },
        { EGtaColor.WornGreen, "#35654b" },
        { EGtaColor.WornSeaWash, "#3b4e52" },
        { EGtaColor.MetallicMidnightBlue, "#1f2838" },
        { EGtaColor.MetallicDarkBlue, "#0b0e13" },
        { EGtaColor.MetallicSaxonyBlue, "#18232c" },
        { EGtaColor.MetallicBlue, "#0f1f2e" },
        { EGtaColor.MetallicMarinerBlue, "#15367a" },
        { EGtaColor.MetallicHarborBlue, "#182c3e" },
        { EGtaColor.MetallicDiamondBlue, "#1e3c5c" },
        { EGtaColor.MetallicSurfBlue, "#11314b" },
        { EGtaColor.MetallicNauticalBlue, "#1d2a46" },
        { EGtaColor.MetallicBrightBlue, "#0a1b2a" },
        { EGtaColor.MetallicPurpleBlue, "#2b3b4e" },
        { EGtaColor.MetallicSpinnakerBlue, "#131f2e" },
        { EGtaColor.MetallicUltraBlue, "#122030" },
        { EGtaColor.MetallicBrightBlue2, "#0a1b2a" },
        { EGtaColor.UtilDarkBlue, "#0b0e13" },
        { EGtaColor.UtilMidnightBlue, "#1f2838" },
        { EGtaColor.UtilBlue, "#0f1f2e" },
        { EGtaColor.UtilSeaFoamBlue, "#aed9e3" },
        { EGtaColor.UtilLightningBlue, "#b3cee6" },
        { EGtaColor.UtilMauiBluePoly, "#4b6584" },
        { EGtaColor.UtilBrightBlue3, "#122030" },
        { EGtaColor.MatteDarkBlue, "#0b0e13" },
        { EGtaColor.MatteBlue, "#0f1f2e" },
        { EGtaColor.MatteMidnightBlue, "#1f2838" },
        { EGtaColor.WornDarkBlue, "#0b0e13" },
        { EGtaColor.WornBlue, "#0f1f2e" },
        { EGtaColor.WornLightBlue, "#1f2838" },
        { EGtaColor.MetallicTaxiYellow, "#ffe600" },
        { EGtaColor.MetallicRaceYellow, "#ffab00" },
        { EGtaColor.MetallicBronze, "#7a4c24" },
        { EGtaColor.MetallicYellowBird, "#ffcc29" },
        { EGtaColor.MetallicLime, "#b4cc2f" },
        { EGtaColor.MetallicChampagne, "#c2b59b" },
        { EGtaColor.MetallicPuebloBeige, "#d2b48c" },
        { EGtaColor.MetallicDarkIvory, "#ffdba8" },
        { EGtaColor.MetallicChocoBrown, "#2e1b14" },
        { EGtaColor.MetallicGoldenBrown, "#45362e" },
        { EGtaColor.MetallicLightBrown, "#816f61" },
        { EGtaColor.MetallicStrawBeige, "#d2b48c" },
        { EGtaColor.MetallicMossBrown, "#2e2b26" },
        { EGtaColor.MetallicBistonBrown, "#47392e" },
        { EGtaColor.MetallicBeechwood, "#8e7a69" },
        { EGtaColor.MetallicDarkBeechwood, "#725d4f" },
        { EGtaColor.MetallicChocoOrange, "#2e1b14" },
        { EGtaColor.MetallicBeachSand, "#d2b48c" },
        { EGtaColor.MetallicSunBleechedSand, "#e6cf9e" },
        { EGtaColor.MetallicCream, "#fffdd0" },
        { EGtaColor.UtilBrown, "#3a2522" },
        { EGtaColor.UtilMediumBrown, "#725d4f" },
        { EGtaColor.UtilLightBrown, "#a18466" },
        { EGtaColor.MetallicWhite, "#ffffff" },
        { EGtaColor.MetallicFrostWhite, "#f4f4f4" },
        { EGtaColor.WornHoneyBeige, "#dbb68d" },
        { EGtaColor.WornBrown, "#725d4f" },
        { EGtaColor.WornDarkBrown, "#47392e" },
        { EGtaColor.WornStrawBeige, "#d2b48c" },
        { EGtaColor.BrushedSteel, "#999999" },
        { EGtaColor.BrushedBlackSteel, "#555555" },
        { EGtaColor.BrushedAluminium, "#cccccc" },
        { EGtaColor.Chrome, "#e0e0e0" },
        { EGtaColor.WornOffWhite, "#f4f4f4" },
        { EGtaColor.UtilOffWhite, "#f4f4f4" },
        { EGtaColor.WornOrange, "#ff6f00" },
        { EGtaColor.WornLightOrange, "#ffdbac" },
        { EGtaColor.MetallicSecuricorGreen, "#4a6956" },
        { EGtaColor.WornTaxiYellow, "#ffe600" },
        { EGtaColor.PoliceCarBlue, "#2e3e4e" },
        { EGtaColor.MatteGreen, "#007f00" },
        { EGtaColor.MatteBrown, "#3a2522" },
        { EGtaColor.WornOrange2, "#ff6f00" },
        { EGtaColor.MatteWhite, "#e6e6e6" },
        { EGtaColor.WornWhite, "#f4f4f4" },
        { EGtaColor.WornOliveArmyGreen, "#4e5b46" },
        { EGtaColor.PureWhite, "#ffffff" },
        { EGtaColor.HotPink, "#ff69b4" },
        { EGtaColor.SalmonPink, "#ff6f7e" },
        { EGtaColor.MetallicVermillionPink, "#db3b3b" },
        { EGtaColor.Orange, "#ff5733" },
        { EGtaColor.Green, "#008000" },
        { EGtaColor.Blue, "#0000ff" },
        { EGtaColor.MettalicBlackBlue, "#050505" },
        { EGtaColor.MetallicBlackPurple, "#050505" },
        { EGtaColor.MetallicBlackRed, "#050505" },
        { EGtaColor.HunterGreen, "#0e312d" },
        { EGtaColor.MetallicPurple, "#5e4f6e" },
        { EGtaColor.MetaillicVDarkBlue, "#050505" },
        { EGtaColor.ModshopBlack, "#0b0e13" },
        { EGtaColor.MattePurple, "#800080" },
        { EGtaColor.MatteDarkPurple, "#3f0f4f" },
        { EGtaColor.MetallicLavaRed, "#1c1e21" },
        { EGtaColor.MatteForestGreen, "#214c2e" },
        { EGtaColor.MatteOliveDrab, "#3a4a3c" },
        { EGtaColor.MatteDesertBrown, "#6b4b35" },
        { EGtaColor.MatteDesertTan, "#bfaf9e" },
        { EGtaColor.MatteFoilageGreen, "#3c5735" },
        { EGtaColor.DefaultAlloy, "#999999" },
        { EGtaColor.EpsilonBlue, "#4b6584" },
        { EGtaColor.PureGold, "#d4af37" },
        { EGtaColor.BrushedGold, "#ffd700" },
    }.ToFrozenDictionary( );


}