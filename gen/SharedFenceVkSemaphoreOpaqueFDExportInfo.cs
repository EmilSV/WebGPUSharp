using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct SharedFenceVkSemaphoreOpaqueFDExportInfo
{
    public ChainedStructOut Chain;
    public int Handle;

    public SharedFenceVkSemaphoreOpaqueFDExportInfo() { }

}
