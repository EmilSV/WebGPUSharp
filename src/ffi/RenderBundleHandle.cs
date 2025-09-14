using System.Runtime.CompilerServices;
using static WebGpuSharp.Marshalling.WebGPUMarshal;

namespace WebGpuSharp.FFI;

public unsafe readonly partial struct RenderBundleHandle :
    IDisposable, IWebGpuHandle<RenderBundleHandle, RenderBundle>
{
    public static ref nuint AsPointer(ref RenderBundleHandle handle)
    {
        return ref Unsafe.As<RenderBundleHandle, nuint>(ref handle);
    }

    public static bool IsNull(RenderBundleHandle handle)
    {
        return handle == Null;
    }

    public static void Reference(RenderBundleHandle handle)
    {
        WebGPU_FFI.RenderBundleAddRef(handle);
    }

    public static void Release(RenderBundleHandle handle)
    {
        WebGPU_FFI.RenderBundleRelease(handle);
    }

    public static RenderBundleHandle UnsafeFromPointer(nuint pointer)
    {
        return new RenderBundleHandle(pointer);
    }

    public readonly void Dispose()
    {
        if (_ptr != UIntPtr.Zero)
        {
            WebGPU_FFI.RenderBundleRelease(this);
        }
    }

    public RenderBundle? ToSafeHandle(bool incrementRefCount)
    {
        if (incrementRefCount)
        {
            return ToSafeHandle<RenderBundle, RenderBundleHandle>(this);
        }
        else
        {
            return ToSafeHandleNoRefIncrement<RenderBundle, RenderBundleHandle>(this);
        }
    }
}