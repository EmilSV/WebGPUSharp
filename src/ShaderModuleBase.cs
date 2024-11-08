using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public abstract class ShaderModuleBase : 
    WebGPUHandleWrapperBase<ShaderModuleHandle>
{
    public void GetCompilationInfo(CompilationInfoCallback callback)
    {
        Handle.GetCompilationInfo(callback);
    }

    public Task GetCompilationInfoAsync(CompilationInfoCallback callback)
    {
        return Handle.GetCompilationInfoAsync(callback);
    }

    public Task<T> GetCompilationInfoAsync<T>(CompilationInfoCallback<T> callback)
    {
        return Handle.GetCompilationInfoAsync(callback);
    }
}