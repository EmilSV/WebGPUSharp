using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

/// <inheritdoc cref ="PipelineLayoutHandle"/>
public unsafe abstract class PipelineLayoutBase :
    WebGPUHandleWrapperBase<PipelineLayoutHandle>
{
    /// <inheritdoc cref ="PipelineLayoutHandle.SetLabel(WGPURefText)"/>
    public void SetLabel(WGPURefText label)
    {
        Handle.SetLabel(label);
    }
}