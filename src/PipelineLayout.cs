using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

/// <inheritdoc/>
public sealed class PipelineLayout :
    PipelineLayoutBase,
    IFromHandle<PipelineLayout, PipelineLayoutHandle>
{
    private readonly WebGpuSafeHandle<PipelineLayoutHandle> _safeHandle;

    protected override PipelineLayoutHandle Handle => _safeHandle.Handle;
    protected override bool HandleWrapperSameLifetime => true;

    private PipelineLayout(PipelineLayoutHandle handle)
    {
        _safeHandle = new WebGpuSafeHandle<PipelineLayoutHandle>(handle);
    }

    static PipelineLayout? IFromHandle<PipelineLayout, PipelineLayoutHandle>.FromHandle(
        PipelineLayoutHandle handle)
    {
        if (PipelineLayoutHandle.IsNull(handle))
        {
            return null;
        }

        PipelineLayoutHandle.Reference(handle);
        return new(handle);
    }

    static PipelineLayout? IFromHandle<PipelineLayout, PipelineLayoutHandle>.FromHandleNoRefIncrement(
        PipelineLayoutHandle handle)
    {
        if (PipelineLayoutHandle.IsNull(handle))
        {
            return null;
        }

        return new(handle);
    }
}