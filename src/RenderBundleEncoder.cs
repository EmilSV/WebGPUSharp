using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public sealed class RenderBundleEncoder :
    RenderBundleEncoderBase,
    IFromHandle<RenderBundleEncoder, RenderBundleEncoderHandle>
{
    private readonly WebGpuSafeHandle<RenderBundleEncoderHandle> _safeHandle;

    protected override RenderBundleEncoderHandle Handle => _safeHandle.Handle;
    protected override bool HandleWrapperSameLifetime => true;

    private RenderBundleEncoder(RenderBundleEncoderHandle handle)
    {
        _safeHandle = new WebGpuSafeHandle<RenderBundleEncoderHandle>(handle);
    }

    static RenderBundleEncoder? IFromHandle<RenderBundleEncoder, RenderBundleEncoderHandle>.FromHandle(
        RenderBundleEncoderHandle handle)
    {
        if (RenderBundleEncoderHandle.IsNull(handle))
        {
            return null;
        }

        RenderBundleEncoderHandle.Reference(handle);
        return new(handle);
    }

    static RenderBundleEncoder? IFromHandle<RenderBundleEncoder, RenderBundleEncoderHandle>.FromHandleNoRefIncrement(
        RenderBundleEncoderHandle handle)
    {
        if (RenderBundleEncoderHandle.IsNull(handle))
        {
            return null;
        }

        return new(handle);
    }
}