using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct PipelineLayoutDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public byte* Label;
    public nuint BindGroupLayoutCount;
    /// <summary>
    /// A list of  <see cref="FFI.BindGroupLayout"/>s the pipeline will use. Each element corresponds to a
    /// @group attribute in the  <see cref="FFI.ShaderModule"/>, with the `N`th element corresponding with
    /// `@group(N)`.
    /// </summary>
    public required BindGroupLayoutHandle* BindGroupLayouts;

    public PipelineLayoutDescriptorFFI()
    {
    }

}
