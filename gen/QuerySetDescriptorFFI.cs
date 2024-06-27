using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct QuerySetDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public byte* Label;
    public QueryType Type;
    public uint Count;

    public QuerySetDescriptorFFI()
    {
    }


    public QuerySetDescriptorFFI(ChainedStruct* nextInChain = default, byte* label = default, QueryType type = default, uint count = default)
    {
        this.NextInChain = nextInChain;
        this.Label = label;
        this.Type = type;
        this.Count = count;
    }


    public QuerySetDescriptorFFI(byte* label = default, QueryType type = default, uint count = default)
    {
        this.Label = label;
        this.Type = type;
        this.Count = count;
    }

}
