using System.Runtime.CompilerServices;

namespace WebGpuSharp.FFI;

public unsafe readonly partial struct RenderPipelineHandle :
    IDisposable, IWebGpuHandle<RenderPipelineHandle, RenderPipeline>
{
    public BindGroupLayoutHandle GetBindGroupLayout(uint groupIndex)
    {
        return WebGPU_FFI.RenderPipelineGetBindGroupLayout(this, groupIndex);
    }

    public void SetLabel(WGPURefText label)
    {
        using var allocator = WebGpuAllocatorHandle.Get();
        fixed (byte* labelPtr = WebGPUMarshal.ToRefCstrUtf8(label, allocator))
        {
            WebGPU_FFI.RenderPipelineSetLabel(this, labelPtr);
        }
    }

    public static ref nuint AsPointer(ref RenderPipelineHandle handle)
    {
        return ref Unsafe.AsRef(in handle._ptr);
    }

    public static RenderPipelineHandle GetNullHandle()
    {
        return Null;
    }

    public static bool IsNull(RenderPipelineHandle handle)
    {
        return handle == Null;
    }

    public static void Reference(RenderPipelineHandle handle)
    {
        WebGPU_FFI.RenderPipelineReference(handle);
    }

    public static void Release(RenderPipelineHandle handle)
    {
        WebGPU_FFI.RenderPipelineRelease(handle);
    }

    public static RenderPipelineHandle UnsafeFromPointer(nuint pointer)
    {
        return new RenderPipelineHandle(pointer);
    }

    public void Dispose()
    {
        if (_ptr != UIntPtr.Zero)
        {
            WebGPU_FFI.RenderPipelineRelease(this);
        }
    }

    public RenderPipeline? ToSafeHandle(bool isOwnedHandle)
    {
        return RenderPipeline.FromHandle(this, isOwnedHandle);
    }
}