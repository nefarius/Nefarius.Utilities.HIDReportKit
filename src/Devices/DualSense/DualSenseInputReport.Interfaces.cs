using System.Diagnostics.CodeAnalysis;

using Nefarius.Utilities.HID.Devices.DualSense.In;
using Nefarius.Utilities.HID.Devices.Generic.Components;

namespace Nefarius.Utilities.HID.Devices.DualSense;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
[SuppressMessage("ReSharper", "MemberCanBeProtected.Global")]
public partial class DualSenseInputReport
{
    #region IHasBattery

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

    bool IHasFaceButtons.Top => _generic.Top;

    bool IHasFaceButtons.Bottom => _generic.Bottom;

    bool IHasFaceButtons.Left => _generic.Left;

    bool IHasFaceButtons.Right => _generic.Right;

    #endregion

    #region IHasShoulderButtons

    bool IHasShoulderButtons.L1 => _generic.L1;

    bool IHasShoulderButtons.R1 => _generic.R1;

    #endregion

    #region IHasTriggerButtons

    bool IHasTriggerButtons.L2 => LeftTriggerButton;

    bool IHasTriggerButtons.R2 => RightTriggerButton;

    #endregion

    #region IHasTriggerAxes

    int IHasTriggerAxes.L2 => LeftTrigger;

    int IHasTriggerAxes.R2 => RightTrigger;

    #endregion
    
    #region IHasDirectionalPad
    
    bool IHasDirectionalPad.Up => DPad is DPadDirection.North or DPadDirection.NorthEast or DPadDirection.NorthWest;

    bool IHasDirectionalPad.Right => DPad is DPadDirection.East or DPadDirection.NorthEast or DPadDirection.SouthEast;
    
    bool IHasDirectionalPad.Down => DPad is DPadDirection.South or DPadDirection.SouthEast or DPadDirection.SouthWest;

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

    bool IHasThumbButtons.L3 => _generic.L3;

    bool IHasThumbButtons.R3 => _generic.R3;

    #endregion
    
    #region IHasSpecialButtons

    bool IHasSpecialButtons.Select => Create;

    bool IHasSpecialButtons.Home => PS;

    bool IHasSpecialButtons.Start => Options;

    #endregion
}