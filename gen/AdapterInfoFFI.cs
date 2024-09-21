using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct AdapterInfoFFI
{
    public ChainedStructOut* NextInChain;
    public byte* Vendor;
    public byte* Architecture;
    public byte* Device;
    public byte* Description;
    public BackendType BackendType;
    public AdapterType AdapterType;
    public uint VendorID;
    public uint DeviceID;

    public AdapterInfoFFI()
    {
    }

}
