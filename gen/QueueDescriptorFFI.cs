using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct QueueDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public StringViewFFI Label = new();

    public QueueDescriptorFFI() { }

}
