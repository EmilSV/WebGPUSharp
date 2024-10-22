using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public unsafe partial struct SharedFenceExportInfo
{
    public ChainedStructOut* NextInChain;
    public SharedFenceType Type;

    public SharedFenceExportInfo() { }

}
