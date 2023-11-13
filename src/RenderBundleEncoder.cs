using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;


public class RenderBundleEncoder : BaseWebGpuSafeHandle<RenderBundleEncoder, RenderBundleEncoderHandle>
{
    private RenderBundleEncoder(RenderBundleEncoderHandle handle) : base(handle)
    {
    }

    internal static RenderBundleEncoder? FromHandle(RenderBundleEncoderHandle handle, bool isOwnedHandle)
    {
        var newRenderBundleEncoder = WebGpuSafeHandleCache.GetOrCreate(handle, static (handle) => new RenderBundleEncoder(handle));
        if (isOwnedHandle)
        {
            newRenderBundleEncoder?.AddReference(false);
        }
        return newRenderBundleEncoder;
    }
}