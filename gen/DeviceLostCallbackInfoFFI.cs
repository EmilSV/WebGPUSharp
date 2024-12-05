using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct DeviceLostCallbackInfoFFI
{
    public ChainedStruct* NextInChain;
    public CallbackMode Mode;
    public delegate* unmanaged[Cdecl]<DeviceHandle*, DeviceLostReason, StringViewFFI, void*, void> Callback;
    public void* Userdata;

    public DeviceLostCallbackInfoFFI() { }

}
