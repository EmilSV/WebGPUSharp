using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct StringViewFFI
{
    public byte* Data;
    public nuint Length;

    public StringViewFFI()
    {
    }


    public StringViewFFI(byte* data = default, nuint length = default)
    {
        this.Data = data;
        this.Length = length;
    }

}
