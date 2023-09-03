using System.Diagnostics.CodeAnalysis;

namespace Nefarius.Utilities.HID.Devices.Generic.Components;

/// <summary>
///     Describes a report offering a directional pad on the device.
/// </summary>
[SuppressMessage("ReSharper", "InconsistentNaming")]
public interface IHasDirectionalPad
{
    bool Up { get; }

    bool Right { get; }

    bool Down { get; }

    bool Left { get; }

    /// <summary>
    ///     Gets the directional pad state as <see cref="DPadPointOfView"/> format.
    /// </summary>
    DPadPointOfView AsPOV();
}