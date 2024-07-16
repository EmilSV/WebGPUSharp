using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;


public sealed class Surface :
    BaseWebGpuSafeHandle<Surface, SurfaceHandle>,
    ITextureSource
{
    private Surface(SurfaceHandle handle) : base(handle)
    {
    }

    internal static Surface? FromHandle(SurfaceHandle handle, bool isOwnedHandle)
    {
        var newSurface = WebGpuSafeHandleCache.GetOrCreate(handle, static handle => new Surface(handle));
        if (isOwnedHandle)
        {
            newSurface?.AddReference(false);
        }
        return newSurface;
    }

    public Status GetCapabilities(Adapter adapter, SurfaceCapabilities outCapabilities)
    {
        return outCapabilities.SetInternalSurfaceCapabilities((SurfaceHandle)this, (AdapterHandle)adapter);
    }

    public SurfaceCapabilities? GetCapabilities(Adapter adapter)
    {
        SurfaceCapabilities capabilities = new();
        var status = GetCapabilities(adapter, capabilities);
        if (status != Status.Success)
        {
            return null;
        }
        return capabilities;
    }

    public SurfaceTexture GetCurrentTexture()
    {
        SurfaceTexture surfaceTexture = default;
        ((SurfaceHandle)this).GetCurrentTexture(ref surfaceTexture);
        return surfaceTexture;
    }

    public void Present()
    {
        ((SurfaceHandle)this).Present();
    }

    public void Configure(in SurfaceConfiguration configuration)
    {
        ((SurfaceHandle)this).Configure(in configuration);
    }

    public void Unconfigure()
    {
        ((SurfaceHandle)this).Unconfigure();
    }

    Texture? ITextureSource.GetCurrentTexture()
    {
        return GetCurrentTexture().Texture;
    }

    TextureHandle ITextureSource.UnsafeGetCurrentOwnedTextureHandle()
    {
        SurfaceTextureFFI surfaceTextureFFI = default;
        _handle.GetCurrentTexture(ref surfaceTextureFFI);
        return surfaceTextureFFI.Texture;
    }
}