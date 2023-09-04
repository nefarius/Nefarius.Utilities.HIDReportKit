using System.Diagnostics.CodeAnalysis;

using Generator.Equals;

using Nefarius.Utilities.HID.Devices.DualSense.In;

namespace Nefarius.Utilities.HID.Devices.DualSense;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
[SuppressMessage("ReSharper", "MemberCanBeProtected.Global")]
public partial class DualSenseInputReport
{
    /// <summary>
    ///     Gets the expected <see cref="AxisRangeType" /> of the thumb axes.
    /// </summary>
    [IgnoreEquality]
    public AxisRangeType AxisScaleInputType => AxisRangeType.Byte;

    /// <summary>
    ///     Gets the battery state (charging, charged, ...).
    /// </summary>
    public PowerState? BatteryState { get; protected set; }

    /// <summary>
    ///     Gets the D-Pad state.
    /// </summary>
    public DPadDirection DPad => _generic.DPad;

    /// <summary>
    ///     Gets whether the Left Shoulder button is pressed or not.
    /// </summary>
    public bool LeftShoulder => _generic.L1;

    /// <summary>
    ///     Gets whether the Right Shoulder button is pressed or not.
    /// </summary>
    public bool RightShoulder => _generic.R1;

    /// <summary>
    ///     Gets whether L2 button is pressed or not.
    /// </summary>
    public byte LeftTrigger { get; protected set; }

    /// <summary>
    ///     Gets whether the Left Trigger Button button is pressed or not.
    /// </summary>
    public bool LeftTriggerButton { get; protected set; }

    /// <summary>
    ///     Gets whether R2 button is pressed or not.
    /// </summary>
    public byte RightTrigger { get; protected set; }

    /// <summary>
    ///     Gets whether the Right Trigger Button button is pressed or not.
    /// </summary>
    public bool RightTriggerButton { get; protected set; }

    /// <summary>
    ///     Gets whether L3 button is pressed or not.
    /// </summary>
    public bool LeftThumb => _generic.L3;

    /// <summary>
    ///     Gets whether R3 button is pressed or not.
    /// </summary>
    public bool RightThumb => _generic.R3;

    /// <summary>
    ///     Gets whether Create button is pressed or not.
    /// </summary>
    public bool Create { get; protected set; }

    /// <summary>
    ///     Gets whether Options button is pressed or not.
    /// </summary>
    public bool Options { get; protected set; }

    /// <summary>
    ///     Gets whether PS button is pressed or not.
    /// </summary>
    public bool PS { get; protected set; }

    /// <summary>
    ///     Gets whether Square button is pressed or not.
    /// </summary>
    public bool Square => _generic.Left;

    /// <summary>
    ///     Gets whether Triangle button is pressed or not.
    /// </summary>
    public bool Triangle => _generic.Top;

    /// <summary>
    ///     Gets whether Circle button is pressed or not.
    /// </summary>
    public bool Circle => _generic.Right;

    /// <summary>
    ///     Gets whether Cross button is pressed or not.
    /// </summary>
    public bool Cross => _generic.Bottom;

    /// <summary>
    ///     Gets the Left Thumb X axis value.
    /// </summary>
    public short LeftThumbX { get; set; } = 128;

    /// <summary>
    ///     Gets the Left Thumb Y axis value.
    /// </summary>
    public short LeftThumbY { get; set; } = 128;

    /// <summary>
    ///     Gets the Right Thumb X axis value.
    /// </summary>
    public short RightThumbX { get; set; } = 128;

    /// <summary>
    ///     Gets the Right Thumb Y axis value.
    /// </summary>
    public short RightThumbY { get; set; } = 128;

    /// <summary>
    ///     Gets the first finger touch information.
    /// </summary>
    public TrackPadTouch TrackPadTouch1 { get; } = new();

    /// <summary>
    ///     Gets the second finger touch information.
    /// </summary>
    public TrackPadTouch TrackPadTouch2 { get; } = new();

    public byte TouchPacketCounter { get; protected set; }

    /// <summary>
    ///     Gets whether only one finger is currently touching.
    /// </summary>
    public bool TouchOneFingerActive => Touch1 || Touch2;

    /// <summary>
    ///     Gets whether two fingers are currently touching.
    /// </summary>
    public bool TouchTwoFingersActive => Touch1 && Touch2;

    /// <summary>
    ///     Gets the microphone mute button state.
    /// </summary>
    public bool Mute { get; protected set; }

    /// <summary>
    ///     First (one finger) touch is registered.
    /// </summary>
    public bool Touch1 { get; protected set; }

    /// <summary>
    ///     Second (two fingers) touch is registered.
    /// </summary>
    public bool Touch2 { get; protected set; }

    /// <summary>
    ///     Touch is registered in the left half of the pad.
    /// </summary>
    public bool TouchIsOnLeftSide { get; protected set; }

    /// <summary>
    ///     Touch is registered in the right half of the pad.
    /// </summary>
    public bool TouchIsOnRightSide { get; protected set; }

    /// <summary>
    ///     Set when the entire touchpad (button) is pressed.
    /// </summary>
    public bool TouchClick { get; protected set; }

    /// <summary>
    ///     Gets idle state. True whenever the state equals the resting, default values (e.g. the user doesn't interact with
    ///     the device).
    /// </summary>
    [IgnoreEquality]
    public virtual bool IsIdle
    {
        get
        {
            if (AreButtonsPressed)
            {
                return false;
            }

            if (LeftTrigger != 0 || RightTrigger != 0)
            {
                return false;
            }

            const int slop = 64;
            if (LeftThumbX is <= 127 - slop or >= 128 + slop || LeftThumbY is <= 127 - slop or >= 128 + slop)
            {
                return false;
            }

            if (RightThumbX is <= 127 - slop or >= 128 + slop || RightThumbY is <= 127 - slop or >= 128 + slop)
            {
                return false;
            }

            if (Touch1 || Touch2)
            {
                return false;
            }

            return true;
        }
    }

    /// <summary>
    ///     Gets whether any digital button is currently pressed.
    /// </summary>
    [IgnoreEquality]
    public virtual bool AreButtonsPressed
    {
        get
        {
            if (Square || Cross || Circle || Triangle)
            {
                return false;
            }

            if (DPad != DPadDirection.Default)
            {
                return false;
            }

            if (LeftShoulder || RightShoulder || LeftThumb || RightThumb || Create || Options || PS)
            {
                return false;
            }

            if (LeftTriggerButton || RightTriggerButton)
            {
                return false;
            }

            if (TouchClick)
            {
                return false;
            }

            return true;
        }
    }

    /// <summary>
    ///     Gets the battery state. Only set if <see cref="BatteryState" /> is in the appropriate state.
    /// </summary>
    public byte? BatteryPercentage { get; protected set; }
}