﻿using System.Collections.Frozen;
using AltV.Atlas.Vehicles.Enums;
namespace AltV.Atlas.Vehicles.Data;

/// <summary>
/// A class that holds GtaColor extensions
/// </summary>
public static class GtaColor
{
    /// <summary>
    /// A map of all hex values for the representing GTA color
    /// </summary>
    public static readonly FrozenDictionary<EGtaColor, string> ColorHexMap = new Dictionary<EGtaColor, string>
    {
        //TODO: The hex colors doesnt match yet needs to be done at some point
        { EGtaColor.MetallicBlack, "#0d1116" },
        { EGtaColor.MetallicGraphiteBlack, "#1c1e21" },
        { EGtaColor.MetallicBlackSteal, "#32383d" },
        { EGtaColor.MetallicDarkSilver, "#454b4f" },
        { EGtaColor.MetallicSilver, "#999da0" },
        { EGtaColor.MetallicBlueSilver, "#c2c4c6" },
        { EGtaColor.MetallicSteelGray, "#979a97" },
        { EGtaColor.MetallicShadowSilver, "#637380" },
        { EGtaColor.MetallicStoneSilver, "#63625c" },
        { EGtaColor.MetallicMidnightSilver, "#3c3f47" },
        { EGtaColor.MetallicGunMetal, "#444e54" },
        { EGtaColor.MetallicAnthraciteGrey, "#1d2129" },
        { EGtaColor.MatteBlack, "#13181f" },
        { EGtaColor.MatteGray, "#26282a" },
        { EGtaColor.MatteLightGrey, "#515554" },
        { EGtaColor.UtilBlack, "#151921" },
        { EGtaColor.UtilBlackPoly, "#1e2429" },
        { EGtaColor.UtilDarkSilver, "#333a3c" },
        { EGtaColor.UtilSilver, "#8c9095" },
        { EGtaColor.UtilGunMetal, "#39434d" },
        { EGtaColor.UtilShadowSilver, "#506272" },
        { EGtaColor.WornBlack, "#1e232f" },
        { EGtaColor.WornGraphite, "#363a3f" },
        { EGtaColor.WornSilverGrey, "#a0a199" },
        { EGtaColor.WornSilver, "#d3d3d3" },
        { EGtaColor.WornBlueSilver, "#b7bfca" },
        { EGtaColor.WornShadowSilver, "#778794" },
        { EGtaColor.MetallicRed, "#c00e1a" },
        { EGtaColor.MetallicTorinoRed, "#da1918" },
        { EGtaColor.MetallicFormulaRed, "#b6111b" },
        { EGtaColor.MetallicBlazeRed, "#a51e23" },
        { EGtaColor.MetallicGracefulRed, "#7b1a22" },
        { EGtaColor.MetallicGarnetRed, "#8e1b1f" },
        { EGtaColor.MetallicDesertRed, "#6f1818" },
        { EGtaColor.MetallicCabernetRed, "#49111d" },
        { EGtaColor.MetallicCandyRed, "#b60f25" },
        { EGtaColor.MetallicSunriseOrange, "#d44a17" },
        { EGtaColor.MetallicClassicGold, "#c2944f" },
        { EGtaColor.MetallicOrange, "#f78616" },
        { EGtaColor.MatteRed, "#cf1f21" },
        { EGtaColor.MatteDarkRed, "#732021" },
        { EGtaColor.MatteOrange, "#f27d20" },
        { EGtaColor.MatteYellow, "#ffc91f" },
        { EGtaColor.UtilRed, "#9c1016" },
        { EGtaColor.UtilBrightRed, "#de0f18" },
        { EGtaColor.UtilGarnetRed, "#8f1e17" },
        { EGtaColor.WornRed, "#a94744" },
        { EGtaColor.WornGoldenRed, "#b16c51" },
        { EGtaColor.WornDarkRed, "#371c25" },
        { EGtaColor.MetallicDarkGreen, "#132428" },
        { EGtaColor.MetallicRacingGreen, "#122e2b" },
        { EGtaColor.MetallicSeaGreen, "#12383c" },
        { EGtaColor.MetallicOliveGreen, "#31423f" },
        { EGtaColor.MetallicGreen, "#155c2d" },
        { EGtaColor.MetallicGasolineBlueGreen, "#1b6770" },
        { EGtaColor.MatteLimeGreen, "#66b81f" },
        { EGtaColor.UtilDarkGreen, "#22383e" },
        { EGtaColor.UtilGreen, "#1d5a3f" },
        { EGtaColor.WornDarkGreen, "#2d423f" },
        { EGtaColor.WornGreen, "#45594b" },
        { EGtaColor.WornSeaWash, "#65867f" },
        { EGtaColor.MetallicMidnightBlue, "#222e46" },
        { EGtaColor.MetallicDarkBlue, "#233155" },
        { EGtaColor.MetallicSaxonyBlue, "#304c7e" },
        { EGtaColor.MetallicBlue, "#47578f" },
        { EGtaColor.MetallicMarinerBlue, "#637ba7" },
        { EGtaColor.MetallicHarborBlue, "#394762" },
        { EGtaColor.MetallicDiamondBlue, "#d6e7f1" },
        { EGtaColor.MetallicSurfBlue, "#76afbe" },
        { EGtaColor.MetallicNauticalBlue, "#345e72" },
        { EGtaColor.MetallicBrightBlue, "#0b9cf1" },
        { EGtaColor.MetallicPurpleBlue, "#2f2d52" },
        { EGtaColor.MetallicSpinnakerBlue, "#282c4d" },
        { EGtaColor.MetallicUltraBlue, "#2354a1" },
        { EGtaColor.MetallicBrightBlue2, "#6ea3c6" },
        { EGtaColor.UtilDarkBlue, "#112552" },
        { EGtaColor.UtilMidnightBlue, "#1b203e" },
        { EGtaColor.UtilBlue, "#275190" },
        { EGtaColor.UtilSeaFoamBlue, "#608592" },
        { EGtaColor.UtilLightningBlue, "#2446a8" },
        { EGtaColor.UtilMauiBluePoly, "#4271e1" },
        { EGtaColor.UtilBrightBlue3, "#3b39e0" },
        { EGtaColor.MatteDarkBlue, "#1f2852" },
        { EGtaColor.MatteBlue, "#253aa7" },
        { EGtaColor.MatteMidnightBlue, "#1c3551" },
        { EGtaColor.WornDarkBlue, "#4c5f81" },
        { EGtaColor.WornBlue, "#58688e" },
        { EGtaColor.WornLightBlue, "#74b5d8" },
        { EGtaColor.MetallicTaxiYellow, "#ffcf20" },
        { EGtaColor.MetallicRaceYellow, "#fbe212" },
        { EGtaColor.MetallicBronze, "#916532" },
        { EGtaColor.MetallicYellowBird, "#e0e13d" },
        { EGtaColor.MetallicLime, "#98d223" },
        { EGtaColor.MetallicChampagne, "#9b8c78" },
        { EGtaColor.MetallicPuebloBeige, "#503218" },
        { EGtaColor.MetallicDarkIvory, "#473f2b" },
        { EGtaColor.MetallicChocoBrown, "#221b19" },
        { EGtaColor.MetallicGoldenBrown, "#653f23" },
        { EGtaColor.MetallicLightBrown, "#775c3e" },
        { EGtaColor.MetallicStrawBeige, "#ac9975" },
        { EGtaColor.MetallicMossBrown, "#6c6b4b" },
        { EGtaColor.MetallicBistonBrown, "#402e2b" },
        { EGtaColor.MetallicBeechwood, "#a4965f" },
        { EGtaColor.MetallicDarkBeechwood, "#46231a" },
        { EGtaColor.MetallicChocoOrange, "#752b19" },
        { EGtaColor.MetallicBeachSand, "#bfae7b" },
        { EGtaColor.MetallicSunBleechedSand, "#dfd5b2" },
        { EGtaColor.MetallicCream, "#f7edd5" },
        { EGtaColor.UtilBrown, "#3a2a1b" },
        { EGtaColor.UtilMediumBrown, "#785f33" },
        { EGtaColor.UtilLightBrown, "#b5a079" },
        { EGtaColor.MetallicWhite, "#fffff6" },
        { EGtaColor.MetallicFrostWhite, "#eaeaea" },
        { EGtaColor.WornHoneyBeige, "#b0ab94" },
        { EGtaColor.WornBrown, "#453831" },
        { EGtaColor.WornDarkBrown, "#2a282b" },
        { EGtaColor.WornStrawBeige, "#726c57" },
        { EGtaColor.BrushedSteel, "#6a747c" },
        { EGtaColor.BrushedBlackSteel, "#354158" },
        { EGtaColor.BrushedAluminium, "#9ba0a8" },
        { EGtaColor.Chrome, "#5870a1" },
        { EGtaColor.WornOffWhite, "#eae6de" },
        { EGtaColor.UtilOffWhite, "#dfddd0" },
        { EGtaColor.WornOrange, "#f2ad2e" },
        { EGtaColor.WornLightOrange, "#f9a458" },
        { EGtaColor.MetallicSecuricorGreen, "#83c566" },
        { EGtaColor.WornTaxiYellow, "#f1cc40" },
        { EGtaColor.PoliceCarBlue, "#4cc3da" },
        { EGtaColor.MatteGreen, "#4e6443" },
        { EGtaColor.MatteBrown, "#bcac8f" },
        { EGtaColor.WornOrange2, "#f8b658" },
        { EGtaColor.MatteWhite, "#fcf9f1" },
        { EGtaColor.WornWhite, "#fffffb" },
        { EGtaColor.WornOliveArmyGreen, "#81844c" },
        { EGtaColor.PureWhite, "#ffffff" },
        { EGtaColor.HotPink, "#f21f99" },
        { EGtaColor.SalmonPink, "#fdd6cd" },
        { EGtaColor.MetallicVermillionPink, "#df5891" },
        { EGtaColor.Orange, "#f6ae20" },
        { EGtaColor.Green, "#b0ee6e" },
        { EGtaColor.Blue, "#08e9fa" },
        { EGtaColor.MettalicBlackBlue, "#0a0c17" },
        { EGtaColor.MetallicBlackPurple, "#0c0d18" },
        { EGtaColor.MetallicBlackRed, "#0e0d14" },
        { EGtaColor.HunterGreen, "#9f9e8a" },
        { EGtaColor.MetallicPurple, "#621276" },
        { EGtaColor.MetaillicVDarkBlue, "#0b1421" },
        { EGtaColor.ModshopBlack, "#11141a" },
        { EGtaColor.MattePurple, "#6b1f7b" },
        { EGtaColor.MatteDarkPurple, "#1e1d22" },
        { EGtaColor.MetallicLavaRed, "#bc1917" },
        { EGtaColor.MatteForestGreen, "#2d362a" },
        { EGtaColor.MatteOliveDrab, "#696748" },
        { EGtaColor.MatteDesertBrown, "#7a6c55" },
        { EGtaColor.MatteDesertTan, "#c3b492" },
        { EGtaColor.MatteFoilageGreen, "#5a6352" },
        { EGtaColor.DefaultAlloy, "#81827f" },
        { EGtaColor.EpsilonBlue, "#afd6e4" },
        { EGtaColor.PureGold, "#7a6440" },
        { EGtaColor.BrushedGold, "#7f6a48" },
    }.ToFrozenDictionary( );


}