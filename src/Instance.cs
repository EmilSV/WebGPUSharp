using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public sealed class Instance : BaseWebGpuSafeHandle<InstanceHandle>
{
    private class CacheFactory :
        WebGpuSafeHandleCache<InstanceHandle>.ISafeHandleFactory
    {
        public static BaseWebGpuSafeHandle<InstanceHandle> Create(InstanceHandle handle)
        {
            return new Instance(handle);
        }
    }

    private Instance(InstanceHandle handle) : base(handle)
    {
    }

    protected override void WebGpuReference()
    {
        WebGPU_FFI.InstanceReference(_handle);
    }

    protected override void WebGpuRelease()
    {
        WebGPU_FFI.InstanceRelease(_handle);
    }

    internal static Instance? FromHandle(InstanceHandle handle, bool incrementReferenceCount = true)
    {
        var newInstance = WebGpuSafeHandleCache<InstanceHandle>.GetOrCreate<CacheFactory>(handle) as Instance;
        if (incrementReferenceCount && newInstance != null)
        {
            newInstance.AddReference(false);
        }

        return newInstance;
    }

    public Task<Adapter?> RequestAdapterAsync(in RequestAdapterOptionsFFI options)
    {
        return _handle.RequestAdapterAsync(options).ContinueWith(static task =>
        {
            return Adapter.FromHandle(task.Result);
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