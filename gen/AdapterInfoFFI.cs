using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct AdapterInfoFFI
{
    public ChainedStructOut* NextInChain;
    public StringViewFFI Vendor = new();
    public StringViewFFI Architecture = new();
    public StringViewFFI Device = new();
    public StringViewFFI Description = new();
    public BackendType BackendType;
    public AdapterType AdapterType;
    public uint VendorID;
    public uint DeviceID;
    public WebGPUBool CompatibilityMode = new();

    public AdapterInfoFFI() { }

}
