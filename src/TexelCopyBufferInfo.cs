using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using WebGpuSharp.Marshalling;

namespace WebGpuSharp;

/// <inheritdoc cref="TexelCopyBufferInfoFFI"/>
public struct TexelCopyBufferInfo : IWebGpuFFIConvertible<TexelCopyBufferInfo, TexelCopyBufferInfoFFI>
{
    /// <inheritdoc cref="TexelCopyBufferInfoFFI.Layout"/>
    public TexelCopyBufferLayout Layout;
    /// <inheritdoc cref="TexelCopyBufferInfoFFI.Buffer"/>
    public required Buffer Buffer;

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