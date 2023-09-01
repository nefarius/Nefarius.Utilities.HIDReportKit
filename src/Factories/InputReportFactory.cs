using System.Diagnostics.CodeAnalysis;

using Nefarius.Utilities.HID.Devices.DualSense;

namespace Nefarius.Utilities.HID.Factories;

/// <summary>
///     Utility methods to create new input reports.
/// </summary>
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public static class InputReportFactory
{
    /// <summary>
    ///     Creates a new y<see cref="DualSenseInputReport"/> and initializes a default state.
    /// </summary>
    public static DualSenseInputReport CreateDualSenseInputReport()
    {
        return new DualSenseInputReport();
    }
}