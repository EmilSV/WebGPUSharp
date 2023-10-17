using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;


public sealed class RenderPipeline : WebGpuSafeHandle<RenderPipelineHandle>
{
    private sealed class CacheFactory :
        WebGpuSafeHandleCache<RenderPipelineHandle>.ISafeHandleFactory
    {
        public static WebGpuSafeHandle<RenderPipelineHandle> Create(RenderPipelineHandle handle)
        {
            return new RenderPipeline(handle);
        }
    }

    private RenderPipeline(RenderPipelineHandle handle) : base(handle)
    {
    }

    protected override void WebGpuReference()
    {
        WebGPU_FFI.RenderPipelineReference(_handle);
    }

    protected override void WebGpuRelease()
    {
        WebGPU_FFI.RenderPipelineRelease(_handle);
    }

    internal static RenderPipeline? FromHandle(RenderPipelineHandle handle, bool incrementReferenceCount = true)
    {
        var newRenderPipeline = WebGpuSafeHandleCache<RenderPipelineHandle>.GetOrCreate<CacheFactory>(handle) as RenderPipeline;
        if (incrementReferenceCount && newRenderPipeline != null)
        {
            newRenderPipeline.AddReference(false);
        }
        return newRenderPipeline;
    }
}