using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct DawnLoadCacheDataFunctionFFI
{
    public delegate* unmanaged[Cdecl]<void*, nuint, void*, nuint, void*, nuint> Value;

    public DawnLoadCacheDataFunctionFFI() { }

}
