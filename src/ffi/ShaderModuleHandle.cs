using System.Runtime.CompilerServices;

namespace WebGpuSharp.FFI;

public readonly partial struct ShaderModuleHandle :
    IDisposable,
    IWebGpuHandle<ShaderModuleHandle, ShaderModule>
{

    public void GetCompilationInfo(CompilationInfoCallback callback)
    {
        ShaderModuleGetCompilationInfoHandler.GetCompilationInfo(this, callback);
    }

    public Task GetCompilationInfoAsync(CompilationInfoCallback callback)
    {
        return ShaderModuleGetCompilationInfoHandler.GetCompilationInfoAsync(this, callback);
    }

    public Task<T> GetCompilationInfoAsync<T>(CompilationInfoCallback<T> callback)
    {
        return ShaderModuleGetCompilationInfoHandler.GetCompilationInfoAsync(this, callback);
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

    public ShaderModule? ToSafeHandle(bool isOwnedHandle)
    {
        return ShaderModule.FromHandle(this, isOwnedHandle);
    }
}