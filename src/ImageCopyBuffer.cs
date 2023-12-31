using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public struct ImageCopyBuffer : IWebGpuFFIConvertible<ImageCopyBuffer, ImageCopyBufferFFI>
{
    public TextureDataLayout Layout;
    public required Buffer Buffer;

    static void IWebGpuFFIConvertible<ImageCopyBuffer, ImageCopyBufferFFI>.UnsafeConvertToFFI(
        in ImageCopyBuffer input, out ImageCopyBufferFFI dest)
    {
        dest = new(
            layout: input.Layout,
            buffer: (BufferHandle)input.Buffer
        );
    }

    static void IWebGpuFFIConvertibleAlloc<ImageCopyBuffer, ImageCopyBufferFFI>.UnsafeConvertToFFI(
        in ImageCopyBuffer input, WebGpuAllocatorHandle allocator, out ImageCopyBufferFFI dest)
    {
        WebGPUMarshal.ToFFI(input, out dest);
    }
}