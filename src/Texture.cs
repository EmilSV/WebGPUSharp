using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public sealed class Texture : BaseWebGpuSafeHandle<TextureHandle>
{
    private Texture(TextureHandle handle) : base(handle)
    {
    }

    internal static Texture? FromHandle(TextureHandle handle, bool isOwnedHandle)
    {
        var newTexture = WebGpuSafeHandleCache.GetOrCreate(handle, static (handle) => new Texture(handle));
        if (isOwnedHandle)
        {
            newTexture?.AddReference(false);
        }
        return newTexture;
    }

    public TextureView? CreateView(in TextureViewDescriptor textureViewDescriptor)
    {
        return _handle.CreateView(textureViewDescriptor).ToSafeHandle(false);
    }
}
