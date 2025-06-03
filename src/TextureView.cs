
using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

/// <inheritdoc />
public sealed class TextureView :
    TextureViewBase,
    IFromHandle<TextureView, TextureViewHandle>
{
    private readonly WebGpuSafeHandle<TextureViewHandle> _safeHandle;

    protected override TextureViewHandle Handle => _safeHandle.Handle;
    protected override bool HandleWrapperSameLifetime => true;

    private TextureView(TextureViewHandle handle)
    {
        _safeHandle = new WebGpuSafeHandle<TextureViewHandle>(handle);
    }

    static TextureView? IFromHandle<TextureView, TextureViewHandle>.FromHandle(
        TextureViewHandle handle)
    {
        if (TextureViewHandle.IsNull(handle))
        {
            return null;
        }

        TextureViewHandle.Reference(handle);
        return new(handle);
    }

    static TextureView? IFromHandle<TextureView, TextureViewHandle>.FromHandleNoRefIncrement(
        TextureViewHandle handle)
    {
        if (TextureViewHandle.IsNull(handle))
        {
            return null;
        }

        return new(handle);
    }
}