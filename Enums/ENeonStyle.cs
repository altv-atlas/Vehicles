namespace AltV.Atlas.Vehicles.Server.Enums;

/// <summary>
/// Enum to simplify neon states
/// </summary>
[Flags]
public enum ENeonStyle
{
    ///<summary>None active</summary>
    None = 0,
    ///<summary>Left active</summary>
    Left = 1,
    ///<summary>Right active</summary>
    Right = 2,
    ///<summary>Top active</summary>
    Top = 4,
    ///<summary>Back active</summary>
    Back = 8,

    ///<summary>Left and right active</summary>
    LeftRight = Left | Right,
    ///<summary>Left and top active</summary>
    LeftTop = Left | Top,
    ///<summary>Left and back active</summary>
    LeftBack = Left | Back,
    ///<summary>Right and top active</summary>
    RightTop = Right | Top,
    ///<summary>Right and back active</summary>
    RightBack = Right | Back,
    ///<summary>Top and back active</summary>
    TopBack = Top | Back,

    ///<summary>Left, right and top active</summary>
    LeftRightTop = Left | Right | Top,
    ///<summary>Left, right and back active</summary>
    LeftRightBack = Left | Right | Back,
    ///<summary>Left, top and back active</summary>
    LeftTopBack = Left | Top | Back,
    ///<summary>Right, top and back active</summary>
    RightTopBack = Right | Top | Back,

    ///<summary>All active</summary>
    LeftRightTopBack = Left | Right | Top | Back
}
