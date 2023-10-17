using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public sealed class BindGroup : WebGpuSafeHandle<BindGroupHandle>
{
    private sealed class CacheFactory :
        WebGpuSafeHandleCache<BindGroupHandle>.ISafeHandleFactory
    {
        public static WebGpuSafeHandle<BindGroupHandle> Create(BindGroupHandle handle)
        {
            return new BindGroup(handle);
        }
    }

    private BindGroup(BindGroupHandle handle) : base(handle)
    {
    }

    protected override void WebGpuReference()
    {
        WebGPU_FFI.BindGroupReference(_handle);
    }

    protected override void WebGpuRelease()
    {
        WebGPU_FFI.BindGroupRelease(_handle);
    }

    internal static BindGroup? FromHandle(BindGroupHandle handle)
    {
        return WebGpuSafeHandleCache<BindGroupHandle>.GetOrCreate<CacheFactory>(handle) as BindGroup;
    }
}