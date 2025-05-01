using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public abstract class QueueBase : WebGPUHandleWrapperBase<QueueHandle>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void SetLabel(WGPURefText label)
    {
        Handle.SetLabel(label);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Submit(ReadOnlySpan<CommandBuffer> commands)
    {
        Handle.Submit(commands);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Submit(CommandBuffer commands)
    {
        Handle.Submit(commands);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteBuffer<T>(Buffer buffer, ulong bufferOffset, List<T> data)
     where T : unmanaged
    {
        Handle.WriteBuffer(WebGPUMarshal.GetBorrowHandle(buffer), bufferOffset, (ReadOnlySpan<T>)CollectionsMarshal.AsSpan(data));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteBuffer<T>(Buffer buffer, ulong bufferOffset, T[] data)
         where T : unmanaged
    {
        Handle.WriteBuffer(WebGPUMarshal.GetBorrowHandle(buffer), bufferOffset, (ReadOnlySpan<T>)data);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteBuffer<T>(Buffer buffer, ulong bufferOffset, Span<T> data)
             where T : unmanaged
    {
        Handle.WriteBuffer(WebGPUMarshal.GetBorrowHandle(buffer), bufferOffset, (ReadOnlySpan<T>)data);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteBuffer<T>(Buffer buffer, ulong bufferOffset, ReadOnlySpan<T> data)
         where T : unmanaged
    {
        Handle.WriteBuffer(WebGPUMarshal.GetBorrowHandle(buffer), bufferOffset, data);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteBuffer<T>(Buffer buffer, ulong bufferOffset, in T data)
         where T : unmanaged
    {
        Handle.WriteBuffer(WebGPUMarshal.GetBorrowHandle(buffer), bufferOffset, data);
    }

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
}