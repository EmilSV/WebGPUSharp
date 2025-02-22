using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public unsafe partial struct InstanceDescriptor
{
    public ChainedStruct* NextInChain;
    public InstanceCapabilities Capabilities = new();
    public InstanceCapabilities Features = new();

    public InstanceDescriptor() { }

}
