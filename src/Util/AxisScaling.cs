namespace Nefarius.Utilities.HID.Util;

public static class AxisScaling
{
    private const float RecipInputPosResolution = 1 / 127f;
    private const float RecipInputNegResolution = 1 / 128f;
    private const int OutputResolution = 32767 - -32768;
    
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