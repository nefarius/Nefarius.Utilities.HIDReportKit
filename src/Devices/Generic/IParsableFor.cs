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
    ///     The underlying report buffer.
    /// </summary>
    Span<byte> ReportBuffer { get; }

    /// <summary>
    ///     Parses the input report from <see cref="ReportBuffer"/>.
    /// </summary>
    void Parse();
    
    /// <summary>
    ///     Parses a provided input report into this instance.
    /// </summary>
    /// <param name="report">The raw report to parse.</param>
    /// <remarks>Provide the start of the report WITHOUT the report ID.</remarks>
    void Parse(ref TRaw report);

    /// <summary>
    ///     Parses a provided input report into this instance.
    /// </summary>
    /// <param name="report">The raw report to parse.</param>
    /// <remarks>Provide the start of the report WITHOUT the report ID.</remarks>
    void Parse(byte[] report);
    
    /// <summary>
    ///     Parses a provided input report into this instance.
    /// </summary>
    /// <param name="report">The raw report to parse.</param>
    /// <remarks>Provide the start of the report WITHOUT the report ID.</remarks>
    void Parse(ReadOnlySpan<byte> report);
}