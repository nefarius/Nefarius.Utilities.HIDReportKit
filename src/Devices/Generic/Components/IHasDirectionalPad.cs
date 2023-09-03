using System.Diagnostics.CodeAnalysis;

namespace Nefarius.Utilities.HID.Devices.Generic.Components;

/// <summary>
///     Describes a report offering a directional pad on the device.
/// </summary>
[SuppressMessage("ReSharper", "InconsistentNaming")]
public interface IHasDirectionalPad
{
    /// <summary>
    ///     Gets whether the up-direction is engaged.
    /// </summary>
    bool Up { get; }

    /// <summary>
    ///     Gets whether the right-direction is engaged.
    /// </summary>
    bool Right { get; }

    /// <summary>
    ///     Gets whether the down-direction is engaged.
    /// </summary>
    bool Down { get; }

    /// <summary>
    ///     Gets whether the left-direction is engaged.
    /// </summary>
    bool Left { get; }

    /// <summary>
    ///     Gets the directional pad state as <see cref="DPadPointOfView"/> format.
    /// </summary>
    DPadPointOfView AsPOV();
}