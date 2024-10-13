namespace WebGpuSharp.FFI;

public unsafe partial struct StringViewFFI
{
    public unsafe StringViewFFI(byte* data, nuint length)
    {
        Data = data;
        Length = length;
    }

    public unsafe StringViewFFI(byte* data, int length)
    {
        Data = data;
        Length = (nuint)length;
    }
}
