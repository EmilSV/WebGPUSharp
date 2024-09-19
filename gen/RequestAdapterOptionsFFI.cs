using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct RequestAdapterOptionsFFI
{
    public ChainedStruct* NextInChain;
    public SurfaceHandle CompatibleSurface;
    public PowerPreference PowerPreference;
    public BackendType BackendType;
    public WebGPUBool ForceFallbackAdapter;

    public RequestAdapterOptionsFFI()
    {
    }


    public RequestAdapterOptionsFFI(ChainedStruct* nextInChain = default, SurfaceHandle compatibleSurface = default, PowerPreference powerPreference = default, BackendType backendType = default, WebGPUBool forceFallbackAdapter = default)
    {
        this.NextInChain = nextInChain;
        this.CompatibleSurface = compatibleSurface;
        this.PowerPreference = powerPreference;
        this.BackendType = backendType;
        this.ForceFallbackAdapter = forceFallbackAdapter;
    }


    public RequestAdapterOptionsFFI(SurfaceHandle compatibleSurface = default, PowerPreference powerPreference = default, BackendType backendType = default, WebGPUBool forceFallbackAdapter = default)
    {
        this.CompatibleSurface = compatibleSurface;
        this.PowerPreference = powerPreference;
        this.BackendType = backendType;
        this.ForceFallbackAdapter = forceFallbackAdapter;
    }

}
