using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public sealed class RenderPassEncoder : WebGpuSafeHandle<RenderPassEncoderHandle>
{
    private sealed class CacheFactory :
        WebGpuSafeHandleCache<RenderPassEncoderHandle>.ISafeHandleFactory
    {
        public static WebGpuSafeHandle<RenderPassEncoderHandle> Create(RenderPassEncoderHandle handle)
        {
            return new RenderPassEncoder(handle);
        }
    }

    private RenderPassEncoder(RenderPassEncoderHandle handle) : base(handle)
    {
    }

    protected override void WebGpuReference()
    {
        WebGPU_FFI.RenderPassEncoderReference(_handle);
    }

    protected override void WebGpuRelease()
    {
        WebGPU_FFI.RenderPassEncoderRelease(_handle);
    }

    internal static RenderPassEncoder? FromHandle(RenderPassEncoderHandle handle, bool incrementReferenceCount = true)
    {
        var newRenderPassEncoder = WebGpuSafeHandleCache<RenderPassEncoderHandle>.GetOrCreate<CacheFactory>(handle) as RenderPassEncoder;
        if (incrementReferenceCount && newRenderPassEncoder != null)
        {
            newRenderPassEncoder.AddReference(false);
        }
        return newRenderPassEncoder;
    }
}