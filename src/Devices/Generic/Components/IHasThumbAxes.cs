namespace Nefarius.Utilities.HID.Devices.Generic.Components;

/// <summary>
///     Describes a report offering the 2 analogue thumbstick axes on the device.
/// </summary>
public interface IHasThumbAxes
{
    /// <summary>
    ///     Gets the left thumb X (West-to-East) axis position. 
    /// </summary>
    short LeftThumbX { get; }
    
    /// <summary>
    ///     Gets the left thumb Y (North-to-South) axis position.
    /// </summary>
    short LeftThumbY { get; }
    
    /// <summary>
    ///     Gets the right thumb X (West-to-East) axis position. 
    /// </summary>
    short RightThumbX { get; }
    
    /// <summary>
    ///     Gets the right thumb Y (North-to-South) axis position.
    /// </summary>
    short RightThumbY { get; }
}