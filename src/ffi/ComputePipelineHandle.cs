using System.Runtime.CompilerServices;

namespace WebGpuSharp.FFI;

public unsafe readonly partial struct ComputePipelineHandle :
    IDisposable, IWebGpuHandle<ComputePipelineHandle>

{
    public static ref nuint AsPointer(ref ComputePipelineHandle handle)
    {
        return ref Unsafe.As<ComputePipelineHandle, UIntPtr>(ref handle);
    }

    public static bool IsNull(ComputePipelineHandle handle)
    {
        return handle == Null;
    }

    public static void Reference(ComputePipelineHandle handle)
    {
        WebGPU_FFI.ComputePipelineAddRef(handle);
    }

    public static void Release(ComputePipelineHandle handle)
    {
        WebGPU_FFI.ComputePipelineRelease(handle);
    }

    public static ComputePipelineHandle UnsafeFromPointer(nuint pointer)
    {
        return new ComputePipelineHandle(pointer);
    }

    public void SetLabel(WGPURefText label)
    {
        using var allocator = WebGpuAllocatorHandle.Get();
        var labelUtf8Span = WebGPUMarshal.ToUtf8Span(label, allocator, false);
        fixed (byte* labelPtr = labelUtf8Span)
        {
            WebGPU_FFI.ComputePipelineSetLabel2(this, new(labelPtr, labelUtf8Span.Length));
        }
    }

    public void Dispose()
    {
        if (_ptr != UIntPtr.Zero)
        {
            WebGPU_FFI.ComputePipelineRelease(this);
        }
    }
}