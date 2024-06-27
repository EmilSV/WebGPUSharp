using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct BindGroupEntryFFI
{
    public ChainedStruct* NextInChain;
    public uint Binding;
    public BufferHandle Buffer;
    public ulong Offset;
    public ulong Size;
    public SamplerHandle Sampler;
    public TextureViewHandle TextureView;

    public BindGroupEntryFFI()
    {
    }


    public BindGroupEntryFFI(ChainedStruct* nextInChain = default, uint binding = default, BufferHandle buffer = default, ulong offset = default, ulong size = default, SamplerHandle sampler = default, TextureViewHandle textureView = default)
    {
        this.NextInChain = nextInChain;
        this.Binding = binding;
        this.Buffer = buffer;
        this.Offset = offset;
        this.Size = size;
        this.Sampler = sampler;
        this.TextureView = textureView;
    }


    public BindGroupEntryFFI(uint binding = default, BufferHandle buffer = default, ulong offset = default, ulong size = default, SamplerHandle sampler = default, TextureViewHandle textureView = default)
    {
        this.Binding = binding;
        this.Buffer = buffer;
        this.Offset = offset;
        this.Size = size;
        this.Sampler = sampler;
        this.TextureView = textureView;
    }

}
