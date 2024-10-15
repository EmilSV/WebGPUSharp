using System.Runtime.CompilerServices;
using static WebGpuSharp.FFI.WebGPUMarshal;

namespace WebGpuSharp.FFI;

public unsafe readonly partial struct SamplerHandle :
    IDisposable, IWebGpuHandle<SamplerHandle, Sampler>
{
    public void SetLabel(WGPURefText label)
    {
        using var allocator = WebGpuAllocatorHandle.Get();
        var labelSpan = ToUtf8Span(label, allocator);
        fixed (byte* labelPtr = labelSpan)
        {
            WebGPU_FFI.SamplerSetLabel2(this, new(labelPtr, labelSpan.Length));
        }
    }

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
        WebGPU_FFI.SamplerAddRef(handle);
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