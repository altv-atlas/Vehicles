using System.Drawing;
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
}