using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct StringViewFFI
{
    public byte* Data;
    public nuint Length;
    public static readonly StringViewFFI NullValue = new() { Data = null, Length = WebGPU_FFI.STRLEN };

    public StringViewFFI() { }

}
