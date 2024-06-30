using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct UncapturedErrorCallbackInfo2FFI
{
    public ChainedStruct* NextInChain;
    public delegate* unmanaged[Cdecl]<DeviceHandle*, ErrorType, byte*, void*, void*, void> Callback;
    public void* Userdata1;
    public void* Userdata2;

    public UncapturedErrorCallbackInfo2FFI()
    {
    }


    public UncapturedErrorCallbackInfo2FFI(ChainedStruct* nextInChain = default, delegate* unmanaged[Cdecl]<DeviceHandle*, ErrorType, byte*, void*, void*, void> callback = default, void* userdata1 = default, void* userdata2 = default)
    {
        this.NextInChain = nextInChain;
        this.Callback = callback;
        this.Userdata1 = userdata1;
        this.Userdata2 = userdata2;
    }


    public UncapturedErrorCallbackInfo2FFI(delegate* unmanaged[Cdecl]<DeviceHandle*, ErrorType, byte*, void*, void*, void> callback = default, void* userdata1 = default, void* userdata2 = default)
    {
        this.Callback = callback;
        this.Userdata1 = userdata1;
        this.Userdata2 = userdata2;
    }

}
