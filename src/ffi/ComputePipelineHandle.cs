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
        WebGPU_FFI.ComputePipelineReference(handle);
    }

    public static void Release(ComputePipelineHandle handle)
    {
        WebGPU_FFI.ComputePipelineRelease(handle);
    }

    public static ComputePipelineHandle UnsafeFromPointer(nuint pointer)
    {
        return new ComputePipelineHandle(pointer);
    }


    public BindGroupLayoutHandle GetBindGroupLayout(uint groupIndex)
    {
        return WebGPU_FFI.ComputePipelineGetBindGroupLayout(this, groupIndex);
    }

    public void SetLabel(WGPURefText label)
    {
        using var allocator = WebGpuAllocatorHandle.Get();
        fixed (byte* labelPtr = WebGPUMarshal.ToRefCstrUtf8(label, allocator))
        {
            WebGPU_FFI.ComputePipelineSetLabel(this, labelPtr);
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