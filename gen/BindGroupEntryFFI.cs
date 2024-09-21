using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct BindGroupEntryFFI
{
    public ChainedStruct* NextInChain;
    public required uint Binding;
    public BufferHandle Buffer;
    public ulong Offset;
    public ulong Size;
    public SamplerHandle Sampler;
    public TextureViewHandle TextureView;

    public BindGroupEntryFFI()
    {
    }

}
