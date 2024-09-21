using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct BufferMapCallbackInfoFFI
{
    public ChainedStruct* NextInChain;
    public CallbackMode Mode;
    public delegate* unmanaged[Cdecl]<BufferMapAsyncStatus, void*, void> Callback;
    public void* Userdata;

    public BufferMapCallbackInfoFFI()
    {
    }

}
