using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public sealed class TextureView : WebGpuSafeHandle<TextureViewHandle>
{
    private class CacheFactory :
        WebGpuSafeHandleCache<TextureViewHandle>.ISafeHandleFactory
    {
        public static WebGpuSafeHandle<TextureViewHandle> Create(TextureViewHandle handle)
        {
            return new TextureView(handle);
        }
    }


    private TextureView(TextureViewHandle handle) : base(handle)
    {
    }

    protected override void WebGpuReference()
    {
        WebGPU_FFI.TextureViewReference(_handle);
    }

    protected override void WebGpuRelease()
    {
        WebGPU_FFI.TextureViewRelease(_handle);
    }


    internal static TextureView? FromHandle(TextureViewHandle handle, bool incrementReferenceCount = true)
    {
        var newTextureView = WebGpuSafeHandleCache<TextureViewHandle>.GetOrCreate<CacheFactory>(handle) as TextureView;
        if (incrementReferenceCount && newTextureView != null)
        {
            newTextureView.AddReference(false);
        }
        return newTextureView;
    }
}