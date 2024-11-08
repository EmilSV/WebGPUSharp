using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public sealed class ComputePipeline :
    ComputePipelineBase,
    IFromHandle<ComputePipeline, ComputePipelineHandle>
{
    private readonly WebGpuSafeHandle<ComputePipelineHandle> _safeHandle;

    protected override ComputePipelineHandle Handle => _safeHandle.Handle;
    protected override bool HandleWrapperSameLifetime => true;

    private ComputePipeline(ComputePipelineHandle handle)
    {
        _safeHandle = new WebGpuSafeHandle<ComputePipelineHandle>(handle);
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