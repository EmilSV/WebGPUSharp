using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;


public sealed class RenderPipeline : BaseWebGpuSafeHandle<RenderPipeline, RenderPipelineHandle>
{
    private RenderPipeline(RenderPipelineHandle handle) : base(handle)
    {
    }

    internal static RenderPipeline? FromHandle(RenderPipelineHandle handle, bool isOwnedHandle)
    {
        var newRenderPipeline = WebGpuSafeHandleCache.GetOrCreate(handle, static handle => new RenderPipeline(handle));
        if (isOwnedHandle)
        {
            newRenderPipeline?.AddReference(false);
        }
        return newRenderPipeline;
    }
}