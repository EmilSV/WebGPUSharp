using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// BufferBindingLayout of defines the structure and purpose of related GPU resources
/// such as buffers that will be used in a pipeline, and is used as a template when creating
/// BindGroups.
/// </summary>
public unsafe partial struct BufferBindingLayout
{
    public ChainedStruct* NextInChain;
    /// <summary>
    /// Indicates the type required for buffers bound to this bindings.
    /// </summary>
    public BufferBindingType Type = BufferBindingType.Uniform;
    /// <summary>
    /// Indicates whether this binding requires a dynamic offset.
    /// </summary>
    public WebGPUBool HasDynamicOffset = false;
    /// <summary>
    /// Indicates the minimum BufferBinding.Size of a buffer binding used with this bind point.
    /// Bindings are always validated against this size in  <see cref="Device.CreateBindGroup"/>.
    /// If this *is not* `0`, pipeline creation additionally validates
    /// that this value &ge; the minimum buffer binding size of the variable.
    /// If this *is* `0`, it is ignored by pipeline creation, and instead draw/dispatch commands
    /// validate that each binding in the  <see cref="BindGroup"/>
    /// satisfies the minimum buffer binding size of the variable.
    /// Note:
    /// Similar execution-time validation is theoretically possible for other
    /// binding-related fields specified for early validation, like
    ///  <see cref="TextureBindingLayout.SampleType"/> and  <see cref="StorageTextureBindingLayout.Format"/>,
    /// which currently can only be validated in pipeline creation.
    /// However, such execution-time validation could be costly or unnecessarily complex, so it is
    /// available only for  <see cref="MinBindingSize"/> which is expected to have the
    /// most ergonomic impact.
    /// </summary>
    public ulong MinBindingSize = 0;

    public BufferBindingLayout() { }

}
