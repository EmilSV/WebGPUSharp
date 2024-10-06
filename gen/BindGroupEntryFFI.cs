using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct BindGroupEntryFFI
{
    public ChainedStruct* NextInChain;
    /// <summary>
    /// A unique identifier for a resource binding within the  <see cref="WebGpuSharp.BindGroup"/>, corresponding to a
    ///  <see cref="BindGroupLayoutEntry.Binding">GPUBindGroupLayoutEntry.binding</see> and a @binding
    /// attribute in the  <see cref="WebGpuSharp.ShaderModule"/>.
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
