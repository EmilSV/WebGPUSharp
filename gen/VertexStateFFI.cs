using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct VertexStateFFI
{
    /// <summary>
    /// Pointer to the first element in a chain of structures that extends this descriptor.
    /// </summary>
    /// <remarks>
    /// Enables struct-chaining, a pattern that extends existing structs with new members while 
    /// maintaining API compatibility. Each extension struct must be properly initialized with 
    /// correct sType values and linked together. For detailed information about struct-chaining,
    /// see: <see href="https://webgpu-native.github.io/webgpu-headers/StructChaining.html"/>
    /// </remarks>
    public ChainedStruct* NextInChain;
    public ShaderModuleHandle Module;
    public StringViewFFI EntryPoint = StringViewFFI.NullValue;
    public nuint ConstantCount;
    public ConstantEntryFFI* Constants;
    public nuint BufferCount;
    /// <summary>
    /// A list of  <see cref="VertexBufferLayout"/>s, each defining the layout of vertex attribute data in a
    /// vertex buffer used by this pipeline.
    /// </summary>
    public VertexBufferLayoutFFI* Buffers;

    public VertexStateFFI() { }

}
