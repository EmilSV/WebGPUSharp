using System.Runtime.CompilerServices;
using static WebGpuSharp.Marshalling.WebGPUMarshal;

namespace WebGpuSharp.FFI;

public readonly partial struct BindGroupLayoutHandle :
     IDisposable, IWebGpuHandle<BindGroupLayoutHandle, BindGroupLayout>
{
    public static ref nuint AsPointer(ref BindGroupLayoutHandle handle)
    {
        return ref Unsafe.AsRef(in handle._ptr);
    }

    public static BindGroupLayoutHandle GetNullHandle()
    {
        return Null;
    }

    public static bool IsNull(BindGroupLayoutHandle handle)
    {
        return handle == Null;
    }

    public static void Reference(BindGroupLayoutHandle handle)
    {
        WebGPU_FFI.BindGroupLayoutAddRef(handle);
    }

    public static void Release(BindGroupLayoutHandle handle)
    {
        WebGPU_FFI.BindGroupLayoutRelease(handle);
    }

    public static BindGroupLayoutHandle UnsafeFromPointer(nuint pointer)
    {
        return new BindGroupLayoutHandle(pointer);
    }

    public readonly void Dispose()
    {
        if (_ptr != UIntPtr.Zero)
        {
            WebGPU_FFI.BindGroupLayoutRelease(this);
        }
    }

    public BindGroupLayout? ToSafeHandle() => ToSafeHandle<BindGroupLayout, BindGroupLayoutHandle>(this);
}
