using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct UncapturedErrorCallbackInfo2FFI
{
    public ChainedStruct* NextInChain;
    public delegate* unmanaged[Cdecl]<DeviceHandle*, ErrorType, StringViewFFI, void*, void*, void> Callback;
    public void* Userdata1;
    public void* Userdata2;

    public UncapturedErrorCallbackInfo2FFI() { }

}
