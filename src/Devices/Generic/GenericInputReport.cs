﻿// ReSharper disable once RedundantUsingDirective

using System;

using Generator.Equals;

namespace Nefarius.Utilities.HID.Devices.Generic;

/// <summary>
///     Minimal implementation of a device-agnostic parsed input report.
/// </summary>
[Equatable]
internal sealed partial class GenericInputReport : IGenericInputReport
{
    /// <inheritdoc />
    [IgnoreEquality]
    public byte ReportId { get; }

    /// <inheritdoc />
    [IgnoreEquality]
    public bool IsIdle { get; }

    /// <inheritdoc />
    public bool L1 { get; set; }

    /// <inheritdoc />
    public bool R1 { get; set; }

    /// <inheritdoc />
    public int L2 { get; set; }

    /// <inheritdoc />
    public int R2 { get; set; }

    /// <inheritdoc />
    public bool L3 { get; set; }

    /// <inheritdoc />
    public bool R3 { get; set; }

    /// <inheritdoc />
    public DPadDirection DPad { get; set; } = DPadDirection.Default;

    /// <inheritdoc />
    public bool Top { get; set; }

    /// <inheritdoc />
    public bool Bottom { get; set; }

    /// <inheritdoc />
    public bool Left { get; set; }

    /// <inheritdoc />
    public bool Right { get; set; }
}