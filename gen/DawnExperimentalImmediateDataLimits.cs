using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct DawnExperimentalImmediateDataLimits
{
    public ChainedStructOut Chain = new();
    public uint MaxImmediateDataRangeByteSize;

    public DawnExperimentalImmediateDataLimits() { }

}
