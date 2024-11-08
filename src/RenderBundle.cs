using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public sealed class RenderBundle :
    RenderBundleBase,
    IFromHandle<RenderBundle, RenderBundleHandle>
{
    private readonly WebGpuSafeHandle<RenderBundleHandle> _safeHandle;

    protected override RenderBundleHandle Handle => _safeHandle.Handle;
    protected override bool HandleWrapperSameLifetime => true;

    private RenderBundle(RenderBundleHandle handle)
    {
        _safeHandle = new WebGpuSafeHandle<RenderBundleHandle>(handle);
    }

    static RenderBundle? IFromHandle<RenderBundle, RenderBundleHandle>.FromHandle(
        RenderBundleHandle handle)
    {
        if (RenderBundleHandle.IsNull(handle))
        {
            return null;
        }

        RenderBundleHandle.Reference(handle);
        return new(handle);
    }

    static RenderBundle? IFromHandle<RenderBundle, RenderBundleHandle>.FromHandleNoRefIncrement(
        RenderBundleHandle handle)
    {
        if (RenderBundleHandle.IsNull(handle))
        {
            return null;
        }

        return new(handle);
    }
}