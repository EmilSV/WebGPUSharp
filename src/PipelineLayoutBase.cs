using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public unsafe abstract class PipelineLayoutBase : 
    WebGPUHandleWrapperBase<PipelineLayoutHandle>
{
    public void SetLabel(WGPURefText label)
    {
        Handle.SetLabel(label);
    }
}