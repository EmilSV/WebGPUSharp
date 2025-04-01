using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// The descriptor for the creation of an <see cref="Instance" />
/// </summary>
public unsafe partial struct InstanceDescriptor
{
    public ChainedStruct* NextInChain;
    public InstanceCapabilities Capabilities = new();
    /// <summary>
    /// Instance features to enable
    /// </summary>
    public InstanceCapabilities Features = new();

    public InstanceDescriptor() { }

}
