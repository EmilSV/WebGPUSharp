using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

/// <inheritdoc cref="ComputePipelineHandle"/>
public abstract class ComputePipelineBase :
    WebGPUHandleWrapperBase<ComputePipelineHandle>
{
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
}