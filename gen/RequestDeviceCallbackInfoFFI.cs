using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct RequestDeviceCallbackInfoFFI
{
    public ChainedStruct* NextInChain;
    public CallbackMode Mode;
    public delegate* unmanaged[Cdecl]<RequestDeviceStatus, DeviceHandle, byte*, void*, void> Callback;
    public void* Userdata;

    public RequestDeviceCallbackInfoFFI()
    {
    }


    public RequestDeviceCallbackInfoFFI(ChainedStruct* nextInChain = default, CallbackMode mode = default, delegate* unmanaged[Cdecl]<RequestDeviceStatus, DeviceHandle, byte*, void*, void> callback = default, void* userdata = default)
    {
        this.NextInChain = nextInChain;
        this.Mode = mode;
        this.Callback = callback;
        this.Userdata = userdata;
    }


    public RequestDeviceCallbackInfoFFI(CallbackMode mode = default, delegate* unmanaged[Cdecl]<RequestDeviceStatus, DeviceHandle, byte*, void*, void> callback = default, void* userdata = default)
    {
        this.Mode = mode;
        this.Callback = callback;
        this.Userdata = userdata;
    }

}
