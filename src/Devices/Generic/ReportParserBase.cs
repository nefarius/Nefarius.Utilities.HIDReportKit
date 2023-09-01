// ReSharper disable once RedundantUsingDirective

using System.Runtime.InteropServices;

using Nefarius.Utilities.HID.Util;

namespace Nefarius.Utilities.HID.Devices.Generic;

/// <summary>
///     Base class derived from <see cref="IParsableFor{TRaw}"/>.
/// </summary>
/// <typeparam name="TRaw"></typeparam>
public abstract class ReportParserBase<TRaw> : IParsableFor<TRaw> where TRaw : struct, IRawInputReportStruct
{
    internal ReportParserBase() { }

    /// <inheritdoc />
    public abstract void Parse(ref TRaw report);

    /// <inheritdoc />
    public void Parse(byte[] report)
    {
#if NETCOREAPP3_0_OR_GREATER
        Parse((ReadOnlySpan<byte>)report);
#else
        // fallback for older frameworks
        GCHandle handle = GCHandle.Alloc(report, GCHandleType.Pinned);
        TRaw data =
            (TRaw)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(TRaw));
        Parse(ref data);
        handle.Free();
#endif
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
}