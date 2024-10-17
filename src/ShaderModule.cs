using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public sealed class ShaderModule : BaseWebGpuSafeHandle<ShaderModuleHandle>
{
    private ShaderModule(ShaderModuleHandle handle) : base(handle)
    {
    }

    internal static ShaderModule? FromHandle(ShaderModuleHandle handle, bool isOwnedHandle)
    {
        var newShaderModule = WebGpuSafeHandleCache.GetOrCreate(handle, h => new ShaderModule(h));
        if (isOwnedHandle)
        {
            newShaderModule?.AddReference(false);
        }
        return newShaderModule;
    }

    public void GetCompilationInfo(CompilationInfoCallback callback)
    {
        _handle.GetCompilationInfo(callback);
    }

    public Task GetCompilationInfoAsync(CompilationInfoCallback callback)
    {
        return _handle.GetCompilationInfoAsync(callback);
    }

    public Task<T> GetCompilationInfoAsync<T>(CompilationInfoCallback<T> callback)
    {
        return _handle.GetCompilationInfoAsync(callback);
    }
}