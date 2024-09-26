using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct BindGroupEntryFFI
{
    public ChainedStruct* NextInChain;
    /// <summary>
    /// A unique identifier for a resource binding within the <see cref="FFI.BindGroup"/>, corresponding to a <see cref="BindGroupLayoutEntry.Binding">GPUBindGroupLayoutEntry.binding</see>and a@bindingattribute in the <see cref="FFI.ShaderModule"/>.
    /// </summary>
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
