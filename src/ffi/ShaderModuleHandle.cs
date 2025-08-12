using System.Runtime.CompilerServices;
using static WebGpuSharp.Marshalling.WebGPUMarshal;

namespace WebGpuSharp.FFI;

public readonly partial struct ShaderModuleHandle :
    IDisposable,
    IWebGpuHandle<ShaderModuleHandle, ShaderModule>
{

    /// <inheritdoc cref="GetCompilationInfo(CompilationInfoCallbackInfoFFI)"/>
    public void GetCompilationInfo(Action<CompilationInfoRequestStatus, CompilationInfo> callbackInfo)
    {
        ShaderModuleGetCompilationInfoHandler.GetCompilationInfo(this, callbackInfo);
    }

    /// <inheritdoc cref="GetCompilationInfo(CompilationInfoCallbackInfoFFI)"/>
    public Task GetCompilationInfoAsync(Action<CompilationInfoRequestStatus, CompilationInfo> callbackInfo)
    {
        return ShaderModuleGetCompilationInfoHandler.GetCompilationInfoAsync(this, callbackInfo);
    }

    /// <inheritdoc cref="GetCompilationInfo(CompilationInfoCallbackInfoFFI)"/>
    public Task<T> GetCompilationInfoAsync<T>(Func<CompilationInfoRequestStatus, CompilationInfo, T> callbackInfo)
    {
        return ShaderModuleGetCompilationInfoHandler.GetCompilationInfoAsync(this, callbackInfo);
    }



    public static ref nuint AsPointer(ref ShaderModuleHandle handle)
    {
        return ref Unsafe.As<ShaderModuleHandle, nuint>(ref handle);
    }

    public static ShaderModuleHandle GetNullHandle()
    {
        return Null;
    }

    public static bool IsNull(ShaderModuleHandle handle)
    {
        return handle == Null;
    }

    public static void Release(ShaderModuleHandle handle)
    {
        WebGPU_FFI.ShaderModuleRelease(handle);
    }

    public static void Reference(ShaderModuleHandle handle)
    {
        WebGPU_FFI.ShaderModuleAddRef(handle);
    }

    public static ShaderModuleHandle UnsafeFromPointer(nuint pointer)
    {
        return new ShaderModuleHandle(pointer);
    }

    public void Dispose()
    {
        if (_ptr != UIntPtr.Zero)
        {
            WebGPU_FFI.ShaderModuleRelease(this);
        }
    }

    public ShaderModule? ToSafeHandle(bool incrementRefCount)
    {
        if (incrementRefCount)
        {
            return ToSafeHandle<ShaderModule, ShaderModuleHandle>(this);
        }
        else
        {
            return ToSafeHandleNoRefIncrement<ShaderModule, ShaderModuleHandle>(this);
        }
    }
}