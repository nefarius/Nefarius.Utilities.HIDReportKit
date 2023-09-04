namespace Nefarius.Utilities.HID.Devices.Generic.Components;

/// <summary>
///     Describes a report offering special buttons (Select, Start, Menu, Options, Guide, ...) on the device.
/// </summary>
public interface IHasSpecialButtons
{
    /// <summary>
    ///     Gets the left-hand special button.
    /// </summary>
    bool Select { get; }
    
    /// <summary>
    ///     Gets the middle special button.
    /// </summary>
    bool Home { get; }
    
    /// <summary>
    ///     Gets the right-hand special button.
    /// </summary>
    bool Start { get; }
}