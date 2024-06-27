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


    public VertexStateFFI(ChainedStruct* nextInChain = default, ShaderModuleHandle module = default, byte* entryPoint = default, nuint constantCount = default, ConstantEntryFFI* constants = default, nuint bufferCount = default, VertexBufferLayoutFFI* buffers = default)
    {
        this.NextInChain = nextInChain;
        this.Module = module;
        this.EntryPoint = entryPoint;
        this.ConstantCount = constantCount;
        this.Constants = constants;
        this.BufferCount = bufferCount;
        this.Buffers = buffers;
    }


    public VertexStateFFI(ShaderModuleHandle module = default, byte* entryPoint = default, nuint constantCount = default, ConstantEntryFFI* constants = default, nuint bufferCount = default, VertexBufferLayoutFFI* buffers = default)
    {
        this.Module = module;
        this.EntryPoint = entryPoint;
        this.ConstantCount = constantCount;
        this.Constants = constants;
        this.BufferCount = bufferCount;
        this.Buffers = buffers;
    }

}
