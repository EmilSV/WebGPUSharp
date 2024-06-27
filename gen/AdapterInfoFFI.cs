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
    public WebGPUBool CompatibilityMode;

    public AdapterInfoFFI()
    {
    }


    public AdapterInfoFFI(ChainedStructOut* nextInChain = default, byte* vendor = default, byte* architecture = default, byte* device = default, byte* description = default, BackendType backendType = default, AdapterType adapterType = default, uint vendorID = default, uint deviceID = default, WebGPUBool compatibilityMode = default)
    {
        this.NextInChain = nextInChain;
        this.Vendor = vendor;
        this.Architecture = architecture;
        this.Device = device;
        this.Description = description;
        this.BackendType = backendType;
        this.AdapterType = adapterType;
        this.VendorID = vendorID;
        this.DeviceID = deviceID;
        this.CompatibilityMode = compatibilityMode;
    }


    public AdapterInfoFFI(byte* vendor = default, byte* architecture = default, byte* device = default, byte* description = default, BackendType backendType = default, AdapterType adapterType = default, uint vendorID = default, uint deviceID = default, WebGPUBool compatibilityMode = default)
    {
        this.Vendor = vendor;
        this.Architecture = architecture;
        this.Device = device;
        this.Description = description;
        this.BackendType = backendType;
        this.AdapterType = adapterType;
        this.VendorID = vendorID;
        this.DeviceID = deviceID;
        this.CompatibilityMode = compatibilityMode;
    }

}
