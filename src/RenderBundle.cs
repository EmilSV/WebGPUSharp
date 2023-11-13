using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public sealed class RenderBundle : BaseWebGpuSafeHandle<RenderBundle, RenderBundleHandle>
{
    private RenderBundle(RenderBundleHandle handle) : base(handle)
    {
    }

    internal static RenderBundle? FromHandle(RenderBundleHandle handle, bool isOwnedHandle)
    {
        var newRenderBundleEncoder = WebGpuSafeHandleCache.GetOrCreate(handle, static (handle) => new RenderBundle(handle));
        if (isOwnedHandle)
        {
            newRenderBundleEncoder?.AddReference(false);
        }
        return newRenderBundleEncoder;
    }

}