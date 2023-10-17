using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public sealed class Texture : WebGpuSafeHandle<TextureHandle>
{
    private class CacheFactory :
        WebGpuSafeHandleCache<TextureHandle>.ISafeHandleFactory
    {
        public static WebGpuSafeHandle<TextureHandle> Create(TextureHandle handle)
        {
            return new Texture(handle);
        }
    }

    private Texture(TextureHandle handle) : base(handle)
    {
    }

    protected override void WebGpuReference()
    {
        WebGPU_FFI.TextureReference(_handle);
    }

    protected override void WebGpuRelease()
    {
        WebGPU_FFI.TextureRelease(_handle);
    }


    internal static Texture? FromHandle(TextureHandle handle)
    {
        return WebGpuSafeHandleCache<TextureHandle>.GetOrCreate<CacheFactory>(handle) as Texture;
    }

    public TextureView? CreateView(in TextureViewDescriptor textureViewDescriptor)
    {
        return TextureView.FromHandle(_handle.CreateView(textureViewDescriptor));
    }
}
