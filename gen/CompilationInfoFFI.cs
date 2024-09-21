using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct CompilationInfoFFI
{
    public ChainedStruct* NextInChain;
    public nuint MessageCount;
    public CompilationMessageFFI* Messages;

    public CompilationInfoFFI()
    {
    }

}
