using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public unsafe partial struct SharedFenceExportInfo
{
    public ChainedStructOut* NextInChain;
    public SharedFenceType Type;

    public SharedFenceExportInfo()
    {
    }


    public SharedFenceExportInfo(ChainedStructOut* nextInChain = default, SharedFenceType type = default)
    {
        this.NextInChain = nextInChain;
        this.Type = type;
    }


    public SharedFenceExportInfo(SharedFenceType type = default)
    {
        this.Type = type;
    }

}
