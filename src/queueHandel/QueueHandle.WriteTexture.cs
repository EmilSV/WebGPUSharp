using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using WebGpuSharp.FFI;

namespace WebGpuSharp.FFI;

public readonly partial struct QueueHandle
{

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
}