using System.Runtime.InteropServices;

namespace Nefarius.Utilities.HID.Util;

public static class StructHelpers
{
    public static void ToBytes<T>(this ref T value, byte[] buffer)
        where T : struct
    {
        MemoryMarshal.Write(buffer, ref value);
    }

#if NETCOREAPP3_0_OR_GREATER
    public static T ToStruct<T>(this ReadOnlySpan<byte> data)
        where T : struct
    {
        return MemoryMarshal.AsRef<T>(data);
    }

    public static T ToStruct<T>(this byte[] data)
        where T : struct
    {
        return ToStruct<T>((ReadOnlySpan<byte>)data);
    }
#endif
}