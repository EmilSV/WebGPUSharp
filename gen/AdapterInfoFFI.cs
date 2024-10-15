using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct AdapterInfoFFI
{
    public ChainedStructOut* NextInChain;
    public StringViewFFI Vendor;
    public StringViewFFI Architecture;
    public StringViewFFI Device;
    public StringViewFFI Description;
    public BackendType BackendType;
    public AdapterType AdapterType;
    public uint VendorID;
    public uint DeviceID;

    public AdapterInfoFFI()
    {
    }

}
