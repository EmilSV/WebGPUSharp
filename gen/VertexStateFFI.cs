using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Describes the vertex processing in a render pipeline.
/// For use in a <see cref="WebGPUSharp.RenderPipelineDescriptor" />.
/// </summary>
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
    /// <summary>
    /// The compiled shader module for this stage.
    /// </summary>
    public ShaderModuleHandle Module;
    /// <summary>
    /// The name of the function in the module that this stage will use to perform its
    /// work. The corresponding shader function must have the @vertex attribute to be
    /// identified as this entry point. See <see href="https://gpuweb.github.io/gpuweb/wgsl/#entry-point-decl">Entry Point Declaration</see> for more information.
    /// </summary>
    /// <remarks>
    /// You can omit the EntryPoint property if your
    /// shader code contains a single function with the @vertex attribute set — this will be
    /// then default entry point. If entryPoint is omitted and no default entry can be
    /// determined, a ValidationError is generated and the resulting RenderPipeline will be
    /// invalid.
    /// </remarks>
    public StringViewFFI EntryPoint = StringViewFFI.NullValue;
    /// <summary>
    /// The number of constants in the sequence.
    /// </summary>
    public nuint ConstantCount = 0;
    /// <summary>
    /// A sequence of unique key value pair, representing override values for
    /// <see href="https://gpuweb.github.io/gpuweb/#typedefdef-gpupipelineconstantvalue">WGSL constants that can be overridden in the pipeline.</see>
    /// </summary>
    public ConstantEntryFFI* Constants;
    /// <summary>
    /// The number of buffers in the sequence.
    /// </summary>
    public nuint BufferCount = 0;
    /// <summary>
    /// A list of  <see cref="VertexBufferLayout"/>s, each defining the layout of vertex attribute data in a
    /// vertex buffer used by this pipeline.
    /// </summary>
    public VertexBufferLayoutFFI* Buffers;

    public VertexStateFFI() { }

}
