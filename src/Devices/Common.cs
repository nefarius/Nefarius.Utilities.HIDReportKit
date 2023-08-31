using System.Diagnostics.CodeAnalysis;

namespace Nefarius.Utilities.HID.Devices;

/// <summary>
///     Possible D-Pad directions for DualShock™/DualSense™ compatible reports.
/// </summary>
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public enum DPadDirection
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Default = 0x8,
    NorthWest = 0x7,
    West = 0x6,
    SouthWest = 0x5,
    South = 0x4,
    SouthEast = 0x3,
    East = 0x2,
    NorthEast = 0x1,
    North = 0x0
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}

/// <summary>
///     Possible axis ranges.
/// </summary>
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public enum AxisRangeType
{
    /// <summary>
    ///     Axis range is represented by a signed 16-bit integer. The value is between -32768 and 32767.
    /// </summary>
    Short,

    /// <summary>
    ///     Axis range is represented by an unsigned byte. The value is between 0 and 255.
    /// </summary>
    Byte
}

/// <summary>
///     Possible trigger ranges.
/// </summary>
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public enum TriggerRangeType
{
    /// <summary>
    ///     Axis range is represented by an unsigned byte. The value is between 0 and 255.
    /// </summary>
    Byte
}