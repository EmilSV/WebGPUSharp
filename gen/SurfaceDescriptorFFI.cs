using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Describes a Surface.
/// </summary>
public unsafe partial struct SurfaceDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public StringViewFFI Label = StringViewFFI.NullValue;

    public SurfaceDescriptorFFI() { }

}
