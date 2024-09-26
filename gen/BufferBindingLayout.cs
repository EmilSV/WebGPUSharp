using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

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
    /// Indicates the minimumBufferBinding.Sizeof a buffer binding used with this bind point.
    /// Bindings are always validated against this size in <see cref="FFI.Device.CreateBindGroup"/>.
    /// If this *is not* `0`, pipeline creation additionallyvalidatesthat this value &ge; theminimum buffer binding sizeof the variable.
    /// If this *is* `0`, it is ignored by pipeline creation, and instead draw/dispatch commandsvalidatethat each binding in the <see cref="FFI.BindGroup"/>satisfies theminimum buffer binding sizeof the variable.
    /// Note:
    /// Similar execution-time validation is theoretically possible for other
    /// binding-related fields specified for early validation, like <see cref="TextureBindingLayout.SampleType"/>and <see cref="StorageTextureBindingLayout.Format"/>,
    /// which currently can only be validated in pipeline creation.
    /// However, such execution-time validation could be costly or unnecessarily complex, so it is
    /// available only for <see cref="MinBindingSize"/>which is expected to have the
    /// most ergonomic impact.
    /// </summary>
    public ulong MinBindingSize = 0;

    public BufferBindingLayout()
    {
    }

}
