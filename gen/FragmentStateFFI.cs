using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Describes the fragment processing in a render pipeline.
/// 
/// For use in a <see cref="WebGPUSharp.RenderPipelineDescriptor" />.
/// </summary>
public unsafe partial struct FragmentStateFFI
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
    /// The name of the entry point in the compiled shader to use.
    /// 
    /// If not null, there must be a @fragment shader entry point with this name in module. Otherwise, expect exactly one fragment-stage entry point in module, which will be selected.
    /// </summary>
    public StringViewFFI EntryPoint = StringViewFFI.NullValue;
    /// <summary>
    /// The number of item in the <see cref="WebGpuSharp.WebGpuSharp.FFI.FragmentStateFFI.Constants" /> sequence
    /// </summary>
    public nuint ConstantCount = 0;
    /// <summary>
    /// Specifies the values of pipeline-overridable constants in the shader module module.
    /// Each such pipeline-overridable constant is uniquely identified by a single pipeline-overridable constant identifier string,
    /// representing the pipeline constant ID of the constant if its declaration specifies one, and otherwise the constant's identifier name.
    /// The key of each key-value pair must equal the pipeline-overridable constant identifier string|identifier string of one such constant,
    /// with the comparison performed according to the rules for WGSL identifier comparison. When the pipeline is executed,
    /// that constant will have the specified value. Values are specified as GPUPipelineConstantValue, which is a double.
    /// They are converted to WGSL type of the pipeline-overridable constant (bool/i32/u32/f32/f16).
    /// If conversion fails, a validation error is generated.
    /// </summary>
    public ConstantEntryFFI* Constants;
    /// <summary>
    /// The number of items in the <see cref="Targets" /> sequence.
    /// </summary>
    public nuint TargetCount;
    /// <summary>
    /// A list of  <see cref="ColorTargetState"/> defining the formats and behaviors of the color targets
    /// this pipeline writes to.
    /// </summary>
    public required ColorTargetStateFFI* Targets;

    public FragmentStateFFI() { }

}
