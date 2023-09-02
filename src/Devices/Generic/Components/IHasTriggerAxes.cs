namespace Nefarius.Utilities.HID.Devices.Generic.Components;

/// <summary>
///     Describes a report offering the 2 analogue buttons (triggers) on the top back of the device.
/// </summary>
public interface IHasTriggerAxes
{
    /// <summary>
    ///     Gets the left trigger value.
    /// </summary>
    int L2 { get; }
    
    /// <summary>
    ///     Gets the right trigger value.
    /// </summary>
    int R2 { get; }
}