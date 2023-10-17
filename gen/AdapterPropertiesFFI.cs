using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
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
	public WGPUBool CompatibilityMode;

	public AdapterPropertiesFFI()
	{
		this.NextInChain = default;
		this.VendorID = default;
		this.VendorName = default;
		this.Architecture = default;
		this.DeviceID = default;
		this.Name = default;
		this.DriverDescription = default;
		this.AdapterType = default;
		this.BackendType = default;
		this.CompatibilityMode = default;
	}

	public AdapterPropertiesFFI(ChainedStructOut* nextInChain = default, uint vendorID = default, byte* vendorName = default, byte* architecture = default, uint deviceID = default, byte* name = default, byte* driverDescription = default, AdapterType adapterType = default, BackendType backendType = default, WGPUBool compatibilityMode = default)
	{
		this.NextInChain = nextInChain;
		this.VendorID = vendorID;
		this.VendorName = vendorName;
		this.Architecture = architecture;
		this.DeviceID = deviceID;
		this.Name = name;
		this.DriverDescription = driverDescription;
		this.AdapterType = adapterType;
		this.BackendType = backendType;
		this.CompatibilityMode = compatibilityMode;
	}
}

