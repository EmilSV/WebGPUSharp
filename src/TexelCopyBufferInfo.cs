using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public struct TexelCopyBufferInfo : IWebGpuFFIConvertible<TexelCopyBufferInfo, TexelCopyBufferInfoFFI>
{
    public TexelCopyBufferLayout Layout;
    public required BufferBase Buffer;

    static void IWebGpuFFIConvertible<TexelCopyBufferInfo, TexelCopyBufferInfoFFI>.UnsafeConvertToFFI(
        in TexelCopyBufferInfo input, out TexelCopyBufferInfoFFI dest)
    {
        dest = new()
        {
            Layout = input.Layout,
            Buffer = WebGPUMarshal.GetBorrowHandle(input.Buffer)
        };
    }

    static void IWebGpuFFIConvertibleAlloc<TexelCopyBufferInfo, TexelCopyBufferInfoFFI>.UnsafeConvertToFFI(
        in TexelCopyBufferInfo input, WebGpuAllocatorHandle allocator, out TexelCopyBufferInfoFFI dest)
    {
        WebGPUMarshal.ToFFI(input, out dest);
    }
}