using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public abstract class ComputePipelineBase :
    WebGPUHandleWrapperBase<ComputePipelineHandle>
{
    public BindGroupLayout? GetBindGroupLayout(uint groupIndex)
    {
        return Handle.GetBindGroupLayout(groupIndex).ToSafeHandle(true);
    }

    public void SetLabel(WGPURefText label)
    {
        Handle.SetLabel(label);
    }
}