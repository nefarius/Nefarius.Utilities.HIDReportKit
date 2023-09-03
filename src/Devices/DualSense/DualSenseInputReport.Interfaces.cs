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
    
    #region IHasDirectionalPad
    
    [IgnoreEquality]
    bool IHasDirectionalPad.Up => DPad is DPadDirection.North or DPadDirection.NorthEast or DPadDirection.NorthWest;

    [IgnoreEquality]
    bool IHasDirectionalPad.Right => DPad is DPadDirection.East or DPadDirection.NorthEast or DPadDirection.SouthEast;
    
    [IgnoreEquality]
    bool IHasDirectionalPad.Down => DPad is DPadDirection.South or DPadDirection.SouthEast or DPadDirection.SouthWest;

    [IgnoreEquality]
    bool IHasDirectionalPad.Left => DPad is DPadDirection.West or DPadDirection.NorthWest or DPadDirection.SouthWest;

    DPadPointOfView IHasDirectionalPad.AsPOV()
    {
        return DPad switch
        {
            DPadDirection.Default => DPadPointOfView.Default,
            DPadDirection.NorthWest => DPadPointOfView.NorthWest,
            DPadDirection.West => DPadPointOfView.West,
            DPadDirection.SouthWest => DPadPointOfView.SouthWest,
            DPadDirection.South => DPadPointOfView.South,
            DPadDirection.SouthEast => DPadPointOfView.SouthEast,
            DPadDirection.East => DPadPointOfView.East,
            DPadDirection.NorthEast => DPadPointOfView.NorthEast,
            DPadDirection.North => DPadPointOfView.North,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
    
    #endregion
    
    #region IHasThumbButtons

    [IgnoreEquality]
    bool IHasThumbButtons.L3 => _generic.L3;

    [IgnoreEquality]
    bool IHasThumbButtons.R3 => _generic.R3;

    #endregion
}