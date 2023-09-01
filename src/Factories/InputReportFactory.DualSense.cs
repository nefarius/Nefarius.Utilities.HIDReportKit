using System.Diagnostics.CodeAnalysis;

using Nefarius.Utilities.HID.Devices.DualSense;

namespace Nefarius.Utilities.HID.Factories;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
public static partial class InputReportFactory
{
    /// <summary>
    ///     Creates a new y<see cref="DualSenseInputReport" /> and initializes a default state.
    /// </summary>
    public static DualSenseInputReport CreateDualSenseInputReport()
    {
        return new DualSenseInputReport();
    }

    /// <summary>
    ///     Creates a new y<see cref="DualSenseInputReport" /> and parses the provided raw report.
    /// </summary>
    public static DualSenseInputReport CreateDualSenseInputReport(byte[] report)
    {
        DualSenseInputReport managed = new();
        managed.Parse(report);

        return managed;
    }

#if NETCOREAPP3_0_OR_GREATER
    /// <summary>
    ///     Creates a new y<see cref="DualSenseInputReport" /> and parses the provided raw report.
    /// </summary>
    public static DualSenseInputReport CreateDualSenseInputReport(ReadOnlySpan<byte> report)
    {
        DualSenseInputReport managed = new();
        managed.Parse(report);

        return managed;
    }
#endif
}