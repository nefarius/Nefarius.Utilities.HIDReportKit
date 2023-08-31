using System.Diagnostics.CodeAnalysis;

namespace Nefarius.Utilities.HID.Util;

/// <summary>
///     Axis value conversion utilities.
/// </summary>
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public static class AxisScaling
{
    private const float RecipInputPosResolution = 1 / 127f;
    private const float RecipInputNegResolution = 1 / 128f;
    private const int OutputResolution = 32767 - -32768;
    
    /// <summary>
    ///     Scales a signed 16-bit value to fit into the range 0 to 255 where 127 equals 0 (centered).
    /// </summary>
    public static byte ScaleDown(short value, bool flip)
    {
        unchecked
        {
            byte newValue = (byte)((value + 0x8000) / 257);
            if (flip)
            {
                newValue = (byte)(byte.MaxValue - newValue);
            }

            return newValue;
        }
    }

    /// <summary>
    ///     Scales an unsigned 8-bit value up to the range between -32768 and 32767.
    /// </summary>
    public static short ScaleUp(int value, bool flip)
    {
        unchecked
        {
            value -= 0x80;
            float recipRun = value >= 0 ? RecipInputPosResolution : RecipInputNegResolution;

            float temp = value * recipRun;
            //if (Flip) temp = (temp - 0.5f) * -1.0f + 0.5f;
            if (flip)
            {
                temp = -temp;
            }

            temp = (temp + 1.0f) * 0.5f;

            return (short)((temp * OutputResolution) + -32768);
        }
    }
}