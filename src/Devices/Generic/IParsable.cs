namespace Nefarius.Utilities.HID.Devices.Generic;

/// <summary>
///     Marks a type as supporting report parsing.
/// </summary>
public interface IParsable
{
    /// <summary>
    ///     Parses a provided input report into this instance.
    /// </summary>
    /// <param name="report">The raw report to parse.</param>
    /// <typeparam name="TRaw">The raw report type.</typeparam>
    void Parse<TRaw>(ref TRaw report) where TRaw : struct;

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