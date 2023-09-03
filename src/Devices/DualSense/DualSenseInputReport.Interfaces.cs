using System.Diagnostics.CodeAnalysis;

using Generator.Equals;

using Nefarius.Utilities.HID.Devices.DualSense.In;
using Nefarius.Utilities.HID.Devices.Generic.Components;

namespace Nefarius.Utilities.HID.Devices.DualSense;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
[SuppressMessage("ReSharper", "MemberCanBeProtected.Global")]
public partial class DualSenseInputReport
{
    #region IHasBattery

    [IgnoreEquality]
    BatteryState? IHasBattery.BatteryState =>
        BatteryState switch
        {
            PowerState.Charging => Devices.BatteryState.Charging,
            PowerState.Discharging => Devices.BatteryState.Discharging,
            PowerState.Complete => Devices.BatteryState.Complete,
            _ => Devices.BatteryState.Unknown
        };

    #endregion

    #region IHasFaceButtons

    [IgnoreEquality]
    bool IHasFaceButtons.Top => _generic.Top;

    [IgnoreEquality]
    bool IHasFaceButtons.Bottom => _generic.Bottom;

    [IgnoreEquality]
    bool IHasFaceButtons.Left => _generic.Left;

    [IgnoreEquality]
    bool IHasFaceButtons.Right => _generic.Right;

    #endregion

    #region IHasShoulderButtons

    [IgnoreEquality]
    bool IHasShoulderButtons.L1 => _generic.L1;

    [IgnoreEquality]
    bool IHasShoulderButtons.R1 => _generic.R1;

    #endregion

    #region IHasTriggerButtons

    [IgnoreEquality]
    bool IHasTriggerButtons.L2 => LeftTriggerButton;

    [IgnoreEquality]
    bool IHasTriggerButtons.R2 => RightTriggerButton;

    #endregion

    #region IHasTriggerAxes

    [IgnoreEquality]
    int IHasTriggerAxes.L2 => LeftTrigger;

    [IgnoreEquality]
    int IHasTriggerAxes.R2 => RightTrigger;

    #endregion
}