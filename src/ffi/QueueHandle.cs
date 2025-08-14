using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using WebGpuSharp.Internal;
using static WebGpuSharp.Marshalling.WebGPUMarshal;

namespace WebGpuSharp.FFI;

public readonly unsafe partial struct QueueHandle :
    IDisposable, IWebGpuHandle<QueueHandle, Queue>
{
    /// <inheritdoc cref ="SetLabel(StringViewFFI)"/>
    public void SetLabel(WGPURefText label)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();

        var labelUtf8Span = ToUtf8Span(label, allocator, addNullTerminator: false);

        fixed (byte* labelPtr = labelUtf8Span)
        {
            WebGPU_FFI.QueueSetLabel(this, StringViewFFI.CreateExplicitlySized(labelPtr, labelUtf8Span.Length));
        }
    }

    /// <inheritdoc cref ="Submit(nuint, CommandBufferHandle*)"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly void Submit(ReadOnlySpan<CommandBufferHandle> commands)
    {
        fixed (CommandBufferHandle* commandBuffersPtr = commands)
        {
            WebGPU_FFI.QueueSubmit(this, (uint)commands.Length, commandBuffersPtr);
        }
    }

    /// <inheritdoc cref ="Submit(nuint, CommandBufferHandle*)"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly void Submit(CommandBufferHandle commands)
    {
        WebGPU_FFI.QueueSubmit(this, 1, &commands);
    }

    /// <inheritdoc cref ="Submit(nuint, CommandBufferHandle*)"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly void Submit(ReadOnlySpan<CommandBuffer> commands)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        var commandBufferHandles = allocator.AllocAsSpan<CommandBufferHandle>((nuint)commands.Length);
        for (int i = 0; i < commands.Length; i++)
        {
            commands[i]._pooledHandle.VerifyToken(commands[i]._localToken);
            commandBufferHandles[i] = commands[i]._pooledHandle.handle;
        }
        fixed (CommandBufferHandle* commandBuffersPtr = commandBufferHandles)
        {
            WebGPU_FFI.QueueSubmit(this, (uint)commands.Length, commandBuffersPtr);
        }

        for (int i = 0; i < commands.Length; i++)
        {
            PooledHandle<CommandBufferHandle>.Return(commands[i]._pooledHandle);
        }
    }

    /// <inheritdoc cref ="Submit(nuint, CommandBufferHandle*)"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly void Submit(CommandBuffer command)
    {
        command._pooledHandle.VerifyToken(command._localToken);
        CommandBufferHandle handle = command._pooledHandle.handle;
        WebGPU_FFI.QueueSubmit(this, 1, &handle);
        PooledHandle<CommandBufferHandle>.Return(command._pooledHandle);
    }

    /// <inheritdoc cref ="WriteBuffer(BufferHandle, ulong, void*, nuint)"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly void WriteBuffer<T>(BufferHandle buffer, ulong bufferOffset, List<T> data)
        where T : unmanaged
    {
        WriteBuffer(buffer, bufferOffset, (ReadOnlySpan<T>)CollectionsMarshal.AsSpan(data));
    }

    /// <inheritdoc cref ="WriteBuffer(BufferHandle, ulong, void*, nuint)"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly void WriteBuffer<T>(BufferHandle buffer, ulong bufferOffset, T[] data)
        where T : unmanaged
    {
        WriteBuffer(buffer, bufferOffset, (ReadOnlySpan<T>)data);
    }

    /// <inheritdoc cref ="WriteBuffer(BufferHandle, ulong, void*, nuint)"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly void WriteBuffer<T>(BufferHandle buffer, ulong bufferOffset, Span<T> data)
        where T : unmanaged
    {
        WriteBuffer(buffer, bufferOffset, (ReadOnlySpan<T>)data);
    }
    /// <inheritdoc cref ="WriteBuffer(BufferHandle, ulong, void*, nuint)"/>
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

    /// <inheritdoc cref ="WriteBuffer(BufferHandle, ulong, void*, nuint)"/>
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


    /// <inheritdoc cref ="WriteTexture(TexelCopyTextureInfoFFI*, void*, nuint, TexelCopyBufferLayout*, Extent3D*)"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly void WriteTexture<T>(
        in TexelCopyTextureInfoFFI destination,
        List<T> data,
        in TexelCopyBufferLayout dataLayout,
        in Extent3D writeSize)
        where T : unmanaged
    {
        WriteTexture(destination, (ReadOnlySpan<T>)CollectionsMarshal.AsSpan(data), dataLayout, writeSize);
    }

    /// <inheritdoc cref ="WriteTexture(TexelCopyTextureInfoFFI*, void*, nuint, TexelCopyBufferLayout*, Extent3D*)"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly void WriteTexture<T>(
        in TexelCopyTextureInfoFFI destination,
        T[] data,
        in TexelCopyBufferLayout dataLayout,
        in Extent3D writeSize)
        where T : unmanaged
    {
        WriteTexture(destination, (ReadOnlySpan<T>)data, dataLayout, writeSize);
    }

    /// <inheritdoc cref ="WriteTexture(TexelCopyTextureInfoFFI*, void*, nuint, TexelCopyBufferLayout*, Extent3D*)"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly void WriteTexture<T>(
        in TexelCopyTextureInfoFFI destination,
        Span<T> data,
        in TexelCopyBufferLayout dataLayout,
        in Extent3D writeSize)
        where T : unmanaged
    {
        WriteTexture(destination, (ReadOnlySpan<T>)data, dataLayout, writeSize);
    }

    /// <inheritdoc cref ="WriteTexture(TexelCopyTextureInfoFFI*, void*, nuint, TexelCopyBufferLayout*, Extent3D*)"/>
    public readonly void WriteTexture<T>(
        in TexelCopyTextureInfoFFI destination,
        ReadOnlySpan<T> data,
        in TexelCopyBufferLayout dataLayout,
        in Extent3D writeSize)
        where T : unmanaged
    {
        unsafe
        {
            fixed (T* dataPtr = data)
            fixed (TexelCopyTextureInfoFFI* destinationPtr = &destination)
            fixed (TexelCopyBufferLayout* dataLayoutPtr = &dataLayout)
            fixed (Extent3D* writeSizePtr = &writeSize)
            {
                WebGPU_FFI.QueueWriteTexture(
                    queue: this,
                    destination: destinationPtr,
                    data: dataPtr,
                    dataSize: (nuint)data.Length * (nuint)sizeof(T),
                    dataLayout: dataLayoutPtr,
                    writeSize: writeSizePtr
                );
            }
        }
    }

    /// <inheritdoc cref ="WriteTexture(TexelCopyTextureInfoFFI*, void*, nuint, TexelCopyBufferLayout*, Extent3D*)"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly void WriteTexture<T>(
        in TexelCopyTextureInfo destination,
        List<T> data,
        in TexelCopyBufferLayout dataLayout,
        in Extent3D writeSize)
        where T : unmanaged
    {
        WriteTexture(destination, (ReadOnlySpan<T>)CollectionsMarshal.AsSpan(data), dataLayout, writeSize);
    }

    /// <inheritdoc cref ="WriteTexture(TexelCopyTextureInfoFFI*, void*, nuint, TexelCopyBufferLayout*, Extent3D*)"/> 
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly void WriteTexture<T>(
        in TexelCopyTextureInfo destination,
        T[] data,
        in TexelCopyBufferLayout dataLayout,
        in Extent3D writeSize)
        where T : unmanaged
    {
        WriteTexture(destination, (ReadOnlySpan<T>)data, dataLayout, writeSize);
    }

    /// <inheritdoc cref ="WriteTexture(TexelCopyTextureInfoFFI*, void*, nuint, TexelCopyBufferLayout*, Extent3D*)"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly void WriteTexture<T>(
        in TexelCopyTextureInfo destination,
        Span<T> data,
        in TexelCopyBufferLayout dataLayout,
        in Extent3D writeSize)
        where T : unmanaged
    {
        WriteTexture(destination, (ReadOnlySpan<T>)data, dataLayout, writeSize);
    }

    /// <inheritdoc cref ="WriteTexture(TexelCopyTextureInfoFFI*, void*, nuint, TexelCopyBufferLayout*, Extent3D*)"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly void WriteTexture<T>(
       in TexelCopyTextureInfo destination,
       ReadOnlySpan<T> data,
       in TexelCopyBufferLayout dataLayout,
       in Extent3D writeSize)
       where T : unmanaged
    {
        TexelCopyTextureInfoFFI destinationFFI = new()
        {
            Texture = GetBorrowHandle(destination.Texture),
            MipLevel = destination.MipLevel,
            Origin = destination.Origin,
            Aspect = destination.Aspect
        };
        WriteTexture(destinationFFI, data, dataLayout, writeSize);
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
        return ref Unsafe.As<QueueHandle, nuint>(ref handle);
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

    public Queue? ToSafeHandle(bool incrementRefCount)
    {
        if (incrementRefCount)
        {
            return ToSafeHandle<Queue, QueueHandle>(this);
        }
        else
        {
            return ToSafeHandleNoRefIncrement<Queue, QueueHandle>(this);
        }
    }

    public static void Reference(QueueHandle handle)
    {
        WebGPU_FFI.QueueAddRef(handle);
    }

    public static void Release(QueueHandle handle)
    {
        WebGPU_FFI.QueueRelease(handle);
    }
}