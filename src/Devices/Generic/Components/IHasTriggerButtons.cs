namespace Nefarius.Utilities.HID.Devices.Generic.Components;

/// <summary>
///     Describes a report offering the 2 digital buttons (triggers) on the top back of the device.
/// </summary>
public interface IHasTriggerButtons
{
    /// <summary>
    ///     Gets the left trigger state.
    /// </summary>
    bool L2 { get; }
    
    /// <summary>
    ///     Gets the right trigger state.
    /// </summary>
    bool R2 { get; }
}