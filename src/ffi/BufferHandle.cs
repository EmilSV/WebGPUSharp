using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using WebGpuSharp.Internal;

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

    public Buffer? ToSafeHandle(bool isOwnedHandle)
    {
        return Buffer.FromHandle(this, isOwnedHandle);
    }

    public void SetLabel(WGPURefText label)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();

        var labelUtf8Span = WebGPUMarshal.ToUtf8Span(label, allocator, addNullTerminator: false);

        fixed (byte* labelPtr = labelUtf8Span)
        {
            WebGPU_FFI.BufferSetLabel2(this, new(labelPtr, labelUtf8Span.Length));
        }
    }
}