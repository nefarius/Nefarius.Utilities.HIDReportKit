namespace Nefarius.Utilities.HID.Devices.Generic.Components;

/// <summary>
///     Describes a report offering the 2 digital thumbstick buttons on the device.
/// </summary>
public interface IHasThumbButtons
{
    /// <summary>
    ///     Gets the left thumb button.
    /// </summary>
    bool L3 { get; }
    
    /// <summary>
    ///     Gets the right thumb button.
    /// </summary>
    bool R3 { get; }
}