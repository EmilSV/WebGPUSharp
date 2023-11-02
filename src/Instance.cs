using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public sealed class Instance : BaseWebGpuSafeHandle<Instance, InstanceHandle>
{
    private Instance(InstanceHandle handle) : base(handle)
    {
    }

    internal static Instance? FromHandle(InstanceHandle handle, bool isOwnedHandle)
    {
        var newInstance = WebGpuSafeHandleCache.GetOrCreate(handle, static (handle) => new Instance(handle));
        if (isOwnedHandle)
        {
            newInstance?.AddReference(false);
        }

        return newInstance;
    }

    public Task<Adapter?> RequestAdapterAsync(in RequestAdapterOptionsFFI options)
    {
        return _handle.RequestAdapterAsync(options).ContinueWith(static task =>
        {
            return task.Result.ToSafeHandle(true);
        });
    }

    public void ProcessEvents()
    {
        _handle.ProcessEvents();
    }

    public Surface? CreateSurface(SurfaceDescriptor descriptor)
    {
        return Surface.FromHandle(_handle.CreateSurface(descriptor));
    }
}