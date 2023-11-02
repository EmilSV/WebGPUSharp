using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public sealed class TextureView :
    BaseWebGpuSafeHandle<TextureView, TextureViewHandle>
{
    private TextureView(TextureViewHandle handle) : base(handle)
    {
    }

    internal static TextureView? FromHandle(TextureViewHandle handle, bool incrementReferenceCount)
    {
        var newTextureView = WebGpuSafeHandleCache.GetOrCreate(handle, static (handle) => new TextureView(handle));
        newTextureView?.AddReference(incrementReferenceCount);
        return newTextureView;
    }
}