using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct PassTimestampWritesFFI
{
    public ChainedStruct* NextInChain;
    public QuerySetHandle QuerySet;
    public uint BeginningOfPassWriteIndex;
    public uint EndOfPassWriteIndex;

    public PassTimestampWritesFFI() { }

}
