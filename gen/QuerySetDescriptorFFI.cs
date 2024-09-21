using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct QuerySetDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public byte* Label;
    public required QueryType Type;
    public required uint Count;

    public QuerySetDescriptorFFI()
    {
    }

}
