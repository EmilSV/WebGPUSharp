using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Descriptor for use with <see cref="DeviceHandle.CreateShaderModule" />.
/// </summary>
public unsafe partial struct ShaderModuleDescriptorFFI
{
    public ChainedStruct* NextInChain;
    /// <summary>
    /// The debug label of the shader module.
    /// </summary>
    public StringViewFFI Label = StringViewFFI.NullValue;

    public ShaderModuleDescriptorFFI() { }

}
