using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Nefarius.Utilities.HID.Util;

/// <summary>
///     Structure conversion utilities.
/// </summary>
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public static class StructHelpers
{
    /// <summary>
    ///     Writes a given type T to a provided byte array.
    /// </summary>
    /// <param name="value">The value to read.</param>
    /// <param name="buffer">The byte array to wrote to.</param>
    /// <typeparam name="T">The type to read.</typeparam>
    public static void ToBytes<T>(this ref T value, byte[] buffer)
        where T : struct
    {
        MemoryMarshal.Write(buffer, ref value);
    }

#if NETCOREAPP3_0_OR_GREATER
    /// <summary>
    ///     Re-interprets a span of bytes as a reference to structure of type T.
    ///     The type may not contain pointers or references. This is checked at runtime in order to preserve type safety.
    /// </summary>
    /// <remarks>
    ///     Supported only for platforms that support misaligned memory access or when the memory block is aligned by other
    ///     means.
    /// </remarks>
    public static T ToStruct<T>(this ReadOnlySpan<byte> data)
        where T : struct
    {
        return MemoryMarshal.AsRef<T>(data);
    }

    /// <summary>
    ///     Re-interprets a span of bytes as a reference to structure of type T.
    ///     The type may not contain pointers or references. This is checked at runtime in order to preserve type safety.
    /// </summary>
    /// <remarks>
    ///     Supported only for platforms that support misaligned memory access or when the memory block is aligned by other
    ///     means.
    /// </remarks>
    public static T ToStruct<T>(this byte[] data)
        where T : struct
    {
        return ToStruct<T>((ReadOnlySpan<byte>)data);
    }
#endif
}