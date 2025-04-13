using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Represents the fragment state of a pipeline.
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
    public ShaderModuleHandle Module;
    public StringViewFFI EntryPoint = StringViewFFI.NullValue;
    public nuint ConstantCount;
    public ConstantEntryFFI* Constants;
    public nuint TargetCount;
    /// <summary>
    /// A list of  <see cref="ColorTargetState"/> defining the formats and behaviors of the color targets
    /// this pipeline writes to.
    /// </summary>
    public required ColorTargetStateFFI* Targets;

    public FragmentStateFFI() { }

}
