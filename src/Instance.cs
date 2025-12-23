using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using WebGpuSharp.Marshalling;

namespace WebGpuSharp;

///<inheritdoc cref="InstanceHandle"/>
public sealed class Instance :
    WebGPUManagedHandleBase<InstanceHandle>,
    IFromHandle<Instance, InstanceHandle>
{
    private Instance(InstanceHandle handle) : base(handle)
    {
    }

    public Task<Adapter> RequestAdapterAsync(in RequestAdapterOptions options)
    {
        return Handle.RequestAdapterAsync(options).ContinueWith(static task =>
        {
            return task.Result.ToSafeHandle()!;
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
        return Handle.CreateSurface(descriptor).ToSafeHandle();
    }

    static Instance? IFromHandle<Instance, InstanceHandle>.FromHandle(InstanceHandle handle)
    {
        if (InstanceHandle.IsNull(handle))
        {
            return null;
        }

        InstanceHandle.Reference(handle);
        return new(handle);
    }
}