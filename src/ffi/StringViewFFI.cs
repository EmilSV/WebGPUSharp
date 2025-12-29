using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;


public unsafe partial struct StringViewFFI
{
    private StringViewFFI(byte* data, nuint length)
    {
        Data = data;
        Length = length;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly ReadOnlySpan<byte> AsSpan()
    {
        if (Data == null && Length == STRLEN)
        {
            return [];
        }

        if (Length == WebGPU_FFI.STRLEN)
        {
            return MemoryMarshal.CreateReadOnlySpanFromNullTerminated(Data);
        }

        return new(Data, (int)Length);
    }

    public static readonly nuint STRLEN = WebGPU_FFI.STRLEN;
    public readonly static StringViewFFI EmptyString = new(null, 0);

    public static StringViewFFI CreateExplicitlySized(byte* data, int length)
    {
        return CreateExplicitlySized(data, (nuint)length);
    }

    public static StringViewFFI CreateExplicitlySized(byte* data, nuint length)
    {
        if (data == null)
        {
            return NullValue;
        }

        return new(data, length);
    }

    public static StringViewFFI CreateNullTerminated(byte* data)
    {
        return new(data, STRLEN);
    }
}