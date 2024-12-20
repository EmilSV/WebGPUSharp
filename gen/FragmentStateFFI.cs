using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct FragmentStateFFI
{
    public ChainedStruct* NextInChain;
    public ShaderModuleHandle Module;
    public StringViewFFI EntryPoint = StringViewFFI.NullValue;
    public nuint ConstantCount;
    public ConstantEntryFFI* Constants;
    public nuint TargetCount;
    /// <summary>
    /// A list of  <see cref="WebGpuSharp.ColorTargetState"/> defining the formats and behaviors of the color targets
    /// this pipeline writes to.
    /// </summary>
    public required ColorTargetStateFFI* Targets;

    public FragmentStateFFI() { }

}
