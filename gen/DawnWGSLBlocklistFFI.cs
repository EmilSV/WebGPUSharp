using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct DawnWGSLBlocklistFFI
{
    public ChainedStruct Chain;
    public nuint BlocklistedFeatureCount;
    public byte** BlocklistedFeatures;

    public DawnWGSLBlocklistFFI()
    {
    }


    public DawnWGSLBlocklistFFI(ChainedStruct chain = default, nuint blocklistedFeatureCount = default, byte** blocklistedFeatures = default)
    {
        this.Chain = chain;
        this.BlocklistedFeatureCount = blocklistedFeatureCount;
        this.BlocklistedFeatures = blocklistedFeatures;
    }

}
