using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public sealed class BindGroupLayout : WebGpuSafeHandle<BindGroupLayoutHandle>
{
    private sealed class CacheFactory :
        WebGpuSafeHandleCache<BindGroupLayoutHandle>.ISafeHandleFactory
    {
        public static WebGpuSafeHandle<BindGroupLayoutHandle> Create(BindGroupLayoutHandle handle)
        {
            return new BindGroupLayout(handle);
        }
    }

    private BindGroupLayout(BindGroupLayoutHandle handle) : base(handle)
    {
    }

    protected override void WebGpuReference()
    {
        WebGPU_FFI.BindGroupLayoutReference(_handle);
    }

    protected override void WebGpuRelease()
    {
        WebGPU_FFI.BindGroupLayoutRelease(_handle);
    }

    internal static BindGroupLayout? FromHandle(BindGroupLayoutHandle handle)
    {
        return WebGpuSafeHandleCache<BindGroupLayoutHandle>.GetOrCreate<CacheFactory>(handle) as BindGroupLayout;
    }

}