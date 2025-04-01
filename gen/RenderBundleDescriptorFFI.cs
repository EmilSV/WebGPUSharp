using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Describes a render bundle.
/// </summary>
public unsafe partial struct RenderBundleDescriptorFFI
{
    public ChainedStruct* NextInChain;
    /// <summary>
    /// Debug label for the render bundle.
    /// </summary>
    public StringViewFFI Label = StringViewFFI.NullValue;

    public RenderBundleDescriptorFFI() { }

}
