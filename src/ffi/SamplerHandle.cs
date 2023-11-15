using System.Runtime.CompilerServices;

namespace WebGpuSharp.FFI;

public readonly partial struct SamplerHandle :
    IDisposable, IWebGpuHandle<SamplerHandle, Sampler>
{
    public static ref nuint AsPointer(ref SamplerHandle handle)
    {
        return ref Unsafe.AsRef(in handle._ptr);
    }

    public static SamplerHandle GetNullHandle()
    {
        return Null;
    }

    public static bool IsNull(SamplerHandle handle)
    {
        return handle == Null;
    }

    public static void Reference(SamplerHandle handle)
    {
        WebGPU_FFI.SamplerReference(handle);
    }

    public static void Release(SamplerHandle handle)
    {
        WebGPU_FFI.SamplerRelease(handle);
    }

    public static SamplerHandle UnsafeFromPointer(nuint pointer)
    {
        return new SamplerHandle(pointer);
    }

    public void Dispose()
    {
        if (_ptr != UIntPtr.Zero)
        {
            WebGPU_FFI.SamplerRelease(this);
        }
    }

    public Sampler? ToSafeHandle(bool isOwnedHandle)
    {
        return Sampler.FromHandle(this, isOwnedHandle);
    }
}