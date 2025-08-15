using System.Runtime.CompilerServices;
using WebGpuSharp.Marshalling;

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

    public ComputePipeline? ToSafeHandle(bool incrementRefCount)
    {
        if (incrementRefCount)
        {
            return WebGPUMarshal.ToSafeHandle<ComputePipeline, ComputePipelineHandle>(this);
        }
        else
        {
            return WebGPUMarshal.ToSafeHandleNoRefIncrement<ComputePipeline, ComputePipelineHandle>(this);
        }
    }

    public static ComputePipelineHandle UnsafeFromPointer(nuint pointer)
    {
        return new ComputePipelineHandle(pointer);
    }

    /// <inheritdoc cref="SetLabel(StringViewFFI)"/>
    public void SetLabel(WGPURefText label)
    {
        const int stackAllocSize = 16 * sizeof(byte) + WebGpuMarshallingMemory.DefaultStartStackSize;
        byte* stackAllocPtr = stackalloc byte[stackAllocSize];
        using var allocator = WebGpuMarshallingMemory.GetAllocatorHandle(stackAllocPtr, stackAllocSize);
        
        var labelUtf8Span = WebGPUMarshal.ToUtf8Span(label, allocator, addNullTerminator: false);
        fixed (byte* labelPtr = labelUtf8Span)
        {
            WebGPU_FFI.ComputePipelineSetLabel(this, StringViewFFI.CreateExplicitlySized(labelPtr, labelUtf8Span.Length));
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