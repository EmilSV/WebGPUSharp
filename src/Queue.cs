using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using WebGpuSharp.Marshalling;

namespace WebGpuSharp;

/// <inheritdoc cref="QueueHandle" />
public sealed class Queue :
    WebGPUManagedHandleBase<QueueHandle>,
    IFromHandle<Queue, QueueHandle>
{
    private Queue(QueueHandle handle) : base(handle)
    {
    }

    /// <inheritdoc cref="QueueHandle.SetLabel(WGPURefText)" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void SetLabel(WGPURefText label)
    {
        Handle.SetLabel(label);
    }

    /// <inheritdoc cref="QueueHandle.Submit(ReadOnlySpan{CommandBuffer})" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Submit(ReadOnlySpan<CommandBuffer> commands)
    {
        Handle.Submit(commands);
    }

    /// <inheritdoc cref="QueueHandle.Submit(CommandBuffer)" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Submit(CommandBuffer commands)
    {
        Handle.Submit(commands);
    }

    /// <inheritdoc cref="QueueHandle.WriteBuffer{T}(BufferHandle, ulong, List{T})" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteBuffer<T>(Buffer buffer, ulong bufferOffset, List<T> data)
     where T : unmanaged
    {
        Handle.WriteBuffer(WebGPUMarshal.GetHandle(buffer), bufferOffset, (ReadOnlySpan<T>)CollectionsMarshal.AsSpan(data));
    }

    /// <inheritdoc cref="QueueHandle.WriteBuffer{T}(BufferHandle, ulong, T[])" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteBuffer<T>(Buffer buffer, ulong bufferOffset, T[] data)
         where T : unmanaged
    {
        Handle.WriteBuffer(WebGPUMarshal.GetHandle(buffer), bufferOffset, (ReadOnlySpan<T>)data);
    }

    /// <inheritdoc cref="QueueHandle.WriteBuffer{T}(BufferHandle, ulong, Span{T})" />
    [MethodImpl(MethodImplOptions.AggressiveInlining), OverloadResolutionPriority(1)]
    public void WriteBuffer<T>(Buffer buffer, ulong bufferOffset, Span<T> data)
             where T : unmanaged
    {
        Handle.WriteBuffer(WebGPUMarshal.GetHandle(buffer), bufferOffset, (ReadOnlySpan<T>)data);
    }

    /// <inheritdoc cref="QueueHandle.WriteBuffer{T}(BufferHandle, ulong, ReadOnlySpan{T})" />
    [MethodImpl(MethodImplOptions.AggressiveInlining), OverloadResolutionPriority(2)]
    public void WriteBuffer<T>(Buffer buffer, ulong bufferOffset, ReadOnlySpan<T> data)
         where T : unmanaged
    {
        Handle.WriteBuffer(WebGPUMarshal.GetHandle(buffer), bufferOffset, data);
    }

    /// <inheritdoc cref="QueueHandle.WriteBuffer{T}(BufferHandle, ulong, in T)" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteBuffer<T>(Buffer buffer, ulong bufferOffset, in T data)
         where T : unmanaged
    {
        Handle.WriteBuffer(WebGPUMarshal.GetHandle(buffer), bufferOffset, data);
    }

    /// <inheritdoc cref="QueueHandle.WriteBuffer{T}(BufferHandle, ulong, in T)" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteBuffer<T>(Buffer buffer, in T data)
         where T : unmanaged
    {
        Handle.WriteBuffer(WebGPUMarshal.GetHandle(buffer), 0, data);
    }


    /// <inheritdoc cref="QueueHandle.WriteTexture{T}(in TexelCopyTextureInfo, List{T}, in TexelCopyBufferLayout, in Extent3D)" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteTexture<T>(
        in TexelCopyTextureInfo destination,
        List<T> data,
        in TexelCopyBufferLayout dataLayout,
        in Extent3D writeSize
    ) where T : unmanaged
    {
        Handle.WriteTexture(
            destination: destination,
            data: (ReadOnlySpan<T>)CollectionsMarshal.AsSpan(data),
            dataLayout: dataLayout,
            writeSize: writeSize
        );
    }

    /// <inheritdoc cref="QueueHandle.WriteTexture{T}(in TexelCopyTextureInfo, T[], in TexelCopyBufferLayout, in Extent3D)" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteTexture<T>(
        in TexelCopyTextureInfo destination,
        T[] data,
        in TexelCopyBufferLayout dataLayout,
        in Extent3D writeSize
    ) where T : unmanaged
    {
        Handle.WriteTexture(
            destination: destination,
            data: (ReadOnlySpan<T>)data,
            dataLayout: dataLayout,
            writeSize: writeSize
        );
    }

    /// <inheritdoc cref="QueueHandle.WriteTexture{T}(in TexelCopyTextureInfo, Span{T}, in TexelCopyBufferLayout, in Extent3D)" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteTexture<T>(
        in TexelCopyTextureInfo destination,
        Span<T> data,
        in TexelCopyBufferLayout dataLayout,
        in Extent3D writeSize
    ) where T : unmanaged
    {
        Handle.WriteTexture(
            destination: destination,
            data: (ReadOnlySpan<T>)data,
            dataLayout: dataLayout,
            writeSize: writeSize
        );
    }

    /// <inheritdoc cref="QueueHandle.WriteTexture{T}(in TexelCopyTextureInfo, ReadOnlySpan{T}, in TexelCopyBufferLayout, in Extent3D)" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteTexture<T>(
        in TexelCopyTextureInfo destination,
        ReadOnlySpan<T> data,
        in TexelCopyBufferLayout dataLayout,
        in Extent3D writeSize)
        where T : unmanaged
    {
        Handle.WriteTexture(
            destination: destination,
            data: data,
            dataLayout: dataLayout,
            writeSize: writeSize
        );
    }

    static Queue? IFromHandle<Queue, QueueHandle>.FromHandle(
        QueueHandle handle)
    {
        if (QueueHandle.IsNull(handle))
        {
            return null;
        }

        QueueHandle.Reference(handle);
        return new(handle);
    }

    /// <inheritdoc cref="QueueHandleOnSubmittedWorkDone(QueueWorkDoneCallbackInfoFFI)"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void OnSubmittedWorkDone(Action<QueueWorkDoneStatus, ReadOnlySpan<byte>> callback
        ) => Handle.OnSubmittedWorkDone(callback);

    /// <inheritdoc cref="QueueHandleOnSubmittedWorkDone(QueueWorkDoneCallbackInfoFFI)"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Task OnSubmittedWorkDone() =>
        Handle.OnSubmittedWorkDone();
}