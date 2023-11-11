using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public unsafe sealed class PipelineLayout : BaseWebGpuSafeHandle<PipelineLayout, PipelineLayoutHandle>
{
    private PipelineLayout(PipelineLayoutHandle handle) : base(handle)
    {
    }

    internal static PipelineLayout? FromHandle(PipelineLayoutHandle handle, bool isOwnedHandle)
    {
        var newPipelineLayout = WebGpuSafeHandleCache.GetOrCreate(handle, static handle => new PipelineLayout(handle));
        if (isOwnedHandle)
        {
            newPipelineLayout?.AddReference(false);
        }
        return newPipelineLayout;
    }

}