using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public sealed class Queue : BaseWebGpuSafeHandle<QueueHandle>
{
    private class CacheFactory :
        WebGpuSafeHandleCache<QueueHandle>.ISafeHandleFactory
    {
        public static BaseWebGpuSafeHandle<QueueHandle> Create(QueueHandle handle)
        {
            return new Queue(handle);
        }
    }


    private Queue(QueueHandle handle) : base(handle)
    {
    }

    internal static Queue? FromHandle(QueueHandle handle, bool incrementReferenceCount = true)
    {
        var newQueue = WebGpuSafeHandleCache<QueueHandle>.GetOrCreate<CacheFactory>(handle) as Queue;
        if (incrementReferenceCount && newQueue != null)
        {
            newQueue.AddReference(false);
        }
        return newQueue;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Submit(ReadOnlySpan<CommandBufferHandle> commands)
    {
        _handle.Submit(commands);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Submit(CommandBufferHandle commands)
    {
        _handle.Submit(commands);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteBuffer<T>(Buffer buffer, ulong bufferOffset, List<T> data)
     where T : unmanaged
    {
        _handle.WriteBuffer(buffer.GetHandle(), bufferOffset, (ReadOnlySpan<T>)CollectionsMarshal.AsSpan(data));
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteBuffer<T>(Buffer buffer, ulong bufferOffset, T[] data)
         where T : unmanaged
    {
        _handle.WriteBuffer(buffer.GetHandle(), bufferOffset, (ReadOnlySpan<T>)data);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteBuffer<T>(Buffer buffer, ulong bufferOffset, Span<T> data)
             where T : unmanaged
    {
        _handle.WriteBuffer(buffer.GetHandle(), bufferOffset, (ReadOnlySpan<T>)data);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteBuffer<T>(Buffer buffer, ulong bufferOffset, ReadOnlySpan<T> data)
         where T : unmanaged
    {
        _handle.WriteBuffer(buffer.GetHandle(), bufferOffset, data);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteBuffer<T>(Buffer buffer, ulong bufferOffset, in T data)
         where T : unmanaged
    {
        _handle.WriteBuffer(buffer.GetHandle(), bufferOffset, data);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteTexture<T>(
        in ImageCopyTextureFFI destination,
        List<T> data,
        in TextureDataLayout dataLayout,
        in Extent3D writeSize
    ) where T : unmanaged
    {
        _handle.WriteTexture(
            destination: destination,
            data: (ReadOnlySpan<T>)CollectionsMarshal.AsSpan(data),
            dataLayout: dataLayout,
            writeSize: writeSize
        );
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteTexture<T>(
        in ImageCopyTextureFFI destination,
        T[] data,
        in TextureDataLayout dataLayout,
        in Extent3D writeSize
    ) where T : unmanaged
    {
        _handle.WriteTexture(
            destination: destination,
            data: (ReadOnlySpan<T>)data,
            dataLayout: dataLayout,
            writeSize: writeSize
        );
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteTexture<T>(
        in ImageCopyTextureFFI destination,
        Span<T> data,
        in TextureDataLayout dataLayout,
        in Extent3D writeSize
    ) where T : unmanaged
    {
        _handle.WriteTexture(
            destination: destination,
            data: (ReadOnlySpan<T>)data,
            dataLayout: dataLayout,
            writeSize: writeSize
        );
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteTexture<T>(
        in ImageCopyTextureFFI destination,
        ReadOnlySpan<T> data,
        in TextureDataLayout dataLayout,
        in Extent3D writeSize)
        where T : unmanaged
    {
        _handle.WriteTexture(
            destination: destination,
            data: data,
            dataLayout: dataLayout,
            writeSize: writeSize
        );
    }
}