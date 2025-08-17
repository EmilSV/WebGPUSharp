using System.Runtime.CompilerServices;
using WebGpuSharp.Marshalling;
using static WebGpuSharp.Marshalling.WebGPUMarshal;

namespace WebGpuSharp.FFI;

public unsafe readonly partial struct RenderPipelineHandle :
    IDisposable, IWebGpuHandle<RenderPipelineHandle, RenderPipeline>
{
    /// <inheritdoc cref="SetLabel(StringViewFFI)"/>
    public void SetLabel(WGPURefText label)
    {
        WebGpuAllocatorLogicBlock allocatorLogicBlock = default;
        const int stackAllocSize = 16 * sizeof(byte) ;
        byte* stackAllocPtr = stackalloc byte[stackAllocSize];

        using var allocator = WebGpuMarshallingMemory.GetAllocatorHandle(
            ref allocatorLogicBlock,
            stackAllocPtr,
            stackAllocSize
        );

        var labelUtf8Span = ToUtf8Span(label, allocator, addNullTerminator: false);

        fixed (byte* labelPtr = labelUtf8Span)
        {
            WebGPU_FFI.RenderPipelineSetLabel(this, StringViewFFI.CreateExplicitlySized(labelPtr, labelUtf8Span.Length));
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
        WebGPU_FFI.RenderPipelineAddRef(handle);
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

    public RenderPipeline? ToSafeHandle(bool incrementRefCount)
    {
        if (incrementRefCount)
        {
            return ToSafeHandle<RenderPipeline, RenderPipelineHandle>(this);
        }
        else
        {
            return ToSafeHandleNoRefIncrement<RenderPipeline, RenderPipelineHandle>(this);
        }
    }
}