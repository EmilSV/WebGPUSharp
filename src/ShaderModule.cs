using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using WebGpuSharp.Marshalling;

namespace WebGpuSharp;

/// <inheritdoc/>
public sealed class ShaderModule :
    WebGPUManagedHandleBase<ShaderModuleHandle>,
    IFromHandle<ShaderModule, ShaderModuleHandle>
{
    private ShaderModule(ShaderModuleHandle handle) : base(handle)
    {
    }
    
    public void GetCompilationInfo(Action<CompilationInfoRequestStatus, CompilationInfo> callback)
    {
        Handle.GetCompilationInfo(callback);
    }

    public Task GetCompilationInfoAsync(Action<CompilationInfoRequestStatus, CompilationInfo> callback)
    {
        return Handle.GetCompilationInfoAsync(callback);
    }

    public Task<T> GetCompilationInfoAsync<T>(Func<CompilationInfoRequestStatus, CompilationInfo, T> callback)
    {
        return Handle.GetCompilationInfoAsync(callback);
    }

    static ShaderModule? IFromHandle<ShaderModule, ShaderModuleHandle>.FromHandle(
        ShaderModuleHandle handle)
    {
        if (ShaderModuleHandle.IsNull(handle))
        {
            return null;
        }

        ShaderModuleHandle.Reference(handle);
        return new(handle);
    }

    static ShaderModule? IFromHandle<ShaderModule, ShaderModuleHandle>.FromHandleNoRefIncrement(
        ShaderModuleHandle handle)
    {
        if (ShaderModuleHandle.IsNull(handle))
        {
            return null;
        }

        return new(handle);
    }
}