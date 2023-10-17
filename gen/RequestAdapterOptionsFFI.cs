using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct RequestAdapterOptionsFFI
{
	public ChainedStruct* NextInChain;
	public SurfaceHandle CompatibleSurface;
	public PowerPreference PowerPreference;
	public BackendType BackendType;
	public WGPUBool ForceFallbackAdapter;
	public WGPUBool CompatibilityMode;

	public RequestAdapterOptionsFFI()
	{
		this.NextInChain = default;
		this.CompatibleSurface = default;
		this.PowerPreference = default;
		this.BackendType = default;
		this.ForceFallbackAdapter = default;
		this.CompatibilityMode = default;
	}

	public RequestAdapterOptionsFFI(SurfaceHandle compatibleSurface = default, PowerPreference powerPreference = default, BackendType backendType = default, WGPUBool forceFallbackAdapter = default, WGPUBool compatibilityMode = default)
	{
		this.CompatibleSurface = compatibleSurface;
		this.PowerPreference = powerPreference;
		this.BackendType = backendType;
		this.ForceFallbackAdapter = forceFallbackAdapter;
		this.CompatibilityMode = compatibilityMode;
	}

	public RequestAdapterOptionsFFI(ChainedStruct* nextInChain = default, SurfaceHandle compatibleSurface = default, PowerPreference powerPreference = default, BackendType backendType = default, WGPUBool forceFallbackAdapter = default, WGPUBool compatibilityMode = default)
	{
		this.NextInChain = nextInChain;
		this.CompatibleSurface = compatibleSurface;
		this.PowerPreference = powerPreference;
		this.BackendType = backendType;
		this.ForceFallbackAdapter = forceFallbackAdapter;
		this.CompatibilityMode = compatibilityMode;
	}
}

