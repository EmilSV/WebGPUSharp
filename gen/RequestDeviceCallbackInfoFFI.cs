using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct RequestDeviceCallbackInfoFFI
{
    public ChainedStruct* NextInChain;
    public CallbackMode Mode;
    public delegate* unmanaged[Cdecl]<RequestDeviceStatus, DeviceHandle, StringViewFFI, void*, void> Callback;
    public void* Userdata;

    public RequestDeviceCallbackInfoFFI() { }

}
