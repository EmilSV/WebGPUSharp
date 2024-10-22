using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct DawnStoreCacheDataFunctionFFI
{
    public delegate* unmanaged[Cdecl]<void*, nuint, void*, nuint, void*, void> Value;

    public DawnStoreCacheDataFunctionFFI() { }

}
