using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public sealed class PipelineLayout : BaseWebGpuSafeHandle<PipelineLayoutHandle>
{
    private class CacheFactory :
        WebGpuSafeHandleCache<PipelineLayoutHandle>.ISafeHandleFactory
    {
        public static BaseWebGpuSafeHandle<PipelineLayoutHandle> Create(PipelineLayoutHandle handle)
        {
            return new PipelineLayout(handle);
        }
    }

    private PipelineLayout(PipelineLayoutHandle handle) : base(handle)
    {
    }

    protected override void WebGpuReference()
    {
        WebGPU_FFI.PipelineLayoutReference(_handle);
    }

    protected override void WebGpuRelease()
    {
        WebGPU_FFI.PipelineLayoutRelease(_handle);
    }

    internal static PipelineLayout? FromHandle(PipelineLayoutHandle handle, bool incrementReferenceCount = true)
    {
        var newPipelineLayout = WebGpuSafeHandleCache<PipelineLayoutHandle>.GetOrCreate<CacheFactory>(handle) as PipelineLayout;
        if (incrementReferenceCount && newPipelineLayout != null)
        {
            newPipelineLayout.AddReference(false);
        }
        return newPipelineLayout;
    }

}