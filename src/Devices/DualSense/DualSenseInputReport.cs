// ReSharper disable once RedundantUsingDirective

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

using Generator.Equals;

using Nefarius.Utilities.HID.Devices.DualSense.In;
using Nefarius.Utilities.HID.Devices.Generic;
using Nefarius.Utilities.HID.Devices.Generic.Components;

namespace Nefarius.Utilities.HID.Devices.DualSense;

/// <summary>
///     Touchpad state details.
/// </summary>
[SuppressMessage("ReSharper", "NotAccessedField.Global")]
[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
[Equatable]
public sealed partial class TrackPadTouch
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
[SuppressMessage("ReSharper", "MemberCanBeProtected.Global")]
[Equatable]
public partial class DualSenseInputReport : ReportParserBase<InputReportData>,
    IHasFaceButtons,
    IHasShoulderButtons,
    IHasTriggerButtons,
    IHasTriggerAxes,
    IHasBattery,
    IHasDirectionalPad,
    IHasThumbButtons,
    IHasThumbAxes
{
    private readonly GenericInputReport _generic = new();

    internal DualSenseInputReport() { }

    /// <inheritdoc />
    public override void Parse(ref InputReportData report)
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

        PowerStateData powerData = report.PowerStateData;
        BatteryState = powerData.BatteryState;
        switch (BatteryState)
        {
            case PowerState.Discharging:
            case PowerState.Charging:
                BatteryPercentage = (byte)powerData.BatteryPercentage;
                break;
            case PowerState.Complete:
                BatteryPercentage = 100;
                break;
            default:
                BatteryPercentage = null;
                break;
        }
    }
}