using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct BufferMapCallbackInfo2FFI
{
    public ChainedStruct* NextInChain;
    public CallbackMode Mode;
    public delegate* unmanaged[Cdecl]<MapAsyncStatus, byte*, void*, void*, void> Callback;
    public void* Userdata1;
    public void* Userdata2;

    public BufferMapCallbackInfo2FFI()
    {
    }

}
