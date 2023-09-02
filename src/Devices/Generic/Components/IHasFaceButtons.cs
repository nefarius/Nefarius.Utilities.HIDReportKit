namespace Nefarius.Utilities.HID.Devices.Generic.Components;

/// <summary>
///     Describes a report offering the 4 common face buttons on the right-hand-side of the device.
/// </summary>
public interface IHasFaceButtons
{
    /// <summary>
    ///     Gets the top face button.
    /// </summary>
    bool Top { get; }

    /// <summary>
    ///     Gets the bottom face button.
    /// </summary>
    bool Bottom { get; }

    /// <summary>
    ///     Gets the left face button.
    /// </summary>
    bool Left { get; }

    /// <summary>
    ///     Gets the right face button.
    /// </summary>
    bool Right { get; }
}