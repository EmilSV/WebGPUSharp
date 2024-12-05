using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct BufferHostMappedPointerFFI
{
    public ChainedStruct Chain;
    public void* Pointer;
    public delegate* unmanaged[Cdecl]<void*, void> DisposeCallback;
    public void* Userdata;

    public BufferHostMappedPointerFFI() { }

}
