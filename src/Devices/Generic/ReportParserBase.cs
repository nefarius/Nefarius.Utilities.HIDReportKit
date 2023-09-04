// ReSharper disable once RedundantUsingDirective

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using Nefarius.Utilities.HID.Util;

namespace Nefarius.Utilities.HID.Devices.Generic;

/// <summary>
///     Base class implementing <see cref="IParsableFor{TRaw}" />.
/// </summary>
/// <typeparam name="TRaw">An implementation of <see cref="IRawInputReportStruct" />.</typeparam>
public abstract class ReportParserBase<TRaw> : IParsableFor<TRaw> where TRaw : struct, IRawInputReportStruct
{
    internal ReportParserBase() { }

    /// <inheritdoc />
    public abstract Span<byte> ReportBuffer { get; }

    /// <inheritdoc />
    public void Parse()
    {
        Parse(ReportBuffer);
    }

    /// <inheritdoc />
    public abstract void Parse(ref TRaw report);

    /// <inheritdoc />
    public void Parse(byte[] report)
    {
        Parse((ReadOnlySpan<byte>)report);
    }

    /// <inheritdoc />
    public void Parse(ReadOnlySpan<byte> report)
    {
#if NETCOREAPP3_0_OR_GREATER
        TRaw data = MemoryMarshal.AsRef<TRaw>(report[1..]);;
        Parse(ref data);
#else
        TRaw data = MemoryMarshal.Read<TRaw>(report[1..]);
        Parse(ref data);
#endif
    }
}