// ReSharper disable once RedundantUsingDirective
using System;

namespace Nefarius.Utilities.HID.Devices.Generic;

/// <summary>
///     Minimal implementation of a device-agnostic parsed input report.
/// </summary>
public class GenericInputReport : IGenericInputReport
{
    /// <inheritdoc />
    public byte ReportId { get; }

    /// <inheritdoc />
    public bool IsIdle { get; }

    /// <inheritdoc />
    public bool L1 { get; }
    
    /// <inheritdoc />
    public bool R1 { get; }
    
    /// <inheritdoc />
    public int L2 { get; }
    
    /// <inheritdoc />
    public int R2 { get; }

    /// <inheritdoc />
    public bool L3 { get; }
    
    /// <inheritdoc />
    public bool R3 { get; }

    /// <inheritdoc />
    public DPadDirection DPad { get; }

    /// <inheritdoc />
    public bool Top { get; }
    
    /// <inheritdoc />
    public bool Bottom { get; }
    
    /// <inheritdoc />
    public bool Left { get; }
    
    /// <inheritdoc />
    public bool Right { get; }

    /// <inheritdoc />
    public void Parse<TRaw>(TRaw report) where TRaw : struct
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public void Parse(byte[] report)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public void Parse(ReadOnlySpan<byte> report)
    {
        throw new NotImplementedException();
    }
}