using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public sealed class ShaderModule : BaseWebGpuSafeHandle<ShaderModuleHandle>
{
    private ShaderModule(ShaderModuleHandle handle) : base(handle)
    {
    }

    private class CacheFactory :
        WebGpuSafeHandleCache<ShaderModuleHandle>.ISafeHandleFactory
    {
        public static BaseWebGpuSafeHandle<ShaderModuleHandle> Create(ShaderModuleHandle handle)
        {
            return new ShaderModule(handle);
        }
    }

    protected override void WebGpuReference()
    {
        WebGPU_FFI.ShaderModuleReference(_handle);
    }

    protected override void WebGpuRelease()
    {
        WebGPU_FFI.ShaderModuleRelease(_handle);
    }

    internal static ShaderModule? FromHandle(ShaderModuleHandle handle, bool incrementReferenceCount = true)
    {
        var newShaderModule = WebGpuSafeHandleCache<ShaderModuleHandle>.GetOrCreate<CacheFactory>(handle) as ShaderModule;
        if (incrementReferenceCount && newShaderModule != null)
        {
            newShaderModule.AddReference(false);
        }
        return newShaderModule;
    }
}