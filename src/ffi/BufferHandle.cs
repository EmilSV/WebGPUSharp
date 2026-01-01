using System.Runtime.CompilerServices;
using WebGpuSharp.Marshalling;

namespace WebGpuSharp.FFI;

public unsafe readonly partial struct BufferHandle :
    IDisposable, IWebGpuHandleNeedInstance<BufferHandle, Buffer>
{
    public void Dispose()
    {
        if (_ptr != UIntPtr.Zero)
        {
            WebGPU_FFI.BufferRelease(this);
        }
    }

    public static ref nuint AsPointer(ref BufferHandle handle)
    {
        return ref Unsafe.AsRef(in handle._ptr);
    }

    public static BufferHandle GetNullHandle()
    {
        return Null;
    }

    public static bool IsNull(BufferHandle handle)
    {
        return handle == Null;
    }

    public static BufferHandle UnsafeFromPointer(nuint pointer)
    {
        return new BufferHandle(pointer);
    }

    public static void Reference(BufferHandle handle)
    {
        WebGPU_FFI.BufferAddRef(handle);
    }

    public static void Release(BufferHandle handle)
    {
        WebGPU_FFI.BufferRelease(handle);
    }

    public Buffer? ToSafeHandle(Instance instance)
    {
        return WebGPUMarshal.ToSafeHandle<Buffer, BufferHandle>(this, instance);
    }

    /// <inheritdoc cref="SetLabel(StringViewFFI)"/>
    public void SetLabel(WGPURefText label)
    {
        const int stackAllocSize = 16 * sizeof(byte);
        byte* stackAllocPtr = stackalloc byte[stackAllocSize];

        WebGpuAllocatorLogicBlock allocatorLogicBlock = default;
        using var allocator = WebGpuMarshallingMemory.GetAllocatorHandle(
            ref allocatorLogicBlock,
            stackAllocPtr,
            stackAllocSize
        );

        var labelUtf8Span = WebGPUMarshal.ToUtf8Span(label, allocator, addNullTerminator: false);

        fixed (byte* labelPtr = labelUtf8Span)
        {
            WebGPU_FFI.BufferSetLabel(this, StringViewFFI.CreateExplicitlySized(labelPtr, labelUtf8Span.Length));
        }
    }
}