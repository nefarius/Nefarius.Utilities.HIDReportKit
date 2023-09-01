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
    public void Parse(ref TRaw report)
    {
        int reportSize = Marshal.SizeOf(report);

        if (Unsafe.SizeOf<TRaw>() != reportSize)
        {
            throw new ArgumentOutOfRangeException(nameof(report),
                $"Unexpected report size of {reportSize} bytes received.");
        }

        ParseInternal(ref report);
    }

    /// <inheritdoc />
    public void Parse(byte[] report)
    {
        Parse((ReadOnlySpan<byte>)report);
    }

    /// <inheritdoc />
    public void Parse(IEnumerable<byte> report)
    {
        Parse((ReadOnlySpan<byte>)report.ToArray());
    }

    /// <inheritdoc />
    public void Parse(ReadOnlySpan<byte> report)
    {
#if NETCOREAPP3_0_OR_GREATER
        TRaw data = report.AsStruct<TRaw>();
        Parse(ref data);
#else
        TRaw data = MemoryMarshal.Read<TRaw>(report);
        Parse(ref data);
#endif
    }

    /// <summary>
    ///     Report parsing logic implemented by derived class.
    /// </summary>
    protected abstract void ParseInternal(ref TRaw report);
}