
using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

///<inheritdoc cref="InstanceHandle"/>
public abstract class InstanceBase : WebGPUHandleWrapperBase<InstanceHandle>
{
    public Task<Adapter> RequestAdapterAsync(in RequestAdapterOptions options)
    {
        return Handle.RequestAdapterAsync(options).ContinueWith(static task =>
        {
            return task.Result.ToSafeHandle(false)!;
        });
    }

    ///<inheritdoc cref="InstanceHandle.ProcessEvents()"/>
    public void ProcessEvents()
    {
        Handle.ProcessEvents();
    }

    ///<inheritdoc cref="InstanceHandle.CreateSurface(SurfaceDescriptor)"/>
    public Surface? CreateSurface(SurfaceDescriptor descriptor)
    {
        return Handle.CreateSurface(descriptor).ToSafeHandle(false);
    }
}