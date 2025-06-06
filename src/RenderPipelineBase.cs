using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

/// <inheritdoc cref="RenderPipelineHandle"/>
public abstract class RenderPipelineBase : WebGPUHandleWrapperBase<RenderPipelineHandle>
{
    public BindGroupLayout GetBindGroupLayout(uint groupIndex)
    {
        return Handle.GetBindGroupLayout(groupIndex).ToSafeHandle(false)!;
    }

    public void SetLabel(WGPURefText label)
    {
        Handle.SetLabel(label);
    }
}