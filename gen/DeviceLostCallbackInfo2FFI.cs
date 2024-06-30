using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct DeviceLostCallbackInfo2FFI
{
    public ChainedStruct* NextInChain;
    public CallbackMode Mode;
    public delegate* unmanaged[Cdecl]<DeviceHandle*, DeviceLostReason, byte*, void*, void*, void> Callback;
    public void* Userdata1;
    public void* Userdata2;

    public DeviceLostCallbackInfo2FFI()
    {
    }


    public DeviceLostCallbackInfo2FFI(ChainedStruct* nextInChain = default, CallbackMode mode = default, delegate* unmanaged[Cdecl]<DeviceHandle*, DeviceLostReason, byte*, void*, void*, void> callback = default, void* userdata1 = default, void* userdata2 = default)
    {
        this.NextInChain = nextInChain;
        this.Mode = mode;
        this.Callback = callback;
        this.Userdata1 = userdata1;
        this.Userdata2 = userdata2;
    }


    public DeviceLostCallbackInfo2FFI(CallbackMode mode = default, delegate* unmanaged[Cdecl]<DeviceHandle*, DeviceLostReason, byte*, void*, void*, void> callback = default, void* userdata1 = default, void* userdata2 = default)
    {
        this.Mode = mode;
        this.Callback = callback;
        this.Userdata1 = userdata1;
        this.Userdata2 = userdata2;
    }

}
