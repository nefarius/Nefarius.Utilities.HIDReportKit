using System.Diagnostics.CodeAnalysis;

namespace Nefarius.Utilities.HID.Util;

/// <summary>
///     Bit-wise manipulation utilities.
/// </summary>
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public static class BitHelpers
{
    private static readonly uint[] BitCountConversions =
    {
        0x00, 0x01, 0x03, 0x07, 0x0F, 0x1F, 0x3F, 0x7F, 0xFF, 0x1FF, 0x3FF, 0x7FF, 0xFFF, 0x1FFF, 0x3FFF, 0x7FFF,
        0xFFFF, 0x1FFFF, 0x3FFFF, 0x7FFFF, 0xFFFFF, 0x1FFFFF, 0x3FFFFF, 0x7FFFFF, 0xFFFFFF, 0x1FFFFFF, 0x3FFFFFF,
        0x7FFFFFF, 0xFFFFFFF, 0x1FFFFFFF, 0x3FFFFFFF, 0x7FFFFFFF, 0xFFFFFFFF
    };

    /// <summary>
    ///     Extracts one or more bits from a given value.
    /// </summary>
    /// <param name="value">The value to read from.</param>
    /// <param name="offset">The offset of the bit of interest.</param>
    /// <param name="count">The amount of bits to include.</param>
    /// <returns>The extracted value made from the given mask.</returns>
    public static byte GetBitsAsByte(this byte value, byte offset, byte count)
    {
        return (byte)((value >> offset) & BitCountConversions[count]);
    }

    /// <summary>
    ///     Extracts one or more bits from a given value.
    /// </summary>
    /// <param name="value">The value to read from.</param>
    /// <param name="offset">The offset of the bit of interest.</param>
    /// <param name="count">The amount of bits to include.</param>
    /// <returns>The extracted value made from the given mask.</returns>
    public static byte GetBitsAsByte(this ushort value, byte offset, byte count)
    {
        return (byte)((value >> offset) & BitCountConversions[count]);
    }

    /// <summary>
    ///     Extracts one or more bits from a given value.
    /// </summary>
    /// <param name="value">The value to read from.</param>
    /// <param name="offset">The offset of the bit of interest.</param>
    /// <param name="count">The amount of bits to include.</param>
    /// <returns>The extracted value made from the given mask.</returns>
    public static short GetBitsAsShort(this ushort value, byte offset, byte count)
    {
        return (short)((value >> offset) & BitCountConversions[count]);
    }

    /// <summary>
    ///     Extracts one or more bits from a given value.
    /// </summary>
    /// <param name="value">The value to read from.</param>
    /// <param name="offset">The offset of the bit of interest.</param>
    /// <param name="count">The amount of bits to include.</param>
    /// <returns>The extracted value made from the given mask.</returns>
    public static byte GetBitsAsByte(this uint value, byte offset, byte count)
    {
        return (byte)((value >> offset) & BitCountConversions[count]);
    }

    /// <summary>
    ///     Extracts one or more bits from a given value.
    /// </summary>
    /// <param name="value">The value to read from.</param>
    /// <param name="offset">The offset of the bit of interest.</param>
    /// <param name="count">The amount of bits to include.</param>
    /// <returns>The extracted value made from the given mask.</returns>
    public static short GetBitsAsShort(this uint value, byte offset, byte count)
    {
        return (short)((value >> offset) & BitCountConversions[count]);
    }

    /// <summary>
    ///     Extracts one or more bits from a given value.
    /// </summary>
    /// <param name="value">The value to read from.</param>
    /// <param name="offset">The offset of the bit of interest.</param>
    /// <param name="count">The amount of bits to include.</param>
    /// <returns>The extracted value made from the given mask.</returns>
    public static int GetBitsAsInt(this uint value, byte offset, byte count)
    {
        return (int)((value >> offset) & BitCountConversions[count]);
    }
}