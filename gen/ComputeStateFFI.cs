using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct ComputeStateFFI
{
    public ChainedStruct* NextInChain;
    public ShaderModuleHandle Module;
    public StringViewFFI EntryPoint = StringViewFFI.NullValue;
    public nuint ConstantCount;
    public ConstantEntryFFI* Constants;

    public ComputeStateFFI() { }

}
