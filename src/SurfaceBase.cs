using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public abstract class SurfaceBase : WebGPUHandleWrapperBase<SurfaceHandle>
{
    public Status GetCapabilities(Adapter adapter, SurfaceCapabilities outCapabilities)
    {
        return outCapabilities.SetInternalSurfaceCapabilities(Handle, WebGPUMarshal.GetBorrowHandle(adapter));
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
        Handle.GetCurrentTexture(ref surfaceTexture);
        return surfaceTexture;
    }

    public void Present()
    {
        Handle.Present();
    }

    public void Configure(in SurfaceConfiguration configuration)
    {
        Handle.Configure(in configuration);
    }

    public void Unconfigure()
    {
        Handle.Unconfigure();
    }
}