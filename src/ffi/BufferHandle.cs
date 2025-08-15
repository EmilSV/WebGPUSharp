using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using WebGpuSharp.Internal;
using WebGpuSharp.Marshalling;

namespace WebGpuSharp.FFI;

public unsafe readonly partial struct BufferHandle :
    IDisposable, IWebGpuHandle<BufferHandle, Buffer>
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

    public Buffer? ToSafeHandle(bool incrementRefCount)
    {
        if (incrementRefCount)
        {
            return WebGPUMarshal.ToSafeHandle<Buffer, BufferHandle>(this);
        }
        else
        {
            return WebGPUMarshal.ToSafeHandleNoRefIncrement<Buffer, BufferHandle>(this);
        }
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
            WebGPU_FFI.BufferSetLabel(this, StringViewFFI.CreateExplicitlySized(labelPtr, labelUtf8Span.Length));
        }
    }
}