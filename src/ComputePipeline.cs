using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

/// <inheritdoc cref="ComputePipelineHandle"/>
public sealed class ComputePipeline :
    WebGPUManagedHandleBase<ComputePipelineHandle>,
    IFromHandle<ComputePipeline, ComputePipelineHandle>
{
    private ComputePipeline(ComputePipelineHandle handle) : base(handle)
    {
    }

    /// <inheritdoc cref="ComputePipelineHandle.GetBindGroupLayout(uint)"/>
    public BindGroupLayout? GetBindGroupLayout(uint groupIndex)
    {
        return Handle.GetBindGroupLayout(groupIndex).ToSafeHandle(false);
    }

    /// <inheritdoc cref="ComputePipelineHandle.SetLabel(WGPURefText)"/>
    public void SetLabel(WGPURefText label)
    {
        Handle.SetLabel(label);
    }

    static ComputePipeline? IFromHandle<ComputePipeline, ComputePipelineHandle>.FromHandle(
        ComputePipelineHandle handle)
    {
        if (ComputePipelineHandle.IsNull(handle))
        {
            return null;
        }

        ComputePipelineHandle.Reference(handle);
        return new(handle);
    }

    static ComputePipeline? IFromHandle<ComputePipeline, ComputePipelineHandle>.FromHandleNoRefIncrement(
        ComputePipelineHandle handle)
    {
        if (ComputePipelineHandle.IsNull(handle))
        {
            return null;
        }

        return new(handle);
    }
}