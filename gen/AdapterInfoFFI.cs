using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct AdapterInfoFFI
{
    public ChainedStructOut* NextInChain;
    public StringViewFFI Vendor = StringViewFFI.NullValue;
    public StringViewFFI Architecture = StringViewFFI.NullValue;
    public StringViewFFI Device = StringViewFFI.NullValue;
    public StringViewFFI Description = StringViewFFI.NullValue;
    public BackendType BackendType;
    public AdapterType AdapterType;
    public uint VendorID;
    public uint DeviceID;
    public WebGPUBool CompatibilityMode = new();

    public AdapterInfoFFI() { }

}
