namespace Nefarius.Utilities.HID.Devices;

/// <summary>
///     Possible D-Pad directions.
/// </summary>
public enum DPadDirection
{
    Default = 0x8,
    NorthWest = 0x7,
    West = 0x6,
    SouthWest = 0x5,
    South = 0x4,
    SouthEast = 0x3,
    East = 0x2,
    NorthEast = 0x1,
    North = 0x0
}