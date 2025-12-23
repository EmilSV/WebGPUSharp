using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using WebGpuSharp.Marshalling;

namespace WebGpuSharp;

/// <inheritdoc cref="SurfaceHandle"/>
public sealed class Surface :
     WebGPUManagedHandleBase<SurfaceHandle>,
    IFromHandle<Surface, SurfaceHandle>
{
    private Surface(SurfaceHandle handle) : base(handle)
    {
    }

    public Status GetCapabilities(Adapter adapter, SurfaceCapabilities outCapabilities)
    {
        return outCapabilities.SetInternalSurfaceCapabilities(Handle, WebGPUMarshal.GetHandle(adapter));
    }

    /// <inheritdoc cref="SurfaceHandle.GetCapabilities(AdapterHandle, SurfaceCapabilitiesFFI*)"/>
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

    /// <inheritdoc cref="SurfaceHandle.GetCurrentTexture(SurfaceTextureFFI*)"/>
    public SurfaceTexture GetCurrentTexture()
    {
        SurfaceTexture surfaceTexture = default;
        Handle.GetCurrentTexture(ref surfaceTexture);
        return surfaceTexture;
    }

    /// <inheritdoc cref="SurfaceHandle.Present()"/>
    public void Present()
    {
        Handle.Present();
    }

    /// <inheritdoc cref="SurfaceHandle.Configure(in SurfaceConfiguration)"/>
    public void Configure(in SurfaceConfiguration configuration)
    {
        Handle.Configure(in configuration);
    }

    /// <inheritdoc cref="SurfaceHandle.Unconfigure()"/>
    public void Unconfigure()
    {
        Handle.Unconfigure();
    }

    static Surface? IFromHandle<Surface, SurfaceHandle>.FromHandle(SurfaceHandle handle)
    {
        if (SurfaceHandle.IsNull(handle))
        {
            return null;
        }

        SurfaceHandle.Reference(handle);
        return new(handle);
    }
}