using System.Diagnostics.CodeAnalysis;

namespace Nefarius.Utilities.HID.Devices.Generic;

/// <summary>
///     Marks a type as supporting report parsing.
/// </summary>
[SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public interface IParsableFor<TRaw> where TRaw : IRawInputReportStruct
{
    /// <summary>
    ///     Parses a provided input report into this instance.
    /// </summary>
    /// <param name="report">The raw report to parse.</param>
    void Parse(ref TRaw report);

    /// <summary>
    ///     Parses a provided input report into this instance.
    /// </summary>
    /// <param name="report">The raw report to parse.</param>
    void Parse(byte[] report);

#if NETCOREAPP3_0_OR_GREATER
    /// <summary>
    ///     Parses a provided input report into this instance.
    /// </summary>
    /// <param name="report">The raw report to parse.</param>
    void Parse(ReadOnlySpan<byte> report);
#endif
}