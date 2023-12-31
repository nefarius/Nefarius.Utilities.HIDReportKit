﻿using System.Diagnostics.CodeAnalysis;

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
    /// <remarks>The Xbox-series of controllers use this format via the XInput API.</remarks>
    Short,

    /// <summary>
    ///     Axis range is represented by an unsigned byte. The value is between 0 and 255.
    /// </summary>
    /// <remarks>The PlayStation™ controllers use this format both wired and wireless.</remarks>
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

/// <summary>
///     Possible battery states.
/// </summary>
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public enum BatteryState
{
    /// <summary>
    ///     Not known.
    /// </summary>
    Unknown,

    /// <summary>
    ///     Battery is discharging.
    /// </summary>
    Discharging,

    /// <summary>
    ///     Battery is charging.
    /// </summary>
    Charging,

    /// <summary>
    ///     Charging is complete.
    /// </summary>
    Complete
}

/// <summary>
///     Possible D-Pad directions in POV (point of view) or hat switch format.
/// </summary>
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public enum DPadPointOfView
{
    /// <summary>
    ///     The resting (default, not engaged) position.
    /// </summary>
    Default,

    /// <summary>
    ///     The up and left direction.
    /// </summary>
    NorthWest,

    /// <summary>
    ///     The left direction.
    /// </summary>
    West,

    /// <summary>
    ///     The down and left direction.
    /// </summary>
    SouthWest,

    /// <summary>
    ///     The down direction.
    /// </summary>
    South,

    /// <summary>
    ///     The down and right direction.
    /// </summary>
    SouthEast,

    /// <summary>
    ///     The right direction.
    /// </summary>
    East,

    /// <summary>
    ///     The up and right direction.
    /// </summary>
    NorthEast,

    /// <summary>
    ///     The up direction.
    /// </summary>
    North
}
