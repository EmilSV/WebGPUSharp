using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct ConstantEntryFFI
{
    public ChainedStruct* NextInChain;
    public StringViewFFI Key = new();
    public double Value;

    public ConstantEntryFFI() { }

}
