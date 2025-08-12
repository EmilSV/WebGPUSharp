using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

/// <inheritdoc cref="RenderPipelineHandle"/>
public sealed class RenderPipeline :
     WebGPUManagedHandleBase<RenderPipelineHandle>,
    IFromHandle<RenderPipeline, RenderPipelineHandle>
{
    private RenderPipeline(RenderPipelineHandle handle) : base(handle)
    {
    }

    public BindGroupLayout GetBindGroupLayout(uint groupIndex)
    {
        return Handle.GetBindGroupLayout(groupIndex).ToSafeHandle(false)!;
    }

    public void SetLabel(WGPURefText label)
    {
        Handle.SetLabel(label);
    }

    static RenderPipeline? IFromHandle<RenderPipeline, RenderPipelineHandle>.FromHandle(
        RenderPipelineHandle handle)
    {
        if (RenderPipelineHandle.IsNull(handle))
        {
            return null;
        }

        RenderPipelineHandle.Reference(handle);
        return new(handle);
    }

    static RenderPipeline? IFromHandle<RenderPipeline, RenderPipelineHandle>.FromHandleNoRefIncrement(
        RenderPipelineHandle handle)
    {
        if (RenderPipelineHandle.IsNull(handle))
        {
            return null;
        }

        return new(handle);
    }
}