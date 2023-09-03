namespace Nefarius.Utilities.HID.Devices.Generic.Components;

/// <summary>
///     Describes a report offering battery information of the device.
/// </summary>
public interface IHasBattery
{
    /// <summary>
    ///     Gets the status of the battery.
    /// </summary>
    BatteryState? BatteryState { get; }

    /// <summary>
    ///     Gets the battery charge percentage. Only set if <see cref="BatteryState" /> is in the appropriate state.
    /// </summary>
    byte? BatteryPercentage { get; }
}