using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public struct ImageCopyBuffer : IWebGpuFFIConvertible<ImageCopyBuffer, ImageCopyBufferFFI>
{
    public TextureDataLayout Layout;
    public required BufferBase Buffer;

    static void IWebGpuFFIConvertible<ImageCopyBuffer, ImageCopyBufferFFI>.UnsafeConvertToFFI(
        in ImageCopyBuffer input, out ImageCopyBufferFFI dest)
    {
        dest = new()
        {
            Layout = input.Layout,
            Buffer = WebGPUMarshal.GetBorrowHandle(input.Buffer)
        };
    }

    static void IWebGpuFFIConvertibleAlloc<ImageCopyBuffer, ImageCopyBufferFFI>.UnsafeConvertToFFI(
        in ImageCopyBuffer input, WebGpuAllocatorHandle allocator, out ImageCopyBufferFFI dest)
    {
        WebGPUMarshal.ToFFI(input, out dest);
    }
}