using System.Runtime.CompilerServices;

namespace WebGpuSharp.FFI;

public unsafe readonly partial struct PipelineLayoutHandle :
    IDisposable, IWebGpuHandle<PipelineLayoutHandle, PipelineLayout>
{

    public void SetLabel(WGPURefText label)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        fixed (byte* labelPtr = WebGPUMarshal.ToRefCstrUtf8(label, allocator))
        {
            WebGPU_FFI.PipelineLayoutSetLabel(this, labelPtr);
        }
    }

    public void Dispose()
    {
        if (_ptr != UIntPtr.Zero)
        {
            WebGPU_FFI.PipelineLayoutRelease(this);
        }
    }

    public static ref UIntPtr AsPointer(ref PipelineLayoutHandle handle)
    {
        return ref Unsafe.AsRef(in handle._ptr);
    }

    public static PipelineLayoutHandle GetNullHandle()
    {
        return Null;
    }

    public static bool IsNull(PipelineLayoutHandle handle)
    {
        return handle == Null;
    }

    public static unsafe PipelineLayoutHandle UnsafeFromPointer(nuint ptr)
    {
        return new PipelineLayoutHandle(ptr);
    }

    public static void Reference(PipelineLayoutHandle handle)
    {
        WebGPU_FFI.PipelineLayoutAddRef(handle);
    }

    public static void Release(PipelineLayoutHandle handle)
    {
        WebGPU_FFI.PipelineLayoutRelease(handle);
    }

    public PipelineLayout? ToSafeHandle(bool isOwnedHandle)
    {
        return PipelineLayout.FromHandle(this, isOwnedHandle);
    }
}