using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct DawnWGSLBlocklistFFI
{
    public ChainedStruct Chain;
    public nuint BlocklistedFeatureCount;
    public byte** BlocklistedFeatures;

    public DawnWGSLBlocklistFFI() { }

}
