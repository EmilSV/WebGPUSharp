using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public sealed class RenderPassEncoder : BaseWebGpuSafeHandle<RenderPassEncoderHandle>
{
    private RenderPassEncoder(RenderPassEncoderHandle handle) : base(handle)
    {
    }

    internal static RenderPassEncoder? FromHandle(RenderPassEncoderHandle handle, bool isOwnedHandle)
    {
        var newRenderPassEncoder = WebGpuSafeHandleCache.GetOrCreate(handle, static (handle) => new RenderPassEncoder(handle));
        if (isOwnedHandle)
        {
            newRenderPassEncoder?.AddReference(false);
        }
        return newRenderPassEncoder;
    }
}