using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// A DeviceLostCallbackInfoFFI is a callback info struct used to register a callback for when a device is lost.
/// </summary>
public unsafe partial struct DeviceLostCallbackInfoFFI
{
    public ChainedStruct* NextInChain;
    public CallbackMode Mode;
    public delegate* unmanaged[Cdecl]<DeviceHandle*, DeviceLostReason, StringViewFFI, void*, void*, void> Callback;
    public void* Userdata1;
    public void* Userdata2;

    public DeviceLostCallbackInfoFFI() { }

}
