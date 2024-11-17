
using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public abstract class InstanceBase : WebGPUHandleWrapperBase<InstanceHandle>
{
    public Task<Adapter> RequestAdapterAsync(in RequestAdapterOptions options)
    {
        return Handle.RequestAdapterAsync(options).ContinueWith(static task =>
        {
            return task.Result.ToSafeHandle(false)!;
        });
    }

    public void ProcessEvents()
    {
        Handle.ProcessEvents();
    }

    public Surface? CreateSurface(SurfaceDescriptor descriptor)
    {
        return Handle.CreateSurface(descriptor).ToSafeHandle(false);
    }
}