using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using WebGpuSharp.Marshalling;

namespace WebGpuSharp;

/// <inheritdoc cref ="PipelineLayoutHandle"/>
public sealed class PipelineLayout :
    WebGPUManagedHandleBase<PipelineLayoutHandle>,
    IFromHandle<PipelineLayout, PipelineLayoutHandle>
{
    private PipelineLayout(PipelineLayoutHandle handle) : base(handle)
    {
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