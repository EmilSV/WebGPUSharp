using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using WebGpuSharp.Marshalling;

namespace WebGpuSharp;

/// <inheritdoc cref="TexelCopyBufferInfoFFI"/>
public struct TexelCopyBufferInfo : IWebGpuMarshallable<TexelCopyBufferInfo, TexelCopyBufferInfoFFI>
{
    /// <inheritdoc cref="TexelCopyBufferInfoFFI.Layout"/>
    public TexelCopyBufferLayout Layout;
    /// <inheritdoc cref="TexelCopyBufferInfoFFI.Buffer"/>
    public required Buffer Buffer;

    static void IWebGpuMarshallable<TexelCopyBufferInfo, TexelCopyBufferInfoFFI>.MarshalToFFI(
        in TexelCopyBufferInfo input, out TexelCopyBufferInfoFFI dest)
    {
        dest = new()
        {
            Layout = input.Layout,
            Buffer = WebGPUMarshal.GetBorrowHandle(input.Buffer)
        };
    }
}