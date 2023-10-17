using WebGpuSharp.FFI;

namespace WebGpuSharp;

public partial struct VertexState
{
    public ShaderModuleHandle Module;
    public string EntryPoint;
    public nuint ConstantCount;
    public ConstantEntryList? Constants;
    public VertexBufferLayoutList? Buffers;
}