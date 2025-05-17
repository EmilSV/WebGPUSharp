using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Describes the compute processing in a compute pipeline.
/// For use in a <see cref="WebGPUSharp.ComputePipelineDescriptor" />.
/// </summary>
public unsafe partial struct ComputeStateFFI
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
    /// The ShaderModule containing the code that this programmable stage will execute.
    /// </summary>
    public ShaderModuleHandle Module;
    /// <summary>
    /// The name of the function in the module that this stage will use to perform its work. The corresponding shader function must have the @compute attribute to be identified as this entry point. See <see href="https://gpuweb.github.io/gpuweb/wgsl/#entry-point-decl">Entry Point Declaration</see> for more information.
    /// </summary>
    /// <remarks>You can omit the EntryPoint property if your shader code contains a single function with the @compute attribute set — this will be then default entry point. If entryPoint is omitted and no default entry can be determined, a ValidationError is generated and the resulting ComputePipeline will be invalid.</remarks>
    public StringViewFFI EntryPoint = StringViewFFI.NullValue;
    /// <summary>
    /// The number of item in the <see cref="WebGpuSharp.WebGpuSharp.FFI.ComputeStateFFI.Constants" /> sequence
    /// </summary>
    public nuint ConstantCount;
    /// <summary>
    /// Specifies the values of pipeline-overridable constants in the shader module module.
    /// Each such pipeline-overridable constant is uniquely identified by a single pipeline-overridable constant identifier string,
    /// representing the pipeline constant ID of the constant if its declaration specifies one, and otherwise the constant's identifier name.
    /// The key of each key-value pair must equal the pipeline-overridable constant identifier string|identifier string of one such constant,
    /// with the comparison performed according to the rules for WGSL identifier comparison. When the pipeline is executed,
    /// that constant will have the specified value. Values are specified as GPUPipelineConstantValue, which is a double.
    /// They are converted [$to WGSL type$] of the pipeline-overridable constant (bool/i32/u32/f32/f16). If conversion fails, a validation error is generated.
    /// </summary>
    public ConstantEntryFFI* Constants;

    public ComputeStateFFI() { }

}
