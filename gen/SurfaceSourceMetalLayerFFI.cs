using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// A surface source for a Metal layer.
/// </summary>
public unsafe partial struct SurfaceSourceMetalLayerFFI
{
    /// <summary>
    /// The chain link for struct chaining.
    /// </summary>
    public ChainedStruct Chain;
    /// <summary>
    /// The Metal layer.
    /// </summary>
    public void* Layer;

    public SurfaceSourceMetalLayerFFI() { }

}
