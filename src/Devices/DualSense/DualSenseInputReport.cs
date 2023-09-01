using System.Diagnostics.CodeAnalysis;

// ReSharper disable once RedundantUsingDirective
using System.Runtime.InteropServices;

using Nefarius.Utilities.HID.Devices.DualSense.In;
using Nefarius.Utilities.HID.Devices.Generic;
using Nefarius.Utilities.HID.Util;

namespace Nefarius.Utilities.HID.Devices.DualSense;

/// <summary>
///     Touchpad state details.
/// </summary>
[SuppressMessage("ReSharper", "NotAccessedField.Global")]
[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
public sealed class TrackPadTouch
{
    public bool IsActive { get; internal set; }

    public byte Id { get; internal set; }

    public short X { get; internal set; }

    public short Y { get; internal set; }

    public byte RawTrackingNum { get; internal set; }
}

/// <summary>
///     Represents a Sony™ DualSense™ compatible input report.
/// </summary>
[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public class DualSenseInputReport : IParsableFor<InputReportData>
{
    private readonly GenericInputReport _generic = new();
    
    /// <summary>
    ///     Gets the expected <see cref="AxisRangeType"/> of the thumb axes.
    /// </summary>
    public AxisRangeType AxisScaleInputType => AxisRangeType.Byte;

    /// <summary>
    ///     Gets the battery state.
    /// </summary>
    public byte? Battery { get; protected set; }

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
    ///     Gets whether Share button is pressed or not.
    /// </summary>
    public bool Share { get; protected set; }

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

    public TrackPadTouch TrackPadTouch1 { get; } = new();

    public TrackPadTouch TrackPadTouch2 { get; } = new();

    public byte TouchPacketCounter { get; protected set; }

    public bool TouchOneFingerActive => Touch1 || Touch2;

    public bool TouchTwoFingersActive => Touch1 && Touch2;

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
    public virtual bool IsIdle
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

            if (LeftShoulder || RightShoulder || LeftThumb || RightThumb || Share || Options || PS)
            {
                return false;
            }

            if (LeftTriggerButton || RightTriggerButton)
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

            if (Touch1 || Touch2 || TouchClick)
            {
                return false;
            }

            return true;
        }
    }

    /// <inheritdoc />
    public void Parse(ref InputReportData report)
    {
        SticksAndTriggers sticksAndTriggers = report.SticksAndTriggers;
        LeftThumbX = sticksAndTriggers.LeftStickX;
        LeftThumbY = sticksAndTriggers.LeftStickY;
        RightThumbX = sticksAndTriggers.RightStickX;
        RightThumbY = sticksAndTriggers.RightStickY;
        LeftTrigger = sticksAndTriggers.TriggerLeft;
        RightTrigger = sticksAndTriggers.TriggerRight;

        DualSenseButtons1 buttons1 = report.Buttons.Buttons1;
        _generic.Top = buttons1.HasFlag(DualSenseButtons1.Triangle);
        _generic.Right = buttons1.HasFlag(DualSenseButtons1.Circle);
        _generic.Bottom = buttons1.HasFlag(DualSenseButtons1.Cross);
        _generic.Left = buttons1.HasFlag(DualSenseButtons1.Square);

        _generic.DPad = report.Buttons.DPad;

        DualSenseButtons2 buttons2 = report.Buttons.Buttons2;
        _generic.L3 = buttons2.HasFlag(DualSenseButtons2.L3);
        _generic.R3 = buttons2.HasFlag(DualSenseButtons2.R3);
        Options = buttons2.HasFlag(DualSenseButtons2.Options);
        Share = buttons2.HasFlag(DualSenseButtons2.Create);
        RightTriggerButton = buttons2.HasFlag(DualSenseButtons2.R2);
        LeftTriggerButton = buttons2.HasFlag(DualSenseButtons2.L2);
        _generic.R1 = buttons2.HasFlag(DualSenseButtons2.R1);
        _generic.L1 = buttons2.HasFlag(DualSenseButtons2.L1);

        DualSenseButtons3 buttons3 = report.Buttons.Buttons3;
        PS = buttons3.HasFlag(DualSenseButtons3.Home);
        TouchClick = buttons3.HasFlag(DualSenseButtons3.Pad);
        Mute = buttons3.HasFlag(DualSenseButtons3.Mute);

        TouchFingerData finger1 = report.TouchData.Finger1;
        TrackPadTouch1.RawTrackingNum = finger1.RawTrackingNumber;
        TrackPadTouch1.Id = finger1.Index;
        TrackPadTouch1.IsActive = finger1.IsActive;
        TrackPadTouch1.X = finger1.FingerX;
        TrackPadTouch1.Y = finger1.FingerY;

        TouchFingerData finger2 = report.TouchData.Finger2;
        TrackPadTouch2.RawTrackingNum = finger2.RawTrackingNumber;
        TrackPadTouch2.Id = finger2.Index;
        TrackPadTouch2.IsActive = finger2.IsActive;
        TrackPadTouch2.X = finger2.FingerX;
        TrackPadTouch2.Y = finger2.FingerY;

        TouchData touchData = report.TouchData;
        TouchPacketCounter = touchData.Timestamp;
        Touch1 = finger1.IsActive;
        Touch2 = finger2.IsActive;
        TouchIsOnLeftSide = touchData.IsTouchOnLeftSide;
        TouchIsOnRightSide = touchData.IsTouchOnRightSide;
    }

    /// <inheritdoc />
    public void Parse(byte[] report)
    {
#if NETCOREAPP3_0_OR_GREATER
        Parse((ReadOnlySpan<byte>)report);
#else
        // fallback for older frameworks
        GCHandle handle = GCHandle.Alloc(report, GCHandleType.Pinned);
        InputReportData data =
            (InputReportData)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(InputReportData));
        Parse(ref data);
        handle.Free();
#endif
    }

#if NETCOREAPP3_0_OR_GREATER
    /// <inheritdoc />
    public void Parse(ReadOnlySpan<byte> report)
    {
        InputReportData data = report.AsStruct<InputReportData>();
        Parse(ref data);
    }

    /// <inheritdoc />
    public void Parse(Memory<byte> report)
    {
        Parse(report.Span);
    }
#endif
}