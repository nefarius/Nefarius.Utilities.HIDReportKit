using System.Diagnostics.CodeAnalysis;

namespace Nefarius.Utilities.HID.Devices;

/// <summary>
///     Possible D-Pad directions for DualShock™/DualSense™ compatible reports.
/// </summary>
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public enum DPadDirection
{
    /// <summary>
    ///     The resting (default, not engaged) position.
    /// </summary>
    Default = 0x8,

    /// <summary>
    ///     The up and left direction.
    /// </summary>
    NorthWest = 0x7,

    /// <summary>
    ///     The left direction.
    /// </summary>
    West = 0x6,

    /// <summary>
    ///     The down and left direction.
    /// </summary>
    SouthWest = 0x5,

    /// <summary>
    ///     The down direction.
    /// </summary>
    South = 0x4,

    /// <summary>
    ///     The down and right direction.
    /// </summary>
    SouthEast = 0x3,

    /// <summary>
    ///     The right direction.
    /// </summary>
    East = 0x2,

    /// <summary>
    ///     The up and right direction.
    /// </summary>
    NorthEast = 0x1,

    /// <summary>
    ///     The up direction.
    /// </summary>
    North = 0x0
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