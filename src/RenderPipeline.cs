using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

/// <inheritdoc/>
public sealed class RenderPipeline :
    RenderPipelineBase,
    IFromHandle<RenderPipeline, RenderPipelineHandle>
{
    private readonly WebGpuSafeHandle<RenderPipelineHandle> _safeHandle;

    protected override RenderPipelineHandle Handle => _safeHandle.Handle;
    protected override bool HandleWrapperSameLifetime => true;

    private RenderPipeline(RenderPipelineHandle handle)
    {
        _safeHandle = new WebGpuSafeHandle<RenderPipelineHandle>(handle);
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