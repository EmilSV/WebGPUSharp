using System.Runtime.CompilerServices;

namespace WebGpuSharp.FFI;

public readonly partial struct ShaderModuleHandle :
    IDisposable,
    IWebGpuHandle<ShaderModuleHandle>
{

    public static ref nuint AsPointer(ref ShaderModuleHandle handle)
    {
        return ref Unsafe.AsRef(handle._ptr);
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
        WebGPU_FFI.ShaderModuleReference(handle);
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