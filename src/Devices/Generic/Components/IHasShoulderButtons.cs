namespace Nefarius.Utilities.HID.Devices.Generic.Components;

/// <summary>
///     Describes a report offering the 2 digital buttons (shoulders, bumpers) on the top of the device.
/// </summary>
public interface IHasShoulderButtons
{
    /// <summary>
    ///     Gets the left shoulder/bumper.
    /// </summary>
    bool L1 { get; }
    
    /// <summary>
    ///     Gets the right shoulder/bumper.
    /// </summary>
    bool R1 { get; }
}