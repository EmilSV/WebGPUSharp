
using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using WebGpuSharp.Marshalling;

namespace WebGpuSharp;

/// <inheritdoc cref ="TextureViewHandle" />
public sealed class TextureView :
    WebGPUManagedHandleBase<TextureViewHandle>,
    IFromHandle<TextureView, TextureViewHandle>
{

    private TextureView(TextureViewHandle handle) : base(handle)
    {
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
}