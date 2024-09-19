using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using WebGpuSharp.Internal;
using static WebGpuSharp.FFI.WebGPUMarshal;

namespace WebGpuSharp.FFI;

public readonly unsafe partial struct QueueHandle :
    IDisposable, IWebGpuHandle<QueueHandle, Queue>
{
    public void SetLabel(WGPURefText label)
    {
        using WebGpuAllocatorHandle allocator = WebGpuAllocatorHandle.Get();
        fixed (byte* labelPtr = ToRefCstrUtf8(label, allocator))
        {
            WebGPU_FFI.QueueSetLabel(this, labelPtr);
        }
    }

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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly void Submit(CommandBuffer command)
    {
        command._pooledHandle.VerifyToken(command._localToken);
        CommandBufferHandle handle = command._pooledHandle.handle;
        WebGPU_FFI.QueueSubmit(this, 1, &handle);
        PooledHandle<CommandBufferHandle>.Return(command._pooledHandle);
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


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly void WriteTexture<T>(
        in ImageCopyTextureFFI destination,
        List<T> data,
        in TextureDataLayout dataLayout,
        in Extent3D writeSize)
        where T : unmanaged
    {
        WriteTexture(destination, (ReadOnlySpan<T>)CollectionsMarshal.AsSpan(data), dataLayout, writeSize);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly void WriteTexture<T>(
        in ImageCopyTextureFFI destination,
        T[] data,
        in TextureDataLayout dataLayout,
        in Extent3D writeSize)
        where T : unmanaged
    {
        WriteTexture(destination, (ReadOnlySpan<T>)data, dataLayout, writeSize);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly void WriteTexture<T>(
        in ImageCopyTextureFFI destination,
        Span<T> data,
        in TextureDataLayout dataLayout,
        in Extent3D writeSize)
        where T : unmanaged
    {
        WriteTexture(destination, (ReadOnlySpan<T>)data, dataLayout, writeSize);
    }

    public readonly void WriteTexture<T>(
        in ImageCopyTextureFFI destination,
        ReadOnlySpan<T> data,
        in TextureDataLayout dataLayout,
        in Extent3D writeSize)
        where T : unmanaged
    {
        unsafe
        {
            fixed (T* dataPtr = data)
            fixed (ImageCopyTextureFFI* destinationPtr = &destination)
            fixed (TextureDataLayout* dataLayoutPtr = &dataLayout)
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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly void WriteTexture<T>(
        in ImageCopyTexture destination,
        List<T> data,
        in TextureDataLayout dataLayout,
        in Extent3D writeSize)
        where T : unmanaged
    {
        WriteTexture(destination, (ReadOnlySpan<T>)CollectionsMarshal.AsSpan(data), dataLayout, writeSize);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly void WriteTexture<T>(
        in ImageCopyTexture destination,
        T[] data,
        in TextureDataLayout dataLayout,
        in Extent3D writeSize)
        where T : unmanaged
    {
        WriteTexture(destination, (ReadOnlySpan<T>)data, dataLayout, writeSize);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly void WriteTexture<T>(
        in ImageCopyTexture destination,
        Span<T> data,
        in TextureDataLayout dataLayout,
        in Extent3D writeSize)
        where T : unmanaged
    {
        WriteTexture(destination, (ReadOnlySpan<T>)data, dataLayout, writeSize);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly void WriteTexture<T>(
       in ImageCopyTexture destination,
       ReadOnlySpan<T> data,
       in TextureDataLayout dataLayout,
       in Extent3D writeSize)
       where T : unmanaged
    {
        using var destinationTextureHandle = destination.Texture.UnsafeGetCurrentOwnedTextureHandle();
        ImageCopyTextureFFI destinationFFI = new(
            texture: destinationTextureHandle,
            mipLevel: destination.MipLevel,
            origin: destination.Origin,
            aspect: destination.Aspect
        );
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

    public Queue? ToSafeHandle(bool isOwnedHandle)
    {
        return Queue.FromHandle(this, isOwnedHandle);
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