using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct DeviceLostCallbackInfoFFI
{
    public ChainedStruct* NextInChain;
    public CallbackMode Mode;
    public delegate* unmanaged[Cdecl]<DeviceHandle*, DeviceLostReason, byte*, void*, void> Callback;
    public void* Userdata;

    public DeviceLostCallbackInfoFFI()
    {
    }


    public DeviceLostCallbackInfoFFI(ChainedStruct* nextInChain = default, CallbackMode mode = default, delegate* unmanaged[Cdecl]<DeviceHandle*, DeviceLostReason, byte*, void*, void> callback = default, void* userdata = default)
    {
        this.NextInChain = nextInChain;
        this.Mode = mode;
        this.Callback = callback;
        this.Userdata = userdata;
    }


    public DeviceLostCallbackInfoFFI(CallbackMode mode = default, delegate* unmanaged[Cdecl]<DeviceHandle*, DeviceLostReason, byte*, void*, void> callback = default, void* userdata = default)
    {
        this.Mode = mode;
        this.Callback = callback;
        this.Userdata = userdata;
    }

}
