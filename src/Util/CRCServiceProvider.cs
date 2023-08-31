using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;

namespace Soft160.Data.Cryptography;

/// <inheritdoc />
[SuppressMessage("ReSharper", "InconsistentNaming")]
public class CRCServiceProvider : HashAlgorithm
{
    private uint seed;

    public CRCServiceProvider()
    {
        seed = 0;
    }

    public override void Initialize()
    {
        seed = 0;
        HashSizeValue = 32;
    }

    protected override void HashCore(byte[] array, int ibStart, int cbSize)
    {
        seed = CRC.Crc32(array, ibStart, cbSize, seed);
    }

    protected override byte[] HashFinal()
    {
        byte[] bytes = BitConverter.GetBytes(seed);
        if (BitConverter.IsLittleEndian)
        {
            Array.Reverse(bytes);
        }

        return bytes;
    }
}