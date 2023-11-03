using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public sealed class TextureView :
    BaseWebGpuSafeHandle<TextureView, TextureViewHandle>
{
    private TextureView(TextureViewHandle handle) : base(handle)
    {
    }

    internal static TextureView? FromHandle(TextureViewHandle handle, bool isOwnedHandle)
    {
        var newTextureView = WebGpuSafeHandleCache.GetOrCreate(handle, static (handle) => new TextureView(handle));
        if (isOwnedHandle)
        {
            newTextureView?.AddReference(false);
        }
        return newTextureView;
    }
}