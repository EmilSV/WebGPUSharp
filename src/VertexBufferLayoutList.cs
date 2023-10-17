using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;


public unsafe sealed class VertexBufferLayoutList : BaseFFIList<
    VertexBufferLayoutMarshal, VertexBufferLayout,
    VertexBufferLayoutFFI, VertexBufferLayoutMarshal.Cache
>
{

}