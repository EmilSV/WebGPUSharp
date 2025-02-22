using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct RequestAdapterOptionsFFI
{
    public ChainedStruct* NextInChain;
    public SurfaceHandle CompatibleSurface;
    public FeatureLevel FeatureLevel;
    public PowerPreference PowerPreference;
    public BackendType BackendType;
    public WebGPUBool ForceFallbackAdapter = false;

    public RequestAdapterOptionsFFI() { }

}
