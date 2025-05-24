using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public abstract class ShaderModuleBase :
    WebGPUHandleWrapperBase<ShaderModuleHandle>
{
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
}