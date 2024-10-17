namespace WebGpuSharp.FFI;


public unsafe partial struct StringViewFFI
{
    public StringViewFFI(byte* data, nuint length)
    {
        Data = data;
        Length = length;
    }

    public StringViewFFI(byte* data, int length)
    {
        Data = data;
        Length = (nuint)length;
    }

}