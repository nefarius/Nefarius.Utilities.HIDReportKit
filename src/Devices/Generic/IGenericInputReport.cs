// ReSharper disable once RedundantUsingDirective
using System;

namespace Nefarius.Utilities.HID.Devices.Generic;

/// <summary>
///     A minimal managed input report description.
/// </summary>
public interface IGenericInputReport
{
    /// <summary>
    ///     Gets the report ID.
    /// </summary>
    byte ReportId { get; }

    /// <summary>
    ///     Gets idle state.
    /// </summary>
    bool IsIdle { get; }

    /// <summary>
    ///     Gets L1 value.
    /// </summary>
    bool L1 { get; }

    /// <summary>
    ///     Gets R1 value.
    /// </summary>
    bool R1 { get; }

    /// <summary>
    ///     Gets L2 value.
    /// </summary>
    int L2 { get; }

    /// <summary>
    ///     Gets R1 value.
    /// </summary>
    int R2 { get; }

    /// <summary>
    ///     Gets L3 value.
    /// </summary>
    bool L3 { get; }

    /// <summary>
    ///     Gets R3 value.
    /// </summary>
    bool R3 { get; }

    /// <summary>
    ///     Gets the directional pad.
    /// </summary>
    DPadDirection DPad { get; }

    /// <summary>
    ///     Gets the top face button.
    /// </summary>
    bool Top { get; }

    /// <summary>
    ///     Gets the bottom face button.
    /// </summary>
    bool Bottom { get; }

    /// <summary>
    ///     Gets the left face button.
    /// </summary>
    bool Left { get; }

    /// <summary>
    ///     Gets the right face button.
    /// </summary>
    bool Right { get; }
}