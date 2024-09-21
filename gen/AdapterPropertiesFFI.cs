using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct AdapterPropertiesFFI
{
    public ChainedStructOut* NextInChain;
    public uint VendorID;
    public byte* VendorName;
    public byte* Architecture;
    public uint DeviceID;
    public byte* Name;
    public byte* DriverDescription;
    public AdapterType AdapterType;
    public BackendType BackendType;

    public AdapterPropertiesFFI()
    {
    }

}
