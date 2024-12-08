namespace WebGpuSharp.FFI;


public unsafe partial struct StringViewFFI
{
    private StringViewFFI(byte* data, nuint length)
    {
        Data = data;
        Length = length;
    }

    public ReadOnlySpan<byte> AsSpan()
    {
        return new(Data, (int)Length);
    }

    public static readonly nuint STRLEN = WebGPU_FFI.STRLEN;
    public readonly static StringViewFFI NullValue = new(null, STRLEN);
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