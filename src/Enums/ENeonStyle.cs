namespace AltV.Atlas.Vehicles.Enums;

[Flags]
public enum ENeonStyle
{
    None = 0,
    Left = 1,
    Right = 2,
    Top = 4,
    Back = 8,

    LeftRight = Left | Right,
    LeftTop = Left | Top,
    LeftBack = Left | Back,
    RightTop = Right | Top,
    RightBack = Right | Back,
    TopBack = Top | Back,

    LeftRightTop = Left | Right | Top,
    LeftRightBack = Left | Right | Back,
    LeftTopBack = Left | Top | Back,
    RightTopBack = Right | Top | Back,

    LeftRightTopBack = Left | Right | Top | Back
}
