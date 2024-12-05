using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct SharedFenceVkSemaphoreZirconHandleExportInfo
{
    public ChainedStructOut Chain;
    public uint Handle;

    public SharedFenceVkSemaphoreZirconHandleExportInfo() { }

}
