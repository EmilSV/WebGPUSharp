using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct DawnExperimentalImmediateDataLimits
{
    public ChainedStructOut Chain;
    public uint MaxImmediateDataRangeByteSize;

    public DawnExperimentalImmediateDataLimits() { }

}
