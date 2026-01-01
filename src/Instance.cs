using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using WebGpuSharp.Marshalling;

namespace WebGpuSharp;

///<inheritdoc cref="InstanceHandle"/>
public sealed class Instance :
    WebGPUManagedHandleBase<InstanceHandle>
{
    internal Instance(InstanceHandle handle) : base(handle)
    {
    }

    ///<inheritdoc cref="InstanceHandle.RequestAdapter(in RequestAdapterOptions)"/>
    public Task<Adapter> RequestAdapterAsync(in RequestAdapterOptions options)
    {
        return Handle.RequestAdapter(options).ContinueWith(static task =>
        {
            return task.Result.ToSafeHandle()!;
        });
    }

    ///<inheritdoc cref="InstanceHandle.RequestAdapter(in RequestAdapterOptions, Action{RequestAdapterStatus, AdapterHandle, ReadOnlySpan{byte}})"/>
    public void RequestAdapterAsync(in RequestAdapterOptions options, Action<RequestAdapterStatus, Adapter, ReadOnlySpan<byte>> callback)
    {
        void innerCallback(RequestAdapterStatus status, AdapterHandle adapterHandle, ReadOnlySpan<byte> message)
        {
            var adapter = adapterHandle.ToSafeHandle()!;
            callback(status, adapter, message);
        }
        Handle.RequestAdapter(options, innerCallback);
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
}