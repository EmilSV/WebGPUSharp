using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using WebGpuSharp.Marshalling;

namespace WebGpuSharp;

/// <inheritdoc/>
public sealed class ShaderModule :
    WebGPUManagedHandleBase<ShaderModuleHandle>,
    IFromHandleWithInstance<ShaderModule, ShaderModuleHandle>
{
    private readonly Instance _instance;

    private ShaderModule(ShaderModuleHandle handle, Instance instance) : base(handle)
    {
        _instance = instance;
    }

    public void GetCompilationInfo(Action<CompilationInfoRequestStatus, CompilationInfo> callback)
    {
        Handle.GetCompilationInfo(callback);
    }

    public Task<T> GetCompilationInfoAsync<T>(Func<CompilationInfoRequestStatus, CompilationInfo, T> callback)
    {
        return Handle.GetCompilationInfo(callback);
    }

    static ShaderModule? IFromHandleWithInstance<ShaderModule, ShaderModuleHandle>.FromHandle(
        ShaderModuleHandle handle, Instance instance)
    {
        if (ShaderModuleHandle.IsNull(handle))
        {
            return null;
        }

        ShaderModuleHandle.Reference(handle);
        return new(handle, instance);
    }

    static Instance IFromHandleWithInstance<ShaderModule, ShaderModuleHandle>.GetOwnerInstance(
        ShaderModule instance)
    {
        return instance._instance;
    }
}