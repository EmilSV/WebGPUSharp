using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using WebGpuSharp.Internal;
using static WebGpuSharp.WebGPUMarshal;

namespace WebGpuSharp.FFI;

public readonly unsafe partial struct QueueHandle :
    IDisposable, IWebGpuHandle<QueueHandle, Queue>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly void Submit(ReadOnlySpan<CommandBufferHandle> commands)
    {
        fixed (CommandBufferHandle* commandBuffersPtr = commands)
        {
            WebGPU_FFI.QueueSubmit(this, (uint)commands.Length, commandBuffersPtr);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly void Submit(CommandBufferHandle commands)
    {
        WebGPU_FFI.QueueSubmit(this, 1, &commands);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly void Submit(ReadOnlySpan<CommandBuffer> commands)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        ToFFI(commands, allocator, out CommandBufferHandle* handlesPtr, out nuint outCount);
        WebGPU_FFI.QueueSubmit(this, outCount, handlesPtr);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly void Submit(CommandBuffer command)
    {
        CommandBufferHandle handle = (CommandBufferHandle)command;
        WebGPU_FFI.QueueSubmit(this, 1, &handle);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly void WriteBuffer<T>(BufferHandle buffer, ulong bufferOffset, List<T> data)
        where T : unmanaged
    {
        WriteBuffer(buffer, bufferOffset, (ReadOnlySpan<T>)CollectionsMarshal.AsSpan(data));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly void WriteBuffer<T>(BufferHandle buffer, ulong bufferOffset, T[] data)
        where T : unmanaged
    {
        WriteBuffer(buffer, bufferOffset, (ReadOnlySpan<T>)data);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly void WriteBuffer<T>(BufferHandle buffer, ulong bufferOffset, Span<T> data)
        where T : unmanaged
    {
        WriteBuffer(buffer, bufferOffset, (ReadOnlySpan<T>)data);
    }

    public readonly void WriteBuffer<T>(BufferHandle buffer, ulong bufferOffset, ReadOnlySpan<T> data)
        where T : unmanaged
    {
        fixed (T* dataPtr = data)
        {
            WebGPU_FFI.QueueWriteBuffer(
                queue: this,
                buffer: buffer,
                bufferOffset: bufferOffset,
                data: dataPtr,
                size: (nuint)data.Length * (nuint)sizeof(T)
            );
        }
    }


    public readonly void WriteBuffer<T>(BufferHandle buffer, ulong bufferOffset, in T data)
        where T : unmanaged
    {
        fixed (T* dataPtr = &data)
        {
            WebGPU_FFI.QueueWriteBuffer(
                this,
                buffer,
                bufferOffset,
                dataPtr,
                (nuint)sizeof(T)
            );
        }
    }

    public readonly void Dispose()
    {
        if (_ptr != UIntPtr.Zero)
        {
            WebGPU_FFI.QueueRelease(this);
        }
    }

    public static ref nuint AsPointer(ref QueueHandle handle)
    {
        return ref Unsafe.AsRef(handle._ptr);
    }

    public static QueueHandle GetNullHandle()
    {
        return Null;
    }

    public static bool IsNull(QueueHandle handle)
    {
        return handle == Null;
    }

    public static QueueHandle UnsafeFromPointer(nuint pointer)
    {
        return new QueueHandle(pointer);
    }

    public Queue? ToSafeHandle(bool isOwnedHandle)
    {
        return Queue.FromHandle(this, isOwnedHandle);
    }

    public static void Reference(QueueHandle handle)
    {
        WebGPU_FFI.QueueReference(handle);
    }

    public static void Release(QueueHandle handle)
    {
        WebGPU_FFI.QueueRelease(handle);
    }
}