using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct VertexStateFFI
{
    public ChainedStruct* NextInChain;
    public ShaderModuleHandle Module;
    public byte* EntryPoint;
    public nuint ConstantCount;
    public ConstantEntryFFI* Constants;
    public nuint BufferCount;
    public VertexBufferLayoutFFI* Buffers;

    public VertexStateFFI()
    {
    }

}
