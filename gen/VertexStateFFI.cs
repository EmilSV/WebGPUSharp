using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct VertexStateFFI
{
    public ChainedStruct* NextInChain;
    public ShaderModuleHandle Module;
    public StringViewFFI EntryPoint = new();
    public nuint ConstantCount;
    public ConstantEntryFFI* Constants;
    public nuint BufferCount;
    /// <summary>
    /// A list of  <see cref="WebGpuSharp.VertexBufferLayout"/>s, each defining the layout of vertex attribute data in a
    /// vertex buffer used by this pipeline.
    /// </summary>
    public VertexBufferLayoutFFI* Buffers;

    public VertexStateFFI() { }

}
