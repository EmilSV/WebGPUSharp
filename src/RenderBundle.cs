using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using WebGpuSharp.Marshalling;

namespace WebGpuSharp;

/// <inheritdoc cref="RenderBundleHandle" />
public sealed class RenderBundle :
    WebGPUManagedHandleBase<RenderBundleHandle>,
    IFromHandle<RenderBundle, RenderBundleHandle>
{
    private RenderBundle(RenderBundleHandle handle) : base(handle)
    {
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
}