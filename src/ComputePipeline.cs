using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public sealed class ComputePipeline :
    BaseWebGpuSafeHandle<ComputePipeline, ComputePipelineHandle>
{
    private ComputePipeline(ComputePipelineHandle handle) : base(handle)
    {
    }

    internal static ComputePipeline? FromHandle(ComputePipelineHandle handle, bool isOwnedHandle)
    {
        var newComputePipeline = WebGpuSafeHandleCache.GetOrCreate(handle, static (handle) => new ComputePipeline(handle));
        if (isOwnedHandle)
        {
            newComputePipeline?.AddReference(false);
        }
        return newComputePipeline;
    }
}