using System.Runtime.CompilerServices;
using static WebGpuSharp.FFI.WebGPUMarshal;

namespace WebGpuSharp.FFI;

public unsafe readonly partial struct PipelineLayoutHandle :
    IDisposable, IWebGpuHandle<PipelineLayoutHandle, PipelineLayout>
{

    public void SetLabel(WGPURefText label)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();

        var labelUtf8Span = WebGPUMarshal.ToUtf8Span(label, allocator, addNullTerminator: false);

        fixed (byte* labelPtr = labelUtf8Span)
        {
            WebGPU_FFI.PipelineLayoutSetLabel(this, StringViewFFI.CreateExplicitlySized(labelPtr, labelUtf8Span.Length));
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


    public PipelineLayout? ToSafeHandle(bool incrementRefCount)
    {
        if (incrementRefCount)
        {
            return ToSafeHandle<PipelineLayout, PipelineLayoutHandle>(this);
        }
        else
        {
            return ToSafeHandleNoRefIncrement<PipelineLayout, PipelineLayoutHandle>(this);
        }
    }
}